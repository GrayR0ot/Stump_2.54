using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Types
{
    [Serializable]
    public class FightTemporaryBoostStateEffect : FightTemporaryBoostEffect
    {
        public new const short Id = 214;

        public FightTemporaryBoostStateEffect(uint uid, double targetId, short turnDuration, sbyte dispelable,
            ushort spellId, uint effectId, uint parentBoostUid, short delta, short stateId)
        {
            Uid = uid;
            TargetId = targetId;
            TurnDuration = turnDuration;
            Dispelable = dispelable;
            SpellId = spellId;
            EffectId = effectId;
            ParentBoostUid = parentBoostUid;
            Delta = delta;
            StateId = stateId;
        }

        public FightTemporaryBoostStateEffect()
        {
        }

        public override short TypeId => Id;

        public short StateId { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteShort(StateId);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            StateId = reader.ReadShort();
        }
    }
}