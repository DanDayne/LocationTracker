using System.Collections.Generic;
using LocationTracker.Database.Parameters;

namespace LocationTracker.Database.StoredProcedures
{
    public class GetUserLocation: IStoredProcedure
    {
        public string ProcedureName => "GetLastLocationForUser";
        private const string UserNameKey = "UserName";
        private const string LongitudeKey = "Longitude";
        private const string LatitudeKey = "Latitude";

        public IEnumerable<StoredProcedureParameter> Parameters { get; }
        public IList<StoredProcedureParameter> OutputParameters { get; }
        
        public GetUserLocation(string name)
        {
            Parameters = new[]
            {
                new StoredProcedureParameter(UserNameKey, name),
            };

            OutputParameters = new List<StoredProcedureParameter>
            {
                new StoredProcedureParameter(LatitudeKey, typeof(float)),
                new StoredProcedureParameter(LongitudeKey, typeof(float))
            };
        }
    }
}