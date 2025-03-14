using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransparenciaWindows.Utils
{
    public static class StringExtensions
    {
        public static string PadLeftSubstring(this string str, int sizeToPad, char charToPad = '0')
        {
            if (sizeToPad > str.Length)
            {
                return str.PadLeft(sizeToPad, charToPad);
            }
            else if (sizeToPad < str.Length)
            {
                return str.Substring(0, sizeToPad);
            }
            else { return str; }
        }
        public static string PadRightSubstring(this string str, int sizeToPad)
        {
            if (sizeToPad > str.Length)
            {
                return str.PadRight(sizeToPad);
            } else if (sizeToPad < str.Length)
            {
                return str.Substring(0, sizeToPad);
            } else { return str; }
        }
    }
}
