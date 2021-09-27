using System.Collections.Generic;
using LocationTracker.Database.Parameters;

namespace LocationTracker.Database
{
    public interface IStoredProcedure
    {
        string ProcedureName { get; }
        IEnumerable<StoredProcedureParameter> Parameters { get; }
        IList<StoredProcedureParameter> OutputParameters { get; }
    }
}