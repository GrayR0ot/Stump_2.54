using System;
using System.Linq;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Types
{
    [Serializable]
    public class DareCriteria
    {
        public const short Id = 501;

        public DareCriteria(sbyte type, int[] @params)
        {
            Type = type;
            this.@params = @params;
        }

        public DareCriteria()
        {
        }

        public virtual short TypeId => Id;

        public sbyte Type { get; set; }
        public int[] @params { get; set; }

        public virtual void Serialize(IDataWriter writer)
        {
            writer.WriteSByte(Type);
            writer.WriteShort((short) @params.Count());
            for (var paramsIndex = 0; paramsIndex < @params.Count(); paramsIndex++)
                writer.WriteInt(@params[paramsIndex]);
        }

        public virtual void Deserialize(IDataReader reader)
        {
            Type = reader.ReadSByte();
            var paramsCount = reader.ReadUShort();
            @params = new int[paramsCount];
            for (var paramsIndex = 0; paramsIndex < paramsCount; paramsIndex++) @params[paramsIndex] = reader.ReadInt();
        }
    }
}