namespace libcs.Types.Unmanaged
{
    public class UnmanagedString {
        
        private byte[] data;
        
        public UnmanagedString() {

        }

        public override string ToString() {
            return "";
        }

        public byte[] ToCString()
        {
            return data;
        }

        private byte[] TrueToCString(string s)
        {
            var re = new byte[s.Length + 1];

            for (int i = 0; i < s.Length; i++)
            {
                re[i] = (byte)s[i];
            }

            re[s.Length + 1] = 0; //c requires null terminated string
            return re;
        }
    }
}