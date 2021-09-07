using System.Collections.Generic;

namespace libcs
{
    [StructLayout(LayoutKind.Sequential)]
    public struct App {
        public string? working_directory; 
        public string[] args;
        public KeyValuePair<string, string>[] environment;
    }
}