using System;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Types
{
    public class Version
    {
        public const short Id = 11;

        public virtual short TypeId
        {
            get { return Id; }
        }

        public sbyte major;
        public sbyte minor;
        public sbyte code;
        public int build;
        public sbyte buildType;


        public Version()
        {
        }

        public Version(sbyte major, sbyte minor, sbyte code, int build, sbyte buildType)
        {
            this.major = major;
            this.minor = minor;
            this.code = code;
            this.build = build;
            this.buildType = buildType;
        }


        public virtual void Serialize(IDataWriter writer)
        {
            writer.WriteSByte(major);
            writer.WriteSByte(minor);
            writer.WriteSByte(code);
            writer.WriteInt(build);
            writer.WriteSByte(buildType);
        }

        public virtual void Deserialize(IDataReader reader)
        {
            major = reader.ReadSByte();
            minor = reader.ReadSByte();
            code = reader.ReadSByte();
            build = reader.ReadInt();
            buildType = reader.ReadSByte();
        }
    }
}