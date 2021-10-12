using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace libcs
{
    [StructLayout(LayoutKind.Sequential)]
    public struct App {
        [MarshalAs(UnmanagedType.LPStr)]
        public string working_directory; 
        public string[] args;
        public KeyValuePair<string, string>[] environment;
    }
}