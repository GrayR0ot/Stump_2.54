using System;
using System.Linq;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class GameActionFightSummonMessage : AbstractGameActionMessage
    {
        public new const uint Id = 5825;

        public GameActionFightSummonMessage(ushort actionId, double sourceId, GameFightFighterInformations[] summons)
        {
            ActionId = actionId;
            SourceId = sourceId;
            Summons = summons;
        }

        public GameActionFightSummonMessage()
        {
        }

        public override uint MessageId => Id;

        public GameFightFighterInformations[] Summons { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteShort((short) Summons.Count());
            for (var summonsIndex = 0; summonsIndex < Summons.Count(); summonsIndex++)
            {
                var objectToSend = Summons[summonsIndex];
                writer.WriteShort(objectToSend.TypeId);
                objectToSend.Serialize(writer);
            }
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            var summonsCount = reader.ReadUShort();
            Summons = new GameFightFighterInformations[summonsCount];
            for (var summonsIndex = 0; summonsIndex < summonsCount; summonsIndex++)
            {
                var objectToAdd = ProtocolTypeManager.GetInstance<GameFightFighterInformations>(reader.ReadShort());
                objectToAdd.Deserialize(reader);
                Summons[summonsIndex] = objectToAdd;
            }
        }
    }
}