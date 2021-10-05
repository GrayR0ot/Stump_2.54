using System;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class MapFightStartPositionsUpdateMessage : Message
    {
        public const uint Id = 6716;

        public MapFightStartPositionsUpdateMessage(double mapId, FightStartingPositions fightStartPositions)
        {
            MapId = mapId;
            FightStartPositions = fightStartPositions;
        }

        public MapFightStartPositionsUpdateMessage()
        {
        }

        public override uint MessageId => Id;

        public double MapId { get; set; }
        public FightStartingPositions FightStartPositions { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteDouble(MapId);
            FightStartPositions.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            MapId = reader.ReadDouble();
            FightStartPositions = new FightStartingPositions();
            FightStartPositions.Deserialize(reader);
        }
    }
}