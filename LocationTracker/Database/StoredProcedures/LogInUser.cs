using System.Collections.Generic;
using LocationTracker.Database.Parameters;

namespace LocationTracker.Database.StoredProcedures
{
    public class LogInUser : IStoredProcedure
    {
        public string ProcedureName => "LogInUser";
        private const string UserNameKey = "UserName";
        private const string PasswordHashKey = "PasswordHash";
        private const string SessionKey = "SessionKey";
        public IEnumerable<StoredProcedureParameter> Parameters { get; }
        public IList<StoredProcedureParameter> OutputParameters => null;

        public LogInUser(string name, string passwordHash, string sessionKey)
        {
            Parameters = new[]
            {
                new StoredProcedureParameter(UserNameKey, name),
                new StoredProcedureParameter(PasswordHashKey, passwordHash),
                new StoredProcedureParameter(SessionKey, sessionKey)
            };
        }
    }
}