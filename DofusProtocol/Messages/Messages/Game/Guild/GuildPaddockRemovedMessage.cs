using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class GuildPaddockRemovedMessage : Message
    {
        public const uint Id = 5955;

        public GuildPaddockRemovedMessage(double paddockId)
        {
            PaddockId = paddockId;
        }

        public GuildPaddockRemovedMessage()
        {
        }

        public override uint MessageId => Id;

        public double PaddockId { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteDouble(PaddockId);
        }

        public override void Deserialize(IDataReader reader)
        {
            PaddockId = reader.ReadDouble();
        }
    }
}