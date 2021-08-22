namespace libcs.IO.Streams
{
    public unsafe class UnmanagedMemoryStream : Stream
    {
        public byte* Pointer;

        public UnmanagedMemoryStream(byte* data)
        {
            Pointer = data;
        }
        public override void Write(byte dat)
        {
            Pointer[Position++] = dat;
        }
        public override int ReadByte()
        {
            return Pointer[Position++];
        }
    }
}