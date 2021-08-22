using System.Runtime.InteropServices;
using System;
namespace libcs.common
{
    
    [StructLayout(LayoutKind.Sequential)]
    public struct process_interprocess_communication
    {
        public uint From;
        public uint To;

        [MarshalAs(UnmanagedType.LPStr)]
        public string message_group;
        
        [MarshalAs(UnmanagedType.SafeArray)]        
        public byte[] payload;
    }
}