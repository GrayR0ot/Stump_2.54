using System;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class SetCharacterRestrictionsMessage : Message
    {
        public const uint Id = 170;

        public SetCharacterRestrictionsMessage(double actorId, ActorRestrictionsInformations restrictions)
        {
            ActorId = actorId;
            Restrictions = restrictions;
        }

        public SetCharacterRestrictionsMessage()
        {
        }

        public override uint MessageId => Id;

        public double ActorId { get; set; }
        public ActorRestrictionsInformations Restrictions { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteDouble(ActorId);
            Restrictions.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            ActorId = reader.ReadDouble();
            Restrictions = new ActorRestrictionsInformations();
            Restrictions.Deserialize(reader);
        }
    }
}