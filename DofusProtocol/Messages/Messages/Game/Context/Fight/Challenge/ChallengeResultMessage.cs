using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class ChallengeResultMessage : Message
    {
        public const uint Id = 6019;

        public ChallengeResultMessage(ushort challengeId, bool success)
        {
            ChallengeId = challengeId;
            Success = success;
        }

        public ChallengeResultMessage()
        {
        }

        public override uint MessageId => Id;

        public ushort ChallengeId { get; set; }
        public bool Success { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUShort(ChallengeId);
            writer.WriteBoolean(Success);
        }

        public override void Deserialize(IDataReader reader)
        {
            ChallengeId = reader.ReadVarUShort();
            Success = reader.ReadBoolean();
        }
    }
}