using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class EmotePlayMessage : EmotePlayAbstractMessage
    {
        public new const uint Id = 5683;

        public EmotePlayMessage(byte emoteId, double emoteStartTime, double actorId, int accountId)
        {
            EmoteId = emoteId;
            EmoteStartTime = emoteStartTime;
            ActorId = actorId;
            AccountId = accountId;
        }

        public EmotePlayMessage()
        {
        }

        public override uint MessageId => Id;

        public double ActorId { get; set; }
        public int AccountId { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteDouble(ActorId);
            writer.WriteInt(AccountId);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            ActorId = reader.ReadDouble();
            AccountId = reader.ReadInt();
        }
    }
}