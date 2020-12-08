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
        const string BYR = "byr";
        const string IYR = "iyr";
        const string EYR = "eyr";
        const string HGT = "hgt";
        const string HCL = "hcl";
        const string ECL = "ecl";
        const string PID = "pid";
        const string CID = "cid";
        const string BYR_REG = @"\b(19[2-9][0-9]|200[0-2])\b";
        const string IYR_REG = @"\b(201[0-9]|2020)\b";
        const string EYR_REG = @"\b(202[0-9]|2030)\b";
        const string HGT_REG = @"\b(1[5-8][0-9]cm|19[0-3]cm|59in|6[0-9]in|7[0-6]in)\b";
        const string HCL_REG = @"\s*\#[0-9a-z]{6}";
        const string ECL_REG = @"\b(amb|blu|brn|gry|grn|hzl|oth)\b";
        const string PID_REG = @"\b[0-9]{9}\b";
        const string CID_REG = @".*";

        public static List<string> GetPassports(List<string> passports)
        {
            List<string> allPassports = new List<string>();

            foreach (var passport in passports)
            {
                string pass = passport.Replace("\r\n", " ");
                var pairs = pass.Split(' ').ToList();
                var keys = new Dictionary<string, string>();

                foreach (var pair in pairs)
                {
                    string key = pair.Split(':')[0];
                    string value = pair.Split(':')[1];

                    if (!keys.ContainsKey(key))
                        keys.Add(key, value);
                }

                List<string> requiredFields = new List<string>() { BYR, IYR, EYR, HGT, HCL, ECL, PID };

                if (keys.ContainsKey(requiredFields))
                    allPassports.Add(pass);
            }

            return allPassports;
        }

        public static List<string> ValidatePassports(List<string> passports)
        {
            Dictionary<string, string> validationRules = new Dictionary<string, string>(){ { BYR, BYR_REG }, { IYR, IYR_REG }, { EYR, EYR_REG }, { HGT, HGT_REG }, { HCL, HCL_REG }, { ECL, ECL_REG }, { PID, PID_REG }, { CID, CID_REG } };

            List<string> invalidPass = new List<string>();

            foreach (var passport in passports)
            {
                List<string> pairs = passport.Split(' ').ToList();

                foreach (var pair in pairs)
                {
                    string key = pair.Split(':')[0];
                    string value = pair.Split(':')[1];
                    string rule = "";

                    if (validationRules.ContainsKey(key))
                        rule = validationRules[key];

                    if (!Regex.IsMatch(value, rule))
                    {
                        invalidPass.Add(passport);
                        break;
                    }
                }
            }

            passports.RemoveAll(invalidPass);
            return passports;
        }

    }

}
