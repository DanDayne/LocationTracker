using System.Collections.Generic;
using LocationTracker.Database.Parameters;
using LocationTracker.Models;

namespace LocationTracker.Database.StoredProcedures
{
    public class StoreLocation : IStoredProcedure
    {
        public string ProcedureName => "StoreLocation";

        private const string LongitudeKey = "Longitude";
        private const string LatitudeKey = "Latitude";
        private const string UserNameKey = "UserName";
        public IEnumerable<StoredProcedureParameter> Parameters { get; }
        public IList<StoredProcedureParameter> OutputParameters => null;

        public StoreLocation(Location location, string userName)
        {
            Parameters = new[]
            {
                new StoredProcedureParameter(LongitudeKey, location.Longitude),
                new StoredProcedureParameter(LatitudeKey, location.Latitude),
                new StoredProcedureParameter(UserNameKey, userName)
            };
        }
    }
}