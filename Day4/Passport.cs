using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day4
{
    internal class Passport
    {
        public Passport(FieldValuePair[] fields)
        {
            Fields = fields;
            ContainsRequiredFields = (fields.Count(f => f.Field.Required == true) == 7);
        }

        public bool ContainsRequiredFields { get; }

        public FieldValuePair[] Fields { get; }

        public bool Validate()
        {
            if (!ContainsRequiredFields)
                return false;

            foreach (FieldValuePair id in Fields)
                if (!id.Validate())
                    return false;
            return true;
        }

        public static Passport[] ParseMany(string inputs)
        {
            var result = new List<Passport>();

            var values = inputs.Split(new[] { Environment.NewLine + Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var value in values)
                result.Add(Passport.Parse(value));

            return result.ToArray();
        }
        public static Passport Parse(string input)
        {
            return new Passport(PassportField.ParseMany(input.Replace(Environment.NewLine, " ")));
        }
    }


}
