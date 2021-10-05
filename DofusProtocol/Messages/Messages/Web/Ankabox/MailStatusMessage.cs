using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class MailStatusMessage : Message
    {
        public const uint Id = 6275;

        public MailStatusMessage(ushort unread, ushort total)
        {
            Unread = unread;
            Total = total;
        }

        public MailStatusMessage()
        {
        }

        public override uint MessageId => Id;

        public ushort Unread { get; set; }
        public ushort Total { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUShort(Unread);
            writer.WriteVarUShort(Total);
        }

        public override void Deserialize(IDataReader reader)
        {
            Unread = reader.ReadVarUShort();
            Total = reader.ReadVarUShort();
        }
    }
}