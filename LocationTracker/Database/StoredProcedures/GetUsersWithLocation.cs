using System.Collections.Generic;
using System.Data;
using LocationTracker.Database.Parameters;

namespace LocationTracker.Database.StoredProcedures
{
    public class GetUsersWithLocation : IStoredProcedure
    {
        public string ProcedureName => "GetUsersWithLocation";
        private const string ReturnKey = "ReturnKey";
        public IEnumerable<StoredProcedureParameter> Parameters => null;
        public IList<StoredProcedureParameter> OutputParameters { get; }


        public GetUsersWithLocation()
        {
            OutputParameters = new[]
            {
                new StoredProcedureParameter(ReturnKey, typeof(string))
            };
        }
    }
}