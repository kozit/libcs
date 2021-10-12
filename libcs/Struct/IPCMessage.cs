using System.Collections.Generic;
using libcs.IO.Streams;
using System.Runtime.InteropServices;

namespace libcs
{
    [StructLayout(LayoutKind.Sequential)]
    public struct IPCMessage {
        public ulong To;
        public ulong From;
        public ulong Size;
        public byte[] Payload;
    }
}