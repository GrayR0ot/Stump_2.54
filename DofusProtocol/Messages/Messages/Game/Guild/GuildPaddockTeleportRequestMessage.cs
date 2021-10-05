using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class GuildPaddockTeleportRequestMessage : Message
    {
        public const uint Id = 5957;

        public GuildPaddockTeleportRequestMessage(double paddockId)
        {
            PaddockId = paddockId;
        }

        public GuildPaddockTeleportRequestMessage()
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