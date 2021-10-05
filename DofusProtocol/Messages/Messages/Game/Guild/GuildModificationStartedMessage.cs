using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class GuildModificationStartedMessage : Message
    {
        public const uint Id = 6324;

        public GuildModificationStartedMessage(bool canChangeName, bool canChangeEmblem)
        {
            CanChangeName = canChangeName;
            CanChangeEmblem = canChangeEmblem;
        }

        public GuildModificationStartedMessage()
        {
        }

        public override uint MessageId => Id;

        public bool CanChangeName { get; set; }
        public bool CanChangeEmblem { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            var flag = new byte();
            flag = BooleanByteWrapper.SetFlag(flag, 0, CanChangeName);
            flag = BooleanByteWrapper.SetFlag(flag, 1, CanChangeEmblem);
            writer.WriteByte(flag);
        }

        public override void Deserialize(IDataReader reader)
        {
            var flag = reader.ReadByte();
            CanChangeName = BooleanByteWrapper.GetFlag(flag, 0);
            CanChangeEmblem = BooleanByteWrapper.GetFlag(flag, 1);
        }
    }
}