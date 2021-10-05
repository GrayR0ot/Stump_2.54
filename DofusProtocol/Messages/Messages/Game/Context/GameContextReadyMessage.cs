using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class GameContextReadyMessage : Message
    {
        public const uint Id = 6071;

        public GameContextReadyMessage(double mapId)
        {
            MapId = mapId;
        }

        public GameContextReadyMessage()
        {
        }

        public override uint MessageId => Id;

        public double MapId { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteDouble(MapId);
        }

        public override void Deserialize(IDataReader reader)
        {
            MapId = reader.ReadDouble();
        }
    }
}