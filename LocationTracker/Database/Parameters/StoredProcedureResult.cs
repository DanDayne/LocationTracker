using System;

namespace LocationTracker.Database.Parameters
{
    public class StoredProcedureResult
    {
        public string Name { get; }
        public Type Type { get; }

        public object Value { get; set; }

        public StoredProcedureResult(string name, Type type, object value)
        {
            Name = name;
            Type = type;
            Value = value;
        }
    }
}