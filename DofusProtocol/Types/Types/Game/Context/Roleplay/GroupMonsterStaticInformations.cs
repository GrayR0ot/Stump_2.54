using System;
using System.Linq;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Types
{
    [Serializable]
    public class GroupMonsterStaticInformations
    {
        public const short Id = 140;

        public GroupMonsterStaticInformations(MonsterInGroupLightInformations mainCreatureLightInfos,
            MonsterInGroupInformations[] underlings)
        {
            MainCreatureLightInfos = mainCreatureLightInfos;
            Underlings = underlings;
        }

        public GroupMonsterStaticInformations()
        {
        }

        public virtual short TypeId => Id;

        public MonsterInGroupLightInformations MainCreatureLightInfos { get; set; }
        public MonsterInGroupInformations[] Underlings { get; set; }

        public virtual void Serialize(IDataWriter writer)
        {
            MainCreatureLightInfos.Serialize(writer);
            writer.WriteShort((short) Underlings.Count());
            for (var underlingsIndex = 0; underlingsIndex < Underlings.Count(); underlingsIndex++)
            {
                var objectToSend = Underlings[underlingsIndex];
                objectToSend.Serialize(writer);
            }
        }

        public virtual void Deserialize(IDataReader reader)
        {
            MainCreatureLightInfos = new MonsterInGroupLightInformations();
            MainCreatureLightInfos.Deserialize(reader);
            var underlingsCount = reader.ReadUShort();
            Underlings = new MonsterInGroupInformations[underlingsCount];
            for (var underlingsIndex = 0; underlingsIndex < underlingsCount; underlingsIndex++)
            {
                var objectToAdd = new MonsterInGroupInformations();
                objectToAdd.Deserialize(reader);
                Underlings[underlingsIndex] = objectToAdd;
            }
        }
    }
}