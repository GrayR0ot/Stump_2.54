using System;
using System.Linq;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class DareWonListMessage : Message
    {
        public const uint Id = 6682;

        public DareWonListMessage(double[] dareId)
        {
            DareId = dareId;
        }

        public DareWonListMessage()
        {
        }

        public override uint MessageId => Id;

        public double[] DareId { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort((short) DareId.Count());
            for (var dareIdIndex = 0; dareIdIndex < DareId.Count(); dareIdIndex++)
                writer.WriteDouble(DareId[dareIdIndex]);
        }

        public override void Deserialize(IDataReader reader)
        {
            var dareIdCount = reader.ReadUShort();
            DareId = new double[dareIdCount];
            for (var dareIdIndex = 0; dareIdIndex < dareIdCount; dareIdIndex++)
                DareId[dareIdIndex] = reader.ReadDouble();
        }
    }
}