using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class AlmanachCalendarDateMessage : Message
    {
        public const uint Id = 6341;

        public AlmanachCalendarDateMessage(int date)
        {
            Date = date;
        }

        public AlmanachCalendarDateMessage()
        {
        }

        public override uint MessageId => Id;

        public int Date { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteInt(Date);
        }

        public override void Deserialize(IDataReader reader)
        {
            Date = reader.ReadInt();
        }
    }
}