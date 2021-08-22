using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace libcs.SourceGenerator
{

    public class Utils {

        public static string RandomString(int length)
        {
            Random i = new Random();
            return Encoding.Unicode.GetString(System.Linq.Enumerable.Repeat("ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789", length).Select(s => s[i.Next(s.Length)]).ToArray().ToUnicode());
        }

    }

}
