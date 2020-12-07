using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day4
{
    internal static class DictionaryExtension
    {
        public static bool ContainsKey(this Dictionary<string, string> source, IEnumerable<string> containingData)
        {
            if (containingData == null)
                return false;

            foreach (var item in containingData)
            {
                if (!source.ContainsKey(item))
                    return false;
            }

            return true;
        }

        public static void RemoveAll(this List<string> source, IEnumerable<string> removingData)
        {
            if (removingData == null)
                return;

            foreach (var item in removingData)
                source.Remove(item);
        }
    }
}
