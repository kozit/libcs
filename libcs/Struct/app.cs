using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace libcs
{
    [StructLayout(LayoutKind.Sequential)]
    public struct App {
        public byte[] working_directory; 
        public byte[][] args;
        public KeyValuePair<byte[], byte[]>[] environment;
    }
}