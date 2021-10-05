using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class CharacterLevelUpInformationMessage : CharacterLevelUpMessage
    {
        public new const uint Id = 6076;

        public CharacterLevelUpInformationMessage(ushort newLevel, string name, ulong objectId)
        {
            NewLevel = newLevel;
            Name = name;
            ObjectId = objectId;
        }

        public CharacterLevelUpInformationMessage()
        {
        }

        public override uint MessageId => Id;

        public string Name { get; set; }
        public ulong ObjectId { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteUTF(Name);
            writer.WriteVarULong(ObjectId);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            Name = reader.ReadUTF();
            ObjectId = reader.ReadVarULong();
        }
    }
}