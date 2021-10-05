using System;
using System.Linq;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class GameRolePlayArenaInvitationCandidatesAnswer : Message
    {
        public const uint Id = 6783;

        public GameRolePlayArenaInvitationCandidatesAnswer(LeagueFriendInformations[] candidates)
        {
            Candidates = candidates;
        }

        public GameRolePlayArenaInvitationCandidatesAnswer()
        {
        }

        public override uint MessageId => Id;

        public LeagueFriendInformations[] Candidates { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort((short) Candidates.Count());
            for (var candidatesIndex = 0; candidatesIndex < Candidates.Count(); candidatesIndex++)
            {
                var objectToSend = Candidates[candidatesIndex];
                objectToSend.Serialize(writer);
            }
        }

        public override void Deserialize(IDataReader reader)
        {
            var candidatesCount = reader.ReadUShort();
            Candidates = new LeagueFriendInformations[candidatesCount];
            for (var candidatesIndex = 0; candidatesIndex < candidatesCount; candidatesIndex++)
            {
                var objectToAdd = new LeagueFriendInformations();
                objectToAdd.Deserialize(reader);
                Candidates[candidatesIndex] = objectToAdd;
            }
        }
    }
}