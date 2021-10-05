using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class CharacterLevelUpMessage : Message
    {
        public const uint Id = 5670;

        public CharacterLevelUpMessage(ushort newLevel)
        {
            NewLevel = newLevel;
        }

        public CharacterLevelUpMessage()
        {
        }

        public override uint MessageId => Id;

        public ushort NewLevel { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUShort(NewLevel);
        }

        public override void Deserialize(IDataReader reader)
        {
            NewLevel = reader.ReadVarUShort();
        }
    }
}