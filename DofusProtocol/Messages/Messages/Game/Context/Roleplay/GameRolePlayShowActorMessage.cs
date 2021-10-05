using System;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class GameRolePlayShowActorMessage : Message
    {
        public const uint Id = 5632;

        public GameRolePlayShowActorMessage(GameRolePlayActorInformations informations)
        {
            Informations = informations;
        }

        public GameRolePlayShowActorMessage()
        {
        }

        public override uint MessageId => Id;

        public GameRolePlayActorInformations Informations { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort(Informations.TypeId);
            Informations.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            Informations = ProtocolTypeManager.GetInstance<GameRolePlayActorInformations>(reader.ReadShort());
            Informations.Deserialize(reader);
        }
    }
}