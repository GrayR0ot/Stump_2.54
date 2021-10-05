using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class LifePointsRegenBeginMessage : Message
    {
        public const uint Id = 5684;

        public LifePointsRegenBeginMessage(byte regenRate)
        {
            RegenRate = regenRate;
        }

        public LifePointsRegenBeginMessage()
        {
        }

        public override uint MessageId => Id;

        public byte RegenRate { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteByte(RegenRate);
        }

        public override void Deserialize(IDataReader reader)
        {
            RegenRate = reader.ReadByte();
        }
    }
}