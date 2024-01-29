using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGamesNET.Classes.Utils
{
    public class UMath
    {

        public static bool Beetween(int n, int a, int b)
        {
            int min = Math.Min(a, b);
            int max = Math.Max(a, b);

            return n >= min && n <= max;
        }

    }
}
