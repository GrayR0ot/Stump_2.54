using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Types
{
    [Serializable]
    public class FightTemporaryBoostWeaponDamagesEffect : FightTemporaryBoostEffect
    {
        public new const short Id = 211;

        public FightTemporaryBoostWeaponDamagesEffect(uint uid, double targetId, short turnDuration, sbyte dispelable,
            ushort spellId, uint effectId, uint parentBoostUid, short delta, short weaponTypeId)
        {
            Uid = uid;
            TargetId = targetId;
            TurnDuration = turnDuration;
            Dispelable = dispelable;
            SpellId = spellId;
            EffectId = effectId;
            ParentBoostUid = parentBoostUid;
            Delta = delta;
            WeaponTypeId = weaponTypeId;
        }

        public FightTemporaryBoostWeaponDamagesEffect()
        {
        }

        public override short TypeId => Id;

        public short WeaponTypeId { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteShort(WeaponTypeId);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            WeaponTypeId = reader.ReadShort();
        }
    }
}