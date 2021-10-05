using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class NotificationUpdateFlagMessage : Message
    {
        public const uint Id = 6090;

        public NotificationUpdateFlagMessage(ushort index)
        {
            Index = index;
        }

        public NotificationUpdateFlagMessage()
        {
        }

        public override uint MessageId => Id;

        public ushort Index { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUShort(Index);
        }

        public override void Deserialize(IDataReader reader)
        {
            Index = reader.ReadVarUShort();
        }
    }
}