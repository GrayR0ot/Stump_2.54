using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class GameMapNoMovementMessage : Message
    {
        public const uint Id = 954;

        public GameMapNoMovementMessage(short cellX, short cellY)
        {
            CellX = cellX;
            CellY = cellY;
        }

        public GameMapNoMovementMessage()
        {
        }

        public override uint MessageId => Id;

        public short CellX { get; set; }
        public short CellY { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort(CellX);
            writer.WriteShort(CellY);
        }

        public override void Deserialize(IDataReader reader)
        {
            CellX = reader.ReadShort();
            CellY = reader.ReadShort();
        }
    }
}