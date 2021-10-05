using System;
using System.Collections.Generic;
using System.Linq;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class MapComplementaryInformationsBreachMessage : MapComplementaryInformationsDataMessage
    {
        public new const uint Id = 6791;

        public MapComplementaryInformationsBreachMessage(ushort subAreaId, double mapId, HouseInformations[] houses,
            GameRolePlayActorInformations[] actors, InteractiveElement[] interactiveElements,
            StatedElement[] statedElements, MapObstacle[] obstacles, FightCommonInformations[] fights,
            bool hasAggressiveMonsters, FightStartingPositions fightStartPositions, uint floor, sbyte room,
            BreachBranch[] branches)
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
            Floor = floor;
            Room = room;
            Branches = branches;
        }

        public MapComplementaryInformationsBreachMessage()
        {
        }

        public override uint MessageId => Id;

        public uint Floor { get; set; }
        public sbyte Room { get; set; }
        public IEnumerable<BreachBranch> Branches { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarUInt(Floor);
            writer.WriteSByte(Room);
            writer.WriteShort((short) Branches.Count());
            foreach (var objectToSend in Branches) objectToSend.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            Floor = reader.ReadVarUInt();
            Room = reader.ReadSByte();
            var branchesCount = reader.ReadUShort();
            var branches_ = new BreachBranch[branchesCount];
            for (var branchesIndex = 0; branchesIndex < branchesCount; branchesIndex++)
            {
                var objectToAdd = new BreachBranch();
                objectToAdd.Deserialize(reader);
                branches_[branchesIndex] = objectToAdd;
            }

            Branches = branches_;
        }
    }
}