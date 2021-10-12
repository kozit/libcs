using System;
using System.Runtime.Serialization;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using libcs.IO.Streams;

namespace libcs.Types.Unmanaged
{
    [Serializable]
    public unsafe class UnmanagedString : ISerializable
    {
        
        private MemoryStream Stream;
        
        public UnmanagedString(long Length) {
            Stream = new MemoryStream(Length);
        }

        public UnmanagedString(string data) {
            Stream = new MemoryStream(RealToCString(data));            
        }

        public UnmanagedString(byte[] data) {
            Stream = new MemoryStream(data);            
        }
        public UnmanagedString(MemoryStream data) {
            Stream = data;            
        }

        public byte this[uint i] {
            get {

                Stream.Seek(i, SeekOrigin.Begin);
                return Stream.ReadByte();

            }          
        }
        
        public override string ToString() {
            var data = new byte[Stream.Length - 1];
            Stream.Seek(0, SeekOrigin.Begin);
            Stream.Read(ref data);
            
            return System.Text.Encoding.UTF8.GetString(data);
        }

        private byte[] RealToCString(string s)
        {
            var re = new List<byte>();
            re.AddRange(System.Text.Encoding.UTF8.GetBytes(s));
            re.Add(0x00);
            return re.ToArray();
            
        }

        //is this needed?
        public static implicit operator string(UnmanagedString d) => d.ToString();        
        public static implicit operator byte[](UnmanagedString d) => d.Stream.data;
        public static explicit operator UnmanagedString(byte[] d) => new UnmanagedString(d);
        public static explicit operator UnmanagedString(MemoryStream d) => new UnmanagedString(d);
        

        protected UnmanagedString(SerializationInfo info, StreamingContext context)
        {
            Stream = new MemoryStream((byte[])info.GetValue("data", typeof(byte[])));
        }
        public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("data", (byte[])this, typeof(byte[]));
        }

    }
}