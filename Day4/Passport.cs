using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Day4
{
    internal static class Passport
    {
        public static List<string> GetPassports(List<string> passports)
        {
            List<string> allPassports = new List<string>();

            foreach (var passport in passports)
            {
                string pp = passport.Replace("\r\n", " ");
                var pairs = pp.Split(' ').ToList();
                var keyValues = new Dictionary<string, string>();

                foreach (var pair in pairs)
                {
                    string key = pair.Split(':')[0];
                    string value = pair.Split(':')[1];

                    if (!keyValues.ContainsKey(key))
                        keyValues.Add(key, value);
                }

                List<string> requiredFields = new List<string>() { "byr", "iyr", "eyr", "hgt", "hcl", "ecl", "pid" };

                if (keyValues.ContainsKey(requiredFields))
                    allPassports.Add(pp);
            }

            return allPassports;
        }

        public static List<string> ValidatePassports(List<string> passports)
        {
            Dictionary<string, string> validationRules = new Dictionary<string, string>()
    {
        { "byr", @"\b(19[2-9][0-9]|200[0-2])\b" },
        { "iyr", @"\b(201[0-9]|2020)\b" },
        { "eyr", @"\b(202[0-9]|2030)\b" },
        { "hgt", @"\b(1[5-8][0-9]cm|19[0-3]cm|59in|6[0-9]in|7[0-6]in)\b" },
        { "hcl", @"\s*\#[0-9a-z]{6}" },
        { "ecl", @"\b(amb|blu|brn|gry|grn|hzl|oth)\b" },
        { "pid", @"\b[0-9]{9}\b" },
        { "cid", @".*" }
    };

            List<string> invalidPassports = new List<string>();

            foreach (var pp in passports)
            {
                List<string> pairs = pp.Split(' ').ToList();
                var keyValues = new Dictionary<string, string>();

                foreach (var pair in pairs)
                {
                    string key = pair.Split(':')[0];
                    string value = pair.Split(':')[1];
                    string rule = "";

                    if (validationRules.ContainsKey(key))
                        rule = validationRules[key];

                    if (!Regex.IsMatch(value, rule))
                    {
                        invalidPassports.Add(pp);
                        break;
                    }
                }
            }

            passports.RemoveAll(invalidPassports);
            return passports;
        }

    }

}
