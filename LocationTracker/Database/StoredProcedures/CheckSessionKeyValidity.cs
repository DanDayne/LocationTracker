using System.Collections.Generic;
using System.Data;
using LocationTracker.Database.Parameters;

namespace LocationTracker.Database.StoredProcedures
{
    public class CheckSessionKeyValidity : IStoredProcedure
    {
        public string ProcedureName => "CheckSessionKeyValidity";
        private const string SessionKey = "SessionKey";
        public IEnumerable<StoredProcedureParameter> Parameters { get; }
        public IList<StoredProcedureParameter> OutputParameters => null;
        public StoredProcedureParameter ReturnParameter => null;

        public CheckSessionKeyValidity(string sessionKey)
        {
            Parameters = new[]
            {
                new StoredProcedureParameter(SessionKey, sessionKey)
            };
        }
    }
}