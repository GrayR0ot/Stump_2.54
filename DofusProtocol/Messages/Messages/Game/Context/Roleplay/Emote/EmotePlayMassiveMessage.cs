using System;
using System.Linq;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class EmotePlayMassiveMessage : EmotePlayAbstractMessage
    {
        public new const uint Id = 5691;

        public EmotePlayMassiveMessage(byte emoteId, double emoteStartTime, double[] actorIds)
        {
            EmoteId = emoteId;
            EmoteStartTime = emoteStartTime;
            ActorIds = actorIds;
        }

        public EmotePlayMassiveMessage()
        {
        }

        public override uint MessageId => Id;

        public double[] ActorIds { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteShort((short) ActorIds.Count());
            for (var actorIdsIndex = 0; actorIdsIndex < ActorIds.Count(); actorIdsIndex++)
                writer.WriteDouble(ActorIds[actorIdsIndex]);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            var actorIdsCount = reader.ReadUShort();
            ActorIds = new double[actorIdsCount];
            for (var actorIdsIndex = 0; actorIdsIndex < actorIdsCount; actorIdsIndex++)
                ActorIds[actorIdsIndex] = reader.ReadDouble();
        }
    }
}