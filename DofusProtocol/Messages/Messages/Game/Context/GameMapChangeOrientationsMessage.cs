using System;
using System.Linq;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class GameMapChangeOrientationsMessage : Message
    {
        public const uint Id = 6155;

        public GameMapChangeOrientationsMessage(ActorOrientation[] orientations)
        {
            Orientations = orientations;
        }

        public GameMapChangeOrientationsMessage()
        {
        }

        public override uint MessageId => Id;

        public ActorOrientation[] Orientations { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort((short) Orientations.Count());
            for (var orientationsIndex = 0; orientationsIndex < Orientations.Count(); orientationsIndex++)
            {
                var objectToSend = Orientations[orientationsIndex];
                objectToSend.Serialize(writer);
            }
        }

        public override void Deserialize(IDataReader reader)
        {
            var orientationsCount = reader.ReadUShort();
            Orientations = new ActorOrientation[orientationsCount];
            for (var orientationsIndex = 0; orientationsIndex < orientationsCount; orientationsIndex++)
            {
                var objectToAdd = new ActorOrientation();
                objectToAdd.Deserialize(reader);
                Orientations[orientationsIndex] = objectToAdd;
            }
        }
    }
}