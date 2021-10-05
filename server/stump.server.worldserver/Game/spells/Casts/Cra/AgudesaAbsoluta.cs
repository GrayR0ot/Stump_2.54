using Stump.DofusProtocol.Enums;
using Stump.Server.WorldServer.Game.Breeds;
using Stump.Server.WorldServer.Game.Fights;
using Stump.Server.WorldServer.Game.Fights.Buffs;
using System.Linq;

namespace Stump.Server.WorldServer.Game.Spells.Casts.Ocra
{
    [SpellCastHandler(SpellIdEnum.ABSOLUTE_ACUTENESS_9306)]
    public class AgudesaAbsoluta : DefaultSpellCastHandler
    {
        public AgudesaAbsoluta(SpellCastInformations cast) : base(cast) { }

        public override void Execute()
        {
            if (!m_initialized)
                Initialize();

            var targer = Handlers[0].GetAffectedActors().First();
            var database = BreedManager.Instance.GetBreed(9);
            foreach (var item in database.Spells)
            {
                if (item.Spell != 0)
                {
                    var boostedSpell = Caster.GetSpell(item.Spell);
                    var buff = new SpellBuff(targer.PopNextBuffId(), targer, Caster, Handlers[0], Spell, boostedSpell, 3, false, FightDispellableEnum.DISPELLABLE_BY_DEATH);
                    targer.AddBuff(buff);
                    boostedSpell.CurrentSpellLevel.CastTestLos = false;
                }

                if (item.VariantId != 0)
                {
                    var boostedSpell = Caster.GetSpell(item.VariantId);
                    var buff = new SpellBuff(targer.PopNextBuffId(), targer, Caster, Handlers[0], Spell, boostedSpell, 3, false, FightDispellableEnum.DISPELLABLE_BY_DEATH);
                    targer.AddBuff(buff);
                    boostedSpell.CurrentSpellLevel.CastTestLos = false;
                }
            }

            foreach (var handler in Handlers)
                handler.Apply();
        }
    }
}