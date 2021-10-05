using System;
using System.Linq;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class NewMailMessage : MailStatusMessage
    {
        public new const uint Id = 6292;

        public NewMailMessage(ushort unread, ushort total, int[] sendersAccountId)
        {
            Unread = unread;
            Total = total;
            SendersAccountId = sendersAccountId;
        }

        public NewMailMessage()
        {
        }

        public override uint MessageId => Id;

        public int[] SendersAccountId { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteShort((short) SendersAccountId.Count());
            for (var sendersAccountIdIndex = 0;
                sendersAccountIdIndex < SendersAccountId.Count();
                sendersAccountIdIndex++) writer.WriteInt(SendersAccountId[sendersAccountIdIndex]);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            var sendersAccountIdCount = reader.ReadUShort();
            SendersAccountId = new int[sendersAccountIdCount];
            for (var sendersAccountIdIndex = 0; sendersAccountIdIndex < sendersAccountIdCount; sendersAccountIdIndex++)
                SendersAccountId[sendersAccountIdIndex] = reader.ReadInt();
        }
    }
}