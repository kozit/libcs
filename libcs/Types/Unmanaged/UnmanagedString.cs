using libcs.IO.Streams;
namespace libcs.Types.Unmanaged
{
    public unsafe class UnmanagedString {
        
        private UnmanagedMemoryStream Stream;
        private long Length;
        
        public UnmanagedString(long Length) {
            Stream = new UnmanagedMemoryStream(Length);
        }

        public override string ToString() {
            return "";
        }

        public byte[] ToCString()
        {
            return RealToCString(data);
        }

        private byte[] RealToCString(string s)
        {
            var re = new byte[s.Length + 1];

            for (int i = 0; i < s.Length; i++)
            {
                re[i] = (byte)s[i];
            }

            re[s.Length + 1] = 0x00; //c requires null terminated string
            return re;
        }
    }
}