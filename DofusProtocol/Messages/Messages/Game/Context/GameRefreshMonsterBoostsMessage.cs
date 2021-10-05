using System;
using System.Linq;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class GameRefreshMonsterBoostsMessage : Message
    {
        public const uint Id = 6618;

        public GameRefreshMonsterBoostsMessage(MonsterBoosts[] monsterBoosts, MonsterBoosts[] familyBoosts)
        {
            MonsterBoosts = monsterBoosts;
            FamilyBoosts = familyBoosts;
        }

        public GameRefreshMonsterBoostsMessage()
        {
        }

        public override uint MessageId => Id;

        public MonsterBoosts[] MonsterBoosts { get; set; }
        public MonsterBoosts[] FamilyBoosts { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort((short) MonsterBoosts.Count());
            for (var monsterBoostsIndex = 0; monsterBoostsIndex < MonsterBoosts.Count(); monsterBoostsIndex++)
            {
                var objectToSend = MonsterBoosts[monsterBoostsIndex];
                objectToSend.Serialize(writer);
            }

            writer.WriteShort((short) FamilyBoosts.Count());
            for (var familyBoostsIndex = 0; familyBoostsIndex < FamilyBoosts.Count(); familyBoostsIndex++)
            {
                var objectToSend = FamilyBoosts[familyBoostsIndex];
                objectToSend.Serialize(writer);
            }
        }

        public override void Deserialize(IDataReader reader)
        {
            var monsterBoostsCount = reader.ReadUShort();
            MonsterBoosts = new MonsterBoosts[monsterBoostsCount];
            for (var monsterBoostsIndex = 0; monsterBoostsIndex < monsterBoostsCount; monsterBoostsIndex++)
            {
                var objectToAdd = new MonsterBoosts();
                objectToAdd.Deserialize(reader);
                MonsterBoosts[monsterBoostsIndex] = objectToAdd;
            }

            var familyBoostsCount = reader.ReadUShort();
            FamilyBoosts = new MonsterBoosts[familyBoostsCount];
            for (var familyBoostsIndex = 0; familyBoostsIndex < familyBoostsCount; familyBoostsIndex++)
            {
                var objectToAdd = new MonsterBoosts();
                objectToAdd.Deserialize(reader);
                FamilyBoosts[familyBoostsIndex] = objectToAdd;
            }
        }
    }
}