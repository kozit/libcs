namespace libcs.IO.Streams
{
    public unsafe class UnmanagedMemoryStream : Stream
    {
        public byte* Pointer;
        public byte* Start;

        public UnmanagedMemoryStream(byte* pointer)
        {
            Pointer = pointer;
            Start = pointer;
        }
        public UnmanagedMemoryStream(long Length)
        {
            Pointer = pointer;
            Start = pointer;
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