using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day4
{
    internal class FieldValuePair
    {
        public FieldValuePair(PassportField field, string value)
        {
            Field = field;
            Value = value;
        }

        public PassportField Field { get; }

        public string Value { get; }

        public bool Validate()
        {
            return Field.ValidateFor(Value);
        }

        public override string ToString()
        {
            return $"{Field.Name}:{Value}:{Validate()}";
        }
    }
}
