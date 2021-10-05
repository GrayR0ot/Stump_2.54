using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class AllianceFactsRequestMessage : Message
    {
        public const uint Id = 6409;

        public AllianceFactsRequestMessage(uint allianceId)
        {
            AllianceId = allianceId;
        }

        public AllianceFactsRequestMessage()
        {
        }

        public override uint MessageId => Id;

        public uint AllianceId { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUInt(AllianceId);
        }

        public override void Deserialize(IDataReader reader)
        {
            AllianceId = reader.ReadVarUInt();
        }
    }
}