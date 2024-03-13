using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGamesNET.Classes.Utils
{
    /// <summary>
    /// Class that contains static mathematical functions.
    /// </summary>
    public class UMath
    {

        /// <summary>
        /// Check if the number <paramref name="n"/> is between the number <paramref name="a"/> and <paramref name="b"/>.<br/>
        /// That means 
        /// <code>
        /// if (a &lt; b)
        /// {
        ///     return a &lt;= n &lt;= b
        /// }
        /// else
        /// {
        ///     return b &lt;= n &lt;= a
        /// }
        /// </code>
        /// </summary>
        /// <param name="n">Number to check.</param>
        /// <param name="a">First inclusive number (min or max).</param>
        /// <param name="b">Second inclusive number (max or min).</param>
        /// <returns><see langword="true"/> if <paramref name="n"/> is between <paramref name="a"/> and <paramref name="b"/>, otherwise <see langword="false"/>.</returns>
        public static bool Beetween(int n, int a, int b)
        {
            int min = Math.Min(a, b);
            int max = Math.Max(a, b);

            return n >= min && n <= max;
        }

    }
}
