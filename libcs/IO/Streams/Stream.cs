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
        public virtual bool CanRead { get; } = true;
        public virtual bool CanWrite { get; } = true;
        public virtual bool CanSeek { get; } = true;
        public virtual bool CanTimeout => false;

        public long Length { get; }
        public long Position { get; protected set; }

        public virtual long GetPosition() {
            return Position;
        }

        public abstract void Read(ref byte[] buffer);
        
        public virtual byte ReadByte()
        {
            var oneByteArray = new byte[1];
            Read(ref oneByteArray);
            return oneByteArray[0];
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
        public static implicit operator byte[](Stream d){
            var current = d.Position;

            d.Seek(0, SeekOrigin.Begin);
            var Output = new byte[d.Length];
            d.Read(ref Output);
            d.Seek(current, SeekOrigin.Begin);
            return Output;
        }
    }

}