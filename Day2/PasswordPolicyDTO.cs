using System;

namespace Day2
{
    internal class PasswordPolicyDTO
    {
        public PasswordPolicyDTO()
        { 
        }

        public Char Letter { get; set; }
        public int Min { get; set; }
        public int Max { get; set; }
        public string Password { get; set; }

    }
}
