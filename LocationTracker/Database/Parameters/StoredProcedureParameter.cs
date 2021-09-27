using System;
using System.Data;

namespace LocationTracker.Database.Parameters
{
    public class StoredProcedureParameter
    {
        public string Name { get; }
        public object Value { get; }
        public Type Type { get; }

        public StoredProcedureParameter(string name, Type type)
        {
            Name = name;
            Type = type;
        }

        public StoredProcedureParameter(string name, string value)
        {
            Name = name;
            Value = value;
            Type = typeof(string);
        }
        
        public StoredProcedureParameter(string name, double value)
        {
            Name = name;
            Value = value;
            Type = typeof(double);
        }
    }
}