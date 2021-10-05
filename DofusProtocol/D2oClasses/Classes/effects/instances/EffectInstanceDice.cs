using System;
using Stump.DofusProtocol.D2oClasses.Tools.D2o;

namespace Stump.DofusProtocol.D2oClasses
{
    [D2OClass("EffectInstanceDice", "com.ankamagames.dofus.datacenter.effects.instances")]
    [Serializable]
    public class EffectInstanceDice : EffectInstanceInteger
    {
        public uint diceNum;
        public uint diceSide;

        [D2OIgnore]
        public uint DiceNum
        {
            get => diceNum;
            set => diceNum = value;
        }

        [D2OIgnore]
        public uint DiceSide
        {
            get => diceSide;
            set => diceSide = value;
        }
    }
}