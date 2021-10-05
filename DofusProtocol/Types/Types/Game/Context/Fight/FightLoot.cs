using System;
using System.Linq;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Types
{
    [Serializable]
    public class FightLoot
    {
        public const short Id = 41;

        public FightLoot(uint[] objects, ulong kamas)
        {
            Objects = objects;
            Kamas = kamas;
        }

        public FightLoot()
        {
        }

        public virtual short TypeId => Id;

        public uint[] Objects { get; set; }
        public ulong Kamas { get; set; }

        public virtual void Serialize(IDataWriter writer)
        {
            writer.WriteShort((short) Objects.Count());
            for (var objectsIndex = 0; objectsIndex < Objects.Count(); objectsIndex++)
                writer.WriteVarUInt(Objects[objectsIndex]);
            writer.WriteVarULong(Kamas);
        }

        public virtual void Deserialize(IDataReader reader)
        {
            var objectsCount = reader.ReadUShort();
            Objects = new uint[objectsCount];
            for (var objectsIndex = 0; objectsIndex < objectsCount; objectsIndex++)
                Objects[objectsIndex] = reader.ReadVarUInt();
            Kamas = reader.ReadVarULong();
        }
    }
}