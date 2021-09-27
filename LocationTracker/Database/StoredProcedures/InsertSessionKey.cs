using System.Collections.Generic;
using LocationTracker.Database.Parameters;

namespace LocationTracker.Database.StoredProcedures
{
    public class InsertSessionKey : IStoredProcedure
    {
        public string ProcedureName => "InsertSessionKey";
        private const string SessionKey = "SessionKey";
        public IEnumerable<StoredProcedureParameter> Parameters { get; }
        public IList<StoredProcedureParameter> OutputParameters => null;

        public InsertSessionKey(string sessionKey)
        {
            Parameters = new[]
            {
                new StoredProcedureParameter(SessionKey, sessionKey)
            };
        }
    }
}