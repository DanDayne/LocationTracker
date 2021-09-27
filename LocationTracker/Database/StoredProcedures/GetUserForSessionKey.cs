using System.Collections.Generic;
using LocationTracker.Database.Parameters;

namespace LocationTracker.Database.StoredProcedures
{
    public class GetUserForSessionKey : IStoredProcedure
    {
        public string ProcedureName => "GetUserForSessionKey";
        private const string SessionKey = "SessionKey";
        public IEnumerable<StoredProcedureParameter> Parameters { get; }
        public IList<StoredProcedureParameter> OutputParameters => null;
        public StoredProcedureParameter ReturnParameter => null;


        public GetUserForSessionKey(string sessionKey)
        {
            Parameters = new[]
            {
                new StoredProcedureParameter(SessionKey, sessionKey)
            };
        }
    }
}