using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class ChallengeTargetsListRequestMessage : Message
    {
        public const uint Id = 5614;

        public ChallengeTargetsListRequestMessage(ushort challengeId)
        {
            ChallengeId = challengeId;
        }

        public ChallengeTargetsListRequestMessage()
        {
        }

        public override uint MessageId => Id;

        public ushort ChallengeId { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUShort(ChallengeId);
        }

        public override void Deserialize(IDataReader reader)
        {
            ChallengeId = reader.ReadVarUShort();
        }
    }
}