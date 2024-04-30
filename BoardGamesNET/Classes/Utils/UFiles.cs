using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGamesNET.Classes.Utils
{
    public class UFiles
    {
        public static string FromRelativeToAbsolutePath(string relativePath)
        {
            if (!File.Exists(relativePath))
            {
                throw new FileNotFoundException("File doesn't exists.");
            }

            return Path.GetFullPath(relativePath);
        }
    }
}
