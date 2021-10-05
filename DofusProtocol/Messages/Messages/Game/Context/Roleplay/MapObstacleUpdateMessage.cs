using System;
using System.Linq;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class MapObstacleUpdateMessage : Message
    {
        public const uint Id = 6051;

        public MapObstacleUpdateMessage(MapObstacle[] obstacles)
        {
            Obstacles = obstacles;
        }

        public MapObstacleUpdateMessage()
        {
        }

        public override uint MessageId => Id;

        public MapObstacle[] Obstacles { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort((short) Obstacles.Count());
            for (var obstaclesIndex = 0; obstaclesIndex < Obstacles.Count(); obstaclesIndex++)
            {
                var objectToSend = Obstacles[obstaclesIndex];
                objectToSend.Serialize(writer);
            }
        }

        public override void Deserialize(IDataReader reader)
        {
            var obstaclesCount = reader.ReadUShort();
            Obstacles = new MapObstacle[obstaclesCount];
            for (var obstaclesIndex = 0; obstaclesIndex < obstaclesCount; obstaclesIndex++)
            {
                var objectToAdd = new MapObstacle();
                objectToAdd.Deserialize(reader);
                Obstacles[obstaclesIndex] = objectToAdd;
            }
        }
    }
}