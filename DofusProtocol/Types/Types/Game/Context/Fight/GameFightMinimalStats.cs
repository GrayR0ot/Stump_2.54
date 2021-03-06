using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Types
{
    [Serializable]
    public class GameFightMinimalStats
    {
        public const short Id = 31;

        public GameFightMinimalStats(uint lifePoints, uint maxLifePoints, uint baseMaxLifePoints,
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
            ushort weaponDamageReceivedPercent, ushort spellDamageReceivedPercent)
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
        }

        public GameFightMinimalStats()
        {
        }

        public virtual short TypeId => Id;

        public uint LifePoints { get; set; }
        public uint MaxLifePoints { get; set; }
        public uint BaseMaxLifePoints { get; set; }
        public uint PermanentDamagePercent { get; set; }
        public uint ShieldPoints { get; set; }
        public short ActionPoints { get; set; }
        public short MaxActionPoints { get; set; }
        public short MovementPoints { get; set; }
        public short MaxMovementPoints { get; set; }
        public double Summoner { get; set; }
        public bool Summoned { get; set; }
        public short NeutralElementResistPercent { get; set; }
        public short EarthElementResistPercent { get; set; }
        public short WaterElementResistPercent { get; set; }
        public short AirElementResistPercent { get; set; }
        public short FireElementResistPercent { get; set; }
        public short NeutralElementReduction { get; set; }
        public short EarthElementReduction { get; set; }
        public short WaterElementReduction { get; set; }
        public short AirElementReduction { get; set; }
        public short FireElementReduction { get; set; }
        public short CriticalDamageFixedResist { get; set; }
        public short PushDamageFixedResist { get; set; }
        public short PvpNeutralElementResistPercent { get; set; }
        public short PvpEarthElementResistPercent { get; set; }
        public short PvpWaterElementResistPercent { get; set; }
        public short PvpAirElementResistPercent { get; set; }
        public short PvpFireElementResistPercent { get; set; }
        public short PvpNeutralElementReduction { get; set; }
        public short PvpEarthElementReduction { get; set; }
        public short PvpWaterElementReduction { get; set; }
        public short PvpAirElementReduction { get; set; }
        public short PvpFireElementReduction { get; set; }
        public ushort DodgePALostProbability { get; set; }
        public ushort DodgePMLostProbability { get; set; }
        public short TackleBlock { get; set; }
        public short TackleEvade { get; set; }
        public short FixedDamageReflection { get; set; }
        public sbyte InvisibilityState { get; set; }
        public ushort MeleeDamageReceivedPercent { get; set; }
        public ushort RangedDamageReceivedPercent { get; set; }
        public ushort WeaponDamageReceivedPercent { get; set; }
        public ushort SpellDamageReceivedPercent { get; set; }

        public virtual void Serialize(IDataWriter writer)
        {
            writer.WriteVarUInt(LifePoints);
            writer.WriteVarUInt(MaxLifePoints);
            writer.WriteVarUInt(BaseMaxLifePoints);
            writer.WriteVarUInt(PermanentDamagePercent);
            writer.WriteVarUInt(ShieldPoints);
            writer.WriteVarShort(ActionPoints);
            writer.WriteVarShort(MaxActionPoints);
            writer.WriteVarShort(MovementPoints);
            writer.WriteVarShort(MaxMovementPoints);
            writer.WriteDouble(Summoner);
            writer.WriteBoolean(Summoned);
            writer.WriteVarShort(NeutralElementResistPercent);
            writer.WriteVarShort(EarthElementResistPercent);
            writer.WriteVarShort(WaterElementResistPercent);
            writer.WriteVarShort(AirElementResistPercent);
            writer.WriteVarShort(FireElementResistPercent);
            writer.WriteVarShort(NeutralElementReduction);
            writer.WriteVarShort(EarthElementReduction);
            writer.WriteVarShort(WaterElementReduction);
            writer.WriteVarShort(AirElementReduction);
            writer.WriteVarShort(FireElementReduction);
            writer.WriteVarShort(CriticalDamageFixedResist);
            writer.WriteVarShort(PushDamageFixedResist);
            writer.WriteVarShort(PvpNeutralElementResistPercent);
            writer.WriteVarShort(PvpEarthElementResistPercent);
            writer.WriteVarShort(PvpWaterElementResistPercent);
            writer.WriteVarShort(PvpAirElementResistPercent);
            writer.WriteVarShort(PvpFireElementResistPercent);
            writer.WriteVarShort(PvpNeutralElementReduction);
            writer.WriteVarShort(PvpEarthElementReduction);
            writer.WriteVarShort(PvpWaterElementReduction);
            writer.WriteVarShort(PvpAirElementReduction);
            writer.WriteVarShort(PvpFireElementReduction);
            writer.WriteVarUShort(DodgePALostProbability);
            writer.WriteVarUShort(DodgePMLostProbability);
            writer.WriteVarShort(TackleBlock);
            writer.WriteVarShort(TackleEvade);
            writer.WriteVarShort(FixedDamageReflection);
            writer.WriteSByte(InvisibilityState);
            writer.WriteVarUShort(MeleeDamageReceivedPercent);
            writer.WriteVarUShort(RangedDamageReceivedPercent);
            writer.WriteVarUShort(WeaponDamageReceivedPercent);
            writer.WriteVarUShort(SpellDamageReceivedPercent);
        }

        public virtual void Deserialize(IDataReader reader)
        {
            LifePoints = reader.ReadVarUInt();
            MaxLifePoints = reader.ReadVarUInt();
            BaseMaxLifePoints = reader.ReadVarUInt();
            PermanentDamagePercent = reader.ReadVarUInt();
            ShieldPoints = reader.ReadVarUInt();
            ActionPoints = reader.ReadVarShort();
            MaxActionPoints = reader.ReadVarShort();
            MovementPoints = reader.ReadVarShort();
            MaxMovementPoints = reader.ReadVarShort();
            Summoner = reader.ReadDouble();
            Summoned = reader.ReadBoolean();
            NeutralElementResistPercent = reader.ReadVarShort();
            EarthElementResistPercent = reader.ReadVarShort();
            WaterElementResistPercent = reader.ReadVarShort();
            AirElementResistPercent = reader.ReadVarShort();
            FireElementResistPercent = reader.ReadVarShort();
            NeutralElementReduction = reader.ReadVarShort();
            EarthElementReduction = reader.ReadVarShort();
            WaterElementReduction = reader.ReadVarShort();
            AirElementReduction = reader.ReadVarShort();
            FireElementReduction = reader.ReadVarShort();
            CriticalDamageFixedResist = reader.ReadVarShort();
            PushDamageFixedResist = reader.ReadVarShort();
            PvpNeutralElementResistPercent = reader.ReadVarShort();
            PvpEarthElementResistPercent = reader.ReadVarShort();
            PvpWaterElementResistPercent = reader.ReadVarShort();
            PvpAirElementResistPercent = reader.ReadVarShort();
            PvpFireElementResistPercent = reader.ReadVarShort();
            PvpNeutralElementReduction = reader.ReadVarShort();
            PvpEarthElementReduction = reader.ReadVarShort();
            PvpWaterElementReduction = reader.ReadVarShort();
            PvpAirElementReduction = reader.ReadVarShort();
            PvpFireElementReduction = reader.ReadVarShort();
            DodgePALostProbability = reader.ReadVarUShort();
            DodgePMLostProbability = reader.ReadVarUShort();
            TackleBlock = reader.ReadVarShort();
            TackleEvade = reader.ReadVarShort();
            FixedDamageReflection = reader.ReadVarShort();
            InvisibilityState = reader.ReadSByte();
            MeleeDamageReceivedPercent = reader.ReadVarUShort();
            RangedDamageReceivedPercent = reader.ReadVarUShort();
            WeaponDamageReceivedPercent = reader.ReadVarUShort();
            SpellDamageReceivedPercent = reader.ReadVarUShort();
        }
    }
}