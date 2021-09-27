using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Configuration;
using LocationTracker.Database.Parameters;
using LocationTracker.Database.StoredProcedures;
using LocationTracker.Models;

namespace LocationTracker.Database
{
    public static class DatabaseManager
    {
        private static readonly string ConnectionString =
            ConfigurationManager.ConnectionStrings["DatabaseConnection"]?.ConnectionString;

        public static bool CreateNewUser(string username, string passwordHash)
        {
            return ExecuteStoredProcedureNonQuery(new CreateNewUser(username, passwordHash)) == 1;
        }

        public static bool LogInUser(string username, string passwordHash, string sessionKey)
        {
            return (int) ExecuteStoredProcedureScalar(new LogInUser(username, passwordHash, sessionKey)) == 1;
        }

        public static bool RemoveSessionKey(string sessionKey)
        {
            return ExecuteStoredProcedureNonQuery(new RemoveSessionKey(sessionKey)) == 1;
        }

        public static bool StoreLocation(Location location, string userName)
        {
            var result = ExecuteStoredProcedureNonQuery(new StoreLocation(location, userName));
            return result == 1;
        }

        public static Location GetLastLocation(string userName)
        {
            var rows = ExecuteStoredProcedureReader(new GetUserLocation(userName));
            if (rows.Count == 0) return null;
            var row = rows.First();
            return new Location {Latitude = (double) row[0].Value, Longitude = (double) row[1].Value};
        }

        public static IEnumerable<string> GetUsersWithLocation()
        {
            return ExecuteStoredProcedureReader(new GetUsersWithLocation())
                .Where(row => row.Count != 0)
                .Select(row => row.First().Value.ToString());
        }

        public static bool CheckSessionKeyValidity(string sessionKey)
        {
            return (int) ExecuteStoredProcedureScalar(new CheckSessionKeyValidity(sessionKey)) == 1;
        }

        public static string GetUserNameForSessionKey(string sessionKey)
        {
            return (string) ExecuteStoredProcedureScalar(new GetUserForSessionKey(sessionKey));
        }

        #region INTERNAL

        private static object ExecuteQuery(Func<SqlConnection, object> block, out SqlConnection cnn, bool close = true)
        {
            cnn = new SqlConnection(ConnectionString);
            cnn.Open();
            var result = block(cnn);
            if (close) cnn.Close();
            return result;
        }


        private static List<List<StoredProcedureResult>> ExecuteStoredProcedureReader(IStoredProcedure procedure)
        {
            var reader = (SqlDataReader) ExecuteQuery(
                cnn => CreateSqlCommand(procedure, cnn).ExecuteReader(CommandBehavior.CloseConnection),
                out var connection,
                false
            );

            var result = new List<List<StoredProcedureResult>>();

            while (procedure.OutputParameters != null && reader.Read())
            {
                var row = new List<StoredProcedureResult>();
                result.Add(row);
                row.AddRange(procedure.OutputParameters.Select((parameter, i) =>
                    new StoredProcedureResult(parameter.Name, parameter.Type, reader[i])));
            }

            connection.Close();
            return result;
        }

        private static object ExecuteStoredProcedureScalar(IStoredProcedure procedure)
        {
            return ExecuteQuery(cnn => CreateSqlCommand(procedure, cnn).ExecuteScalar(), out _);
        }

        // returns number of rows affected
        private static int ExecuteStoredProcedureNonQuery(IStoredProcedure procedure)
        {
            return (int) ExecuteQuery(cnn => CreateSqlCommand(procedure, cnn).ExecuteNonQuery(), out _);
        }

        private static SqlCommand CreateSqlCommand(IStoredProcedure procedure, SqlConnection cnn)
        {
            var cmd = new SqlCommand(procedure.ProcedureName, cnn)
            {
                CommandType = CommandType.StoredProcedure
            };

            if (procedure.Parameters != null)
                foreach (var procedureParameter in procedure.Parameters)
                {
                    cmd.Parameters.AddWithValue(procedureParameter.Name, procedureParameter.Value);
                }

            return cmd;
        }

        #endregion:
    }
}