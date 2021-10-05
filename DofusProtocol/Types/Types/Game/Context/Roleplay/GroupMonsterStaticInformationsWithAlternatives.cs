using System;
using System.Linq;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Types
{
    [Serializable]
    public class GroupMonsterStaticInformationsWithAlternatives : GroupMonsterStaticInformations
    {
        public new const short Id = 396;

        public GroupMonsterStaticInformationsWithAlternatives(MonsterInGroupLightInformations mainCreatureLightInfos,
            MonsterInGroupInformations[] underlings, AlternativeMonstersInGroupLightInformations[] alternatives)
        {
            MainCreatureLightInfos = mainCreatureLightInfos;
            Underlings = underlings;
            Alternatives = alternatives;
        }

        public GroupMonsterStaticInformationsWithAlternatives()
        {
        }

        public override short TypeId => Id;

        public AlternativeMonstersInGroupLightInformations[] Alternatives { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteShort((short) Alternatives.Count());
            for (var alternativesIndex = 0; alternativesIndex < Alternatives.Count(); alternativesIndex++)
            {
                var objectToSend = Alternatives[alternativesIndex];
                objectToSend.Serialize(writer);
            }
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            var alternativesCount = reader.ReadUShort();
            Alternatives = new AlternativeMonstersInGroupLightInformations[alternativesCount];
            for (var alternativesIndex = 0; alternativesIndex < alternativesCount; alternativesIndex++)
            {
                var objectToAdd = new AlternativeMonstersInGroupLightInformations();
                objectToAdd.Deserialize(reader);
                Alternatives[alternativesIndex] = objectToAdd;
            }
        }
    }
}