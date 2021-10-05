using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class CharacterCapabilitiesMessage : Message
    {
        public const uint Id = 6339;

        public CharacterCapabilitiesMessage(uint guildEmblemSymbolCategories)
        {
            GuildEmblemSymbolCategories = guildEmblemSymbolCategories;
        }

        public CharacterCapabilitiesMessage()
        {
        }

        public override uint MessageId => Id;

        public uint GuildEmblemSymbolCategories { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUInt(GuildEmblemSymbolCategories);
        }

        public override void Deserialize(IDataReader reader)
        {
            GuildEmblemSymbolCategories = reader.ReadVarUInt();
        }
    }
}