using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGamesNET.Classes.Utils
{
    public class UString
    {

        public static string GetBetweenChars(string line, char firstChar, char secondChar)
        {
            int from = line.IndexOf(firstChar);
            int to = line.LastIndexOf(secondChar);

            if (from == -1)
            {
                throw new ArgumentException("First char doesn't exists.");
            }

            if (to == -1)
            {
                throw new ArgumentException("Second char doesn't exists.");
            }

            if (from == to)
            {
                throw new ArgumentException("First char and second char are the same.");
            }

            if (from == line.Length - 1)
            {
                throw new ArgumentException("First char is at the end of the string.");
            }

            if (to == 0)
            {
                throw new ArgumentException("Second char is at the beginning of the string.");
            }

            int start = from + 1;
            int length = to - start;

            return line.Substring(start, length);
        }

        public static string GetBetweenBrackets(string line)
        {
            return GetBetweenChars(line, '[', ']');
        }

    }
}
