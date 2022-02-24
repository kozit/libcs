using System;

namespace libcs.IO.Streams
{
    public unsafe class MemoryStream : Stream
    {
        public byte[] data;

        public MemoryStream(byte[] Data)
        {
            data = Data;
            Seek(0 , SeekOrigin.Begin);
        }

        public MemoryStream(ref byte[] Data)
        {
            data = Data;
            Seek(0 , SeekOrigin.Begin);
        }

        public MemoryStream(long Length)
        {
            data = new byte[Length];
            for (int i = 0; i < Length; i++)
            {
                Write(0x00);
            }
            Seek(0 , SeekOrigin.Begin);
        }
        public override void Write(byte dat)
        {
            data[Position++] = dat;
        }
        public override void Write(byte[] buffer)
        {
            Array.Copy(buffer, 0, data, Position, buffer.LongLength);
        }
        public override byte ReadByte()
        {
            return data[Position++];
        }

        public override void Read(ref byte[] buffer)
        {
            Array.Copy(data, Position, buffer, 0, buffer.LongLength);
            Position += buffer.LongLength;
        }

        public override void Dispose()
        {
            
        }

        public static implicit operator byte[](MemoryStream d) => d.data;
        public static explicit operator MemoryStream(byte[] d) => new MemoryStream(d);

    }
}