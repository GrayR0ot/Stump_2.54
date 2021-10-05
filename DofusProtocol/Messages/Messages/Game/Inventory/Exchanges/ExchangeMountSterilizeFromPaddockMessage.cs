using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class ExchangeMountSterilizeFromPaddockMessage : Message
    {
        public const uint Id = 6056;

        public ExchangeMountSterilizeFromPaddockMessage(string name, short worldX, short worldY, string sterilizator)
        {
            Name = name;
            WorldX = worldX;
            WorldY = worldY;
            Sterilizator = sterilizator;
        }

        public ExchangeMountSterilizeFromPaddockMessage()
        {
        }

        public override uint MessageId => Id;

        public string Name { get; set; }
        public short WorldX { get; set; }
        public short WorldY { get; set; }
        public string Sterilizator { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteUTF(Name);
            writer.WriteShort(WorldX);
            writer.WriteShort(WorldY);
            writer.WriteUTF(Sterilizator);
        }

        public override void Deserialize(IDataReader reader)
        {
            Name = reader.ReadUTF();
            WorldX = reader.ReadShort();
            WorldY = reader.ReadShort();
            Sterilizator = reader.ReadUTF();
        }
    }
}