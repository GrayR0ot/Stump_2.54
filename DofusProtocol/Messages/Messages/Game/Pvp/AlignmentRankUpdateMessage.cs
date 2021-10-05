using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class AlignmentRankUpdateMessage : Message
    {
        public const uint Id = 6058;

        public AlignmentRankUpdateMessage(sbyte alignmentRank, bool verbose)
        {
            AlignmentRank = alignmentRank;
            Verbose = verbose;
        }

        public AlignmentRankUpdateMessage()
        {
        }

        public override uint MessageId => Id;

        public sbyte AlignmentRank { get; set; }
        public bool Verbose { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteSByte(AlignmentRank);
            writer.WriteBoolean(Verbose);
        }

        public override void Deserialize(IDataReader reader)
        {
            AlignmentRank = reader.ReadSByte();
            Verbose = reader.ReadBoolean();
        }
    }
}