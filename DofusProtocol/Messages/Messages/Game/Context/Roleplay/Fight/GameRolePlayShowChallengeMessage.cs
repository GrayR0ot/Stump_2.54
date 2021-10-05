using System;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class GameRolePlayShowChallengeMessage : Message
    {
        public const uint Id = 301;

        public GameRolePlayShowChallengeMessage(FightCommonInformations commonsInfos)
        {
            CommonsInfos = commonsInfos;
        }

        public GameRolePlayShowChallengeMessage()
        {
        }

        public override uint MessageId => Id;

        public FightCommonInformations CommonsInfos { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            CommonsInfos.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            CommonsInfos = new FightCommonInformations();
            CommonsInfos.Deserialize(reader);
        }
    }
}