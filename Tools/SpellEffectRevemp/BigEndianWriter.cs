using System;
using System.IO;
using System.Text;

namespace SpellEffect
{
    public class BigEndianWriter : IDisposable, IDataWriter
    {
        private BinaryWriter m_writer;

        public BigEndianWriter()
        {
            m_writer = new BinaryWriter(new MemoryStream(), Encoding.UTF8);
        }

        public BigEndianWriter(Stream stream)
        {
            m_writer = new BinaryWriter(stream, Encoding.UTF8);
        }

        public Stream BaseStream => m_writer.BaseStream;

        public long BytesAvailable => m_writer.BaseStream.Length - m_writer.BaseStream.Position;

        public long Position
        {
            get => m_writer.BaseStream.Position;
            set => m_writer.BaseStream.Position = value;
        }

        public byte[] Data
        {
            get
            {
                var position = m_writer.BaseStream.Position;
                var array = new byte[m_writer.BaseStream.Length];
                m_writer.BaseStream.Position = 0L;
                m_writer.BaseStream.Read(array, 0, (int) m_writer.BaseStream.Length);
                m_writer.BaseStream.Position = position;
                return array;
            }
        }

        public void WriteShort(short @short)
        {
            WriteBigEndianBytes(BitConverter.GetBytes(@short));
        }

        public void WriteInt(int @int)
        {
            WriteBigEndianBytes(BitConverter.GetBytes(@int));
        }

        public void WriteLong(long @long)
        {
            WriteBigEndianBytes(BitConverter.GetBytes(@long));
        }

        public void WriteUShort(ushort @ushort)
        {
            WriteBigEndianBytes(BitConverter.GetBytes(@ushort));
        }

        public void WriteUInt(uint @uint)
        {
            WriteBigEndianBytes(BitConverter.GetBytes(@uint));
        }

        public void WriteULong(ulong @ulong)
        {
            WriteBigEndianBytes(BitConverter.GetBytes(@ulong));
        }

        public void WriteByte(byte @byte)
        {
            m_writer.Write(@byte);
        }

        public void WriteSByte(sbyte @byte)
        {
            m_writer.Write(@byte);
        }

        public void WriteFloat(float @float)
        {
            m_writer.Write(@float);
        }

        public void WriteBoolean(bool @bool)
        {
            if (@bool)
                m_writer.Write((byte) 1);
            else
                m_writer.Write((byte) 0);
        }

        public void WriteChar(char @char)
        {
            WriteBigEndianBytes(BitConverter.GetBytes(@char));
        }

        public void WriteDouble(double @double)
        {
            WriteBigEndianBytes(BitConverter.GetBytes(@double));
        }

        public void WriteSingle(float single)
        {
            WriteBigEndianBytes(BitConverter.GetBytes(single));
        }

        public void WriteUTF(string str)
        {
            var bytes = Encoding.UTF8.GetBytes(str);
            var num = (byte) bytes.Length;
            //this.WriteReversUShort(num);
            WriteByte(num);
            for (var i = 0; i < num; i++) m_writer.Write(bytes[i]);
        }

        public void WriteUTFBytes(string str)
        {
            var bytes = Encoding.UTF8.GetBytes(str);
            var num = bytes.Length;
            for (var i = 0; i < num; i++) m_writer.Write(bytes[i]);
        }

        public void WriteBytes(byte[] data)
        {
            m_writer.Write(data);
        }

        public void Seek(int offset)
        {
            Seek(offset, SeekOrigin.Begin);
        }

        public void Clear()
        {
            m_writer = new BinaryWriter(new MemoryStream(), Encoding.UTF8);
        }

        public void Dispose()
        {
            m_writer.Flush();
            m_writer.Dispose();
            m_writer = null;
        }

        private void WriteBigEndianBytes(byte[] endianBytes)
        {
            /*for (int i = endianBytes.Length - 1; i >= 0; i--)
            {
                this.m_writer.Write(endianBytes[i]);
            }*/
            for (var i = 0; i < endianBytes.Length; i++) m_writer.Write(endianBytes[i]);
        }

        private void WriteBigEndianReversBytes(byte[] endianBytes)
        {
            for (var i = endianBytes.Length - 1; i >= 0; i--) m_writer.Write(endianBytes[i]);
            /*for (int i = 0; i < endianBytes.Length; i++)
            {
                this.m_writer.Write(endianBytes[i]);
            }*/
        }

        public void WriteReversUShort(ushort @ushort)
        {
            WriteBigEndianReversBytes(BitConverter.GetBytes(@ushort));
        }

        public void Seek(int offset, SeekOrigin seekOrigin)
        {
            m_writer.BaseStream.Seek(offset, seekOrigin);
        }
    }

    public interface IDataWriter
    {
        byte[] Data { get; }

        long Position { get; }

        void WriteShort(short @short);

        void WriteInt(int @int);

        void WriteLong(long @long);

        void WriteUShort(ushort @ushort);

        void WriteUInt(uint @uint);

        void WriteULong(ulong @ulong);

        void WriteByte(byte @byte);

        void WriteSByte(sbyte @byte);

        void WriteFloat(float @float);

        void WriteBoolean(bool @bool);

        void WriteChar(char @char);

        void WriteDouble(double @double);

        void WriteSingle(float single);

        void WriteUTF(string str);

        void WriteUTFBytes(string str);

        void WriteBytes(byte[] data);

        void Clear();

        void Seek(int offset);
    }
}