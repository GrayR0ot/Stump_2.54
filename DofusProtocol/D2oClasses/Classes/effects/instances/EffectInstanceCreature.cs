using System;
using Stump.DofusProtocol.D2oClasses.Tools.D2o;

namespace Stump.DofusProtocol.D2oClasses
{
    [D2OClass("EffectInstanceCreature", "com.ankamagames.dofus.datacenter.effects.instances")]
    [Serializable]
    public class EffectInstanceCreature : EffectInstance
    {
        public uint monsterFamilyId;

        [D2OIgnore]
        public uint MonsterFamilyId
        {
            get => monsterFamilyId;
            set => monsterFamilyId = value;
        }
    }
}