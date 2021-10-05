using System;
using System.Linq;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class MapRunningFightDetailsMessage : Message
    {
        public const uint Id = 5751;

        public MapRunningFightDetailsMessage(ushort fightId, GameFightFighterLightInformations[] attackers,
            GameFightFighterLightInformations[] defenders)
        {
            FightId = fightId;
            Attackers = attackers;
            Defenders = defenders;
        }

        public MapRunningFightDetailsMessage()
        {
        }

        public override uint MessageId => Id;

        public ushort FightId { get; set; }
        public GameFightFighterLightInformations[] Attackers { get; set; }
        public GameFightFighterLightInformations[] Defenders { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUShort(FightId);
            writer.WriteShort((short) Attackers.Count());
            for (var attackersIndex = 0; attackersIndex < Attackers.Count(); attackersIndex++)
            {
                var objectToSend = Attackers[attackersIndex];
                writer.WriteShort(objectToSend.TypeId);
                objectToSend.Serialize(writer);
            }

            writer.WriteShort((short) Defenders.Count());
            for (var defendersIndex = 0; defendersIndex < Defenders.Count(); defendersIndex++)
            {
                var objectToSend = Defenders[defendersIndex];
                writer.WriteShort(objectToSend.TypeId);
                objectToSend.Serialize(writer);
            }
        }

        public override void Deserialize(IDataReader reader)
        {
            FightId = reader.ReadVarUShort();
            var attackersCount = reader.ReadUShort();
            Attackers = new GameFightFighterLightInformations[attackersCount];
            for (var attackersIndex = 0; attackersIndex < attackersCount; attackersIndex++)
            {
                var objectToAdd =
                    ProtocolTypeManager.GetInstance<GameFightFighterLightInformations>(reader.ReadShort());
                objectToAdd.Deserialize(reader);
                Attackers[attackersIndex] = objectToAdd;
            }

            var defendersCount = reader.ReadUShort();
            Defenders = new GameFightFighterLightInformations[defendersCount];
            for (var defendersIndex = 0; defendersIndex < defendersCount; defendersIndex++)
            {
                var objectToAdd =
                    ProtocolTypeManager.GetInstance<GameFightFighterLightInformations>(reader.ReadShort());
                objectToAdd.Deserialize(reader);
                Defenders[defendersIndex] = objectToAdd;
            }
        }
    }
}