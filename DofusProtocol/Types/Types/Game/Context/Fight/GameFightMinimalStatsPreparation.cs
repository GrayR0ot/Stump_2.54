using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Types
{
    [Serializable]
    public class GameFightMinimalStatsPreparation : GameFightMinimalStats
    {
        public new const short Id = 360;

        public GameFightMinimalStatsPreparation(uint lifePoints, uint maxLifePoints, uint baseMaxLifePoints,
            uint permanentDamagePercent, uint shieldPoints, short actionPoints, short maxActionPoints,
            short movementPoints, short maxMovementPoints, double summoner, bool summoned,
            short neutralElementResistPercent, short earthElementResistPercent, short waterElementResistPercent,
            short airElementResistPercent, short fireElementResistPercent, short neutralElementReduction,
            short earthElementReduction, short waterElementReduction, short airElementReduction,
            short fireElementReduction, short criticalDamageFixedResist, short pushDamageFixedResist,
            short pvpNeutralElementResistPercent, short pvpEarthElementResistPercent,
            short pvpWaterElementResistPercent, short pvpAirElementResistPercent, short pvpFireElementResistPercent,
            short pvpNeutralElementReduction, short pvpEarthElementReduction, short pvpWaterElementReduction,
            short pvpAirElementReduction, short pvpFireElementReduction, ushort dodgePALostProbability,
            ushort dodgePMLostProbability, short tackleBlock, short tackleEvade, short fixedDamageReflection,
            sbyte invisibilityState, ushort meleeDamageReceivedPercent, ushort rangedDamageReceivedPercent,
            ushort weaponDamageReceivedPercent, ushort spellDamageReceivedPercent, uint initiative)
        {
            LifePoints = lifePoints;
            MaxLifePoints = maxLifePoints;
            BaseMaxLifePoints = baseMaxLifePoints;
            PermanentDamagePercent = permanentDamagePercent;
            ShieldPoints = shieldPoints;
            ActionPoints = actionPoints;
            MaxActionPoints = maxActionPoints;
            MovementPoints = movementPoints;
            MaxMovementPoints = maxMovementPoints;
            Summoner = summoner;
            Summoned = summoned;
            NeutralElementResistPercent = neutralElementResistPercent;
            EarthElementResistPercent = earthElementResistPercent;
            WaterElementResistPercent = waterElementResistPercent;
            AirElementResistPercent = airElementResistPercent;
            FireElementResistPercent = fireElementResistPercent;
            NeutralElementReduction = neutralElementReduction;
            EarthElementReduction = earthElementReduction;
            WaterElementReduction = waterElementReduction;
            AirElementReduction = airElementReduction;
            FireElementReduction = fireElementReduction;
            CriticalDamageFixedResist = criticalDamageFixedResist;
            PushDamageFixedResist = pushDamageFixedResist;
            PvpNeutralElementResistPercent = pvpNeutralElementResistPercent;
            PvpEarthElementResistPercent = pvpEarthElementResistPercent;
            PvpWaterElementResistPercent = pvpWaterElementResistPercent;
            PvpAirElementResistPercent = pvpAirElementResistPercent;
            PvpFireElementResistPercent = pvpFireElementResistPercent;
            PvpNeutralElementReduction = pvpNeutralElementReduction;
            PvpEarthElementReduction = pvpEarthElementReduction;
            PvpWaterElementReduction = pvpWaterElementReduction;
            PvpAirElementReduction = pvpAirElementReduction;
            PvpFireElementReduction = pvpFireElementReduction;
            DodgePALostProbability = dodgePALostProbability;
            DodgePMLostProbability = dodgePMLostProbability;
            TackleBlock = tackleBlock;
            TackleEvade = tackleEvade;
            FixedDamageReflection = fixedDamageReflection;
            InvisibilityState = invisibilityState;
            MeleeDamageReceivedPercent = meleeDamageReceivedPercent;
            RangedDamageReceivedPercent = rangedDamageReceivedPercent;
            WeaponDamageReceivedPercent = weaponDamageReceivedPercent;
            SpellDamageReceivedPercent = spellDamageReceivedPercent;
            Initiative = initiative;
        }

        public GameFightMinimalStatsPreparation()
        {
        }

        public override short TypeId => Id;

        public uint Initiative { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarUInt(Initiative);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            Initiative = reader.ReadVarUInt();
        }
    }
}