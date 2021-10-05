using System;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class MapComplementaryInformationsAnomalyMessage : MapComplementaryInformationsDataMessage
    {
        public new const uint Id = 6828;

        public MapComplementaryInformationsAnomalyMessage(ushort subAreaId, double mapId, HouseInformations[] houses,
            GameRolePlayActorInformations[] actors, InteractiveElement[] interactiveElements,
            StatedElement[] statedElements, MapObstacle[] obstacles, FightCommonInformations[] fights,
            bool hasAggressiveMonsters, FightStartingPositions fightStartPositions, ushort level, ulong closingTime)
        {
            SubAreaId = subAreaId;
            MapId = mapId;
            Houses = houses;
            Actors = actors;
            InteractiveElements = interactiveElements;
            StatedElements = statedElements;
            Obstacles = obstacles;
            Fights = fights;
            HasAggressiveMonsters = hasAggressiveMonsters;
            FightStartPositions = fightStartPositions;
            Level = level;
            ClosingTime = closingTime;
        }

        public MapComplementaryInformationsAnomalyMessage()
        {
        }

        public override uint MessageId => Id;

        public ushort Level { get; set; }
        public ulong ClosingTime { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarUShort(Level);
            writer.WriteVarULong(ClosingTime);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            Level = reader.ReadVarUShort();
            ClosingTime = reader.ReadVarULong();
        }
    }
}