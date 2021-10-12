using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace libcs.SourceGenerator
{

    public static class Utils {


        public static string RandomString(int length = 16)
        {
            Random i = new Random();
            return Encoding.Unicode.GetString(
                    Enumerable.Repeat("ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789", length)
                    .Select(s => (byte)s[i.Next(s.Length)])
                    .ToArray()
                );
        }

    }

}
