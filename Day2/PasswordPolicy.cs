using System;
using System.Collections.Generic;
using System.Text;

namespace Day2
{
    internal class PasswordPolicy
    {
        public static bool ValidateOne(PasswordPolicyDTO passwordPolicy)
         { 
              int count = 0; 
             foreach (char letter in passwordPolicy.Password) 
                 if (letter == passwordPolicy.Letter) 
                     count++; 
             return (count >= passwordPolicy.Min && count <= passwordPolicy.Max); 
         }

        public static bool ValidateTwo(PasswordPolicyDTO passwordPolicy)
        {
            return (passwordPolicy.Password[passwordPolicy.Min - 1] == passwordPolicy.Letter ^ passwordPolicy.Password[passwordPolicy.Max - 1] == passwordPolicy.Letter);
        }

        public static PasswordPolicyDTO Parse(string line)
         {
            var pwdPolicy = new PasswordPolicyDTO();

            var valuesInit = line.Split((":").ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            var values = valuesInit[0].Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            pwdPolicy.Letter = values[1].ToCharArray()[0]; 
  
            values = values[0].Split("-".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            pwdPolicy.Min = int.Parse(values[0]);
            pwdPolicy.Max = int.Parse(values[1]);

            pwdPolicy.Password = valuesInit[1].Trim();
            return pwdPolicy; 
         }
    } 
}
