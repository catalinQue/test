using System;
using System.Collections.Generic;
using System.Linq;
using Common;

namespace Day4
{
    internal class PassportField
    {
        public static PassportField CountryId = new PassportField("cid");
        public static PassportField BirthYear = new PassportField("byr", new LengthRule(4).And(new DigitBetweenRule(1920, 2002)));
        public static PassportField IssueYear = new PassportField("iyr", new LengthRule(4).And(new DigitBetweenRule(2010, 2020)));
        public static PassportField ExpirationYear = new PassportField("eyr", new LengthRule(4).And(new DigitBetweenRule(2020, 2030)));
        public static PassportField Height = new PassportField("hgt", new EndsWithRule("cm").And(new DigitBetweenRule(150, 193).With(input => input.Substring(0, input.Length - 2))).Or(new EndsWithRule("in").And(new DigitBetweenRule(59, 76).With(input => input.Substring(0, input.Length - 2)))));
        public static PassportField HairColor = new PassportField("hcl", new LengthRule(7).And(new StartsWithRule("#").And(new LetterOrDigitRule().With(input => input.Substring(1)))));
        public static PassportField EyeColor = new PassportField("ecl", new ChoiceRule(new[] { "amb", "blu", "brn", "gry", "grn", "hzl", "oth" }));
        public static PassportField PassportId = new PassportField("pid", new LengthRule(9).And(new DigitRule()));

        public static PassportField[] All = { CountryId, BirthYear, IssueYear, ExpirationYear, Height, HairColor, EyeColor, PassportId };


        #region " Implementation "

        public string Name { get; }
        private readonly IRules rules;

        public bool Required { get; }

        private PassportField(string name, IRules rules)
        {
            this.Name = name;
            this.rules = rules;
            Required = true;
        }
        private PassportField(string name)
        {
            this.Name = name;
            this.rules = new AlwaysTrueRule();
            Required = false;
        }

        public bool ValidateFor(string input)
        {
            return rules.ValidateFor(input);
        }

        public static FieldValuePair[] ParseMany(string input)
        {
            var result = new List<FieldValuePair>();
            var values = input.Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            foreach (var value in values)
                result.Add(Parse(value));

            return result.ToArray();
        }
        public static FieldValuePair Parse(string input)
        {
            var values = input.Split(":".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            foreach (var field in All)
                if (values[0] == field.Name)
                    return new FieldValuePair(field, values[1]);

            throw new ArgumentException();
        }

        #endregion
    }
}

