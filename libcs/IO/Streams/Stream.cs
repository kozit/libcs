using System;

namespace libcs.IO.Streams
{
    public enum SeekOrigin
    {

        Begin = 0,
        Current = 1,
        End = 2,
    }


    public abstract class Stream : IDisposable
    {
        public abstract bool CanRead { get; }
        public abstract bool CanWrite { get; }
        public abstract bool CanSeek { get; }
        public virtual bool CanTimeout => false;

        public abstract long Length { get; }
        public abstract long Position { get; set; }

        public virtual long GetPosition() {
            return Position;
        }

        public abstract int Read(byte[] buffer, int offset, int count);
        public virtual int ReadByte()
        {
            var oneByteArray = new byte[1];
            int r = Read(oneByteArray, 0, 1);
            return r == 0 ? -1 : oneByteArray[0];
        }        
        public abstract void Write(byte dat);
        public abstract void Write(byte[] dat);

        public virtual void Seek(long offset, SeekOrigin origin = SeekOrigin.Current) {
            switch (origin)
            {
                case SeekOrigin.End:
                    Position = Length;
                    break;
                case SeekOrigin.Begin:
                    Position = 0;
                    break;
                
            }
            Position += offset;
        }

        public abstract void Dispose();

    }

}