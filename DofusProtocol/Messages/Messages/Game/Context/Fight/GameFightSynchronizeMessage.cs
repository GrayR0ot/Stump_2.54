using System;
using System.Linq;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class GameFightSynchronizeMessage : Message
    {
        public const uint Id = 5921;

        public GameFightSynchronizeMessage(GameFightFighterInformations[] fighters)
        {
            Fighters = fighters;
        }

        public GameFightSynchronizeMessage()
        {
        }

        public override uint MessageId => Id;

        public GameFightFighterInformations[] Fighters { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort((short) Fighters.Count());
            for (var fightersIndex = 0; fightersIndex < Fighters.Count(); fightersIndex++)
            {
                var objectToSend = Fighters[fightersIndex];
                writer.WriteShort(objectToSend.TypeId);
                objectToSend.Serialize(writer);
            }
        }

        public override void Deserialize(IDataReader reader)
        {
            var fightersCount = reader.ReadUShort();
            Fighters = new GameFightFighterInformations[fightersCount];
            for (var fightersIndex = 0; fightersIndex < fightersCount; fightersIndex++)
            {
                var objectToAdd = ProtocolTypeManager.GetInstance<GameFightFighterInformations>(reader.ReadShort());
                objectToAdd.Deserialize(reader);
                Fighters[fightersIndex] = objectToAdd;
            }
        }
    }
}