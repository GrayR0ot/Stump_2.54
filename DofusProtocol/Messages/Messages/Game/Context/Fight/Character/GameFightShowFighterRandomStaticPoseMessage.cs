using System;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class GameFightShowFighterRandomStaticPoseMessage : GameFightShowFighterMessage
    {
        public new const uint Id = 6218;

        public GameFightShowFighterRandomStaticPoseMessage(GameFightFighterInformations informations)
        {
            Informations = informations;
        }

        public GameFightShowFighterRandomStaticPoseMessage()
        {
        }

        public override uint MessageId => Id;

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
        }
    }
}