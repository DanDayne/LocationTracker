using System.Collections.Generic;
using LocationTracker.Database.Parameters;

namespace LocationTracker.Database.StoredProcedures
{
    public class CreateNewUser : IStoredProcedure
    {
        public string ProcedureName => "CreateNewUser";
        private const string UserNameKey = "UserName";
        private const string PasswordHashKey = "PasswordHash";
        public IEnumerable<StoredProcedureParameter> Parameters { get; }
        public IList<StoredProcedureParameter> OutputParameters => null;
        public StoredProcedureParameter ReturnParameter => null;


        public CreateNewUser(string name, string passwordHash)
        {
            Parameters = new[]
            {
                new StoredProcedureParameter(UserNameKey, name),
                new StoredProcedureParameter(PasswordHashKey, passwordHash),
            };
        }
    }
}