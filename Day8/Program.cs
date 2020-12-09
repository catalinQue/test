
namespace Day8
{
    internal class Program
    {
        public bool isTerminated = false;

        public int Execute(string[] lignes)
        {
            int ip = 0;
            int acc = 0;
            string opCode = "";
            string instruction = "";
            bool[] seen = new bool[611];

            while (true)
            {
                if ((ip == lignes.Length))
                {
                    isTerminated = true;
                    return acc;
                }
                if (seen[ip])
                {
                    return acc;
                }

                seen[ip] = true;

                instruction = lignes[ip].ToString().Split(null)[0].ToString();
                opCode = lignes[ip].ToString().Split(null)[1].ToString();

                switch (lignes[ip].ToString().Split(null)[0].ToString())
                {
                    case "nop":
                        ip++;
                        break;

                    case "acc":
                        ip++;
                        acc = GetResultat(instruction, acc, opCode);
                        break;

                    case "jmp":
                        ip = GetResultat(instruction, ip, opCode);
                        break;

                }

            }
        }

        private  int GetResultat(string instruction, int value, string opCode)
        {
            int result = 0;

            if (opCode[0].ToString() == "+")
            {
                result = value + int.Parse(opCode.Remove(0, 1).ToString());
            }
            else if (opCode[0].ToString() == "-")
            {
                result = value - int.Parse(opCode.Remove(0, 1).ToString());
            }
            return result;
        }
    }
}
