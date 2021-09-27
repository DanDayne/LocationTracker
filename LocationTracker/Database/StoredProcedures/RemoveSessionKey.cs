using System.Collections.Generic;
using LocationTracker.Database.Parameters;

namespace LocationTracker.Database.StoredProcedures
{
    public class RemoveSessionKey : IStoredProcedure
    {
        public string ProcedureName => "RemoveSessionKey";
        private const string SessionKey = "SessionKey";
        public IEnumerable<StoredProcedureParameter> Parameters { get; }
        public IList<StoredProcedureParameter> OutputParameters => null;

        public RemoveSessionKey(string sessionKey)
        {
            Parameters = new[]
            {
                new StoredProcedureParameter(SessionKey, sessionKey)
            };
        }
    }
}