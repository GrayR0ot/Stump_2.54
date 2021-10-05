using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Types
{
    [Serializable]
    public class CharacterMinimalGuildPublicInformations : CharacterMinimalInformations
    {
        public new const short Id = 556;

        public CharacterMinimalGuildPublicInformations(ulong objectId, string name, ushort level, uint rank)
        {
            ObjectId = objectId;
            Name = name;
            Level = level;
            Rank = rank;
        }

        public CharacterMinimalGuildPublicInformations()
        {
        }

        public override short TypeId => Id;

        public uint Rank { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarUInt(Rank);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            Rank = reader.ReadVarUInt();
        }
    }
}