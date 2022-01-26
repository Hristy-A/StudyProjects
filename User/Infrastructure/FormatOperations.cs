using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formatting
{
    internal static class FormatOperations
    {
        /// <summary>
        /// Returns a string starting with a character 
        /// in uppercase and then every character in 
        /// lowercase.
        /// </summary>
        /// <param name="str">Input string</param>
        /// <returns>The string in required format.</returns>
        public static string ToNormal(this string str) => 
            str.Length >= 2 
            ? str.ToUpper() 
            : char.ToUpper(str[0]).ToString() +
            str.Substring(1).ToLower();
        //нужно ли было в донном методе использовать StringBuilder?

        public static string ToValidFormat(this string str)
        {
            char[] sepSet = { '-', ' ' };
            string[] sepResults = str.Split(sepSet, StringSplitOptions.RemoveEmptyEntries);
            StringBuilder validStr = new StringBuilder();
            for (int i = 0; i < sepResults.Length; i++)
            {
                if (sepResults[i].Length >= 2)
                {
                    validStr.Append(char.ToUpper(sepResults[i][0]));
                    validStr.Append(sepResults[i].Substring(1).ToLower());
                }
                else validStr.Append(sepResults[i].ToUpper());
                if (i < sepResults.Length - 1) validStr.Append('_');
            }
            return validStr.ToString();
        }
    }
}
