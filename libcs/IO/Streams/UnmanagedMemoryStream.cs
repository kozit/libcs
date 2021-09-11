namespace libcs.IO.Streams
{
    public unsafe class UnmanagedMemoryStream : Stream
    {
        public byte* Pointer;

        public UnmanagedMemoryStream(byte* pointer)
        {
            Pointer = pointer;
        }
        public UnmanagedMemoryStream(long Length)
        {
            Pointer = new byte*();
            for (int i = 0; i < Length; i++)
            {
                Write(0x00);
            }
            Seek(0 , SeekOrigin.Begin);
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