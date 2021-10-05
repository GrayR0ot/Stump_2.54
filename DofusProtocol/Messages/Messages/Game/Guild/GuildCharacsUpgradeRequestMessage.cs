using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class GuildCharacsUpgradeRequestMessage : Message
    {
        public const uint Id = 5706;

        public GuildCharacsUpgradeRequestMessage(sbyte charaTypeTarget)
        {
            CharaTypeTarget = charaTypeTarget;
        }

        public GuildCharacsUpgradeRequestMessage()
        {
        }

        public override uint MessageId => Id;

        public sbyte CharaTypeTarget { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteSByte(CharaTypeTarget);
        }

        public override void Deserialize(IDataReader reader)
        {
            CharaTypeTarget = reader.ReadSByte();
        }
    }
}