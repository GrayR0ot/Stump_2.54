using System;
using System.Linq;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class GameRolePlayShowMultipleActorsMessage : Message
    {
        public const uint Id = 6712;

        public GameRolePlayShowMultipleActorsMessage(GameRolePlayActorInformations[] informationsList)
        {
            InformationsList = informationsList;
        }

        public GameRolePlayShowMultipleActorsMessage()
        {
        }

        public override uint MessageId => Id;

        public GameRolePlayActorInformations[] InformationsList { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort((short) InformationsList.Count());
            for (var informationsListIndex = 0;
                informationsListIndex < InformationsList.Count();
                informationsListIndex++)
            {
                var objectToSend = InformationsList[informationsListIndex];
                writer.WriteShort(objectToSend.TypeId);
                objectToSend.Serialize(writer);
            }
        }

        public override void Deserialize(IDataReader reader)
        {
            var informationsListCount = reader.ReadUShort();
            InformationsList = new GameRolePlayActorInformations[informationsListCount];
            for (var informationsListIndex = 0; informationsListIndex < informationsListCount; informationsListIndex++)
            {
                var objectToAdd = ProtocolTypeManager.GetInstance<GameRolePlayActorInformations>(reader.ReadShort());
                objectToAdd.Deserialize(reader);
                InformationsList[informationsListIndex] = objectToAdd;
            }
        }
    }
}