using System;
using System.Linq;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Types
{
    [Serializable]
    public class AlternativeMonstersInGroupLightInformations
    {
        public const short Id = 394;

        public AlternativeMonstersInGroupLightInformations(int playerCount, MonsterInGroupLightInformations[] monsters)
        {
            PlayerCount = playerCount;
            Monsters = monsters;
        }

        public AlternativeMonstersInGroupLightInformations()
        {
        }

        public virtual short TypeId => Id;

        public int PlayerCount { get; set; }
        public MonsterInGroupLightInformations[] Monsters { get; set; }

        public virtual void Serialize(IDataWriter writer)
        {
            writer.WriteInt(PlayerCount);
            writer.WriteShort((short) Monsters.Count());
            for (var monstersIndex = 0; monstersIndex < Monsters.Count(); monstersIndex++)
            {
                var objectToSend = Monsters[monstersIndex];
                objectToSend.Serialize(writer);
            }
        }

        public virtual void Deserialize(IDataReader reader)
        {
            PlayerCount = reader.ReadInt();
            var monstersCount = reader.ReadUShort();
            Monsters = new MonsterInGroupLightInformations[monstersCount];
            for (var monstersIndex = 0; monstersIndex < monstersCount; monstersIndex++)
            {
                var objectToAdd = new MonsterInGroupLightInformations();
                objectToAdd.Deserialize(reader);
                Monsters[monstersIndex] = objectToAdd;
            }
        }
    }
}