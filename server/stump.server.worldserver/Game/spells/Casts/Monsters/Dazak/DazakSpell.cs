using Stump.DofusProtocol.Enums;
using Stump.Server.WorldServer.Game.Actors.Fight;
using Stump.Server.WorldServer.Game.Fights;
using Stump.Server.WorldServer.Game.Fights.Buffs;

namespace Stump.Server.WorldServer.Game.Spells.Casts.Ecaflip
{
    [SpellCastHandler(10336)]
    public class DazakSpell : DefaultSpellCastHandler
    {
        public DazakSpell(SpellCastInformations cast)
            : base(cast)
        {
        }

        public override void Execute()
        {
            Handlers[0].DefaultDispellableStatus = FightDispellableEnum.NOT_DISPELLABLE;
            var caster = this.Caster;
            if ((caster as MonsterFighter).Monster.Template.Id == 5319)
            {
                Handlers[0].AddTriggerBuff(caster, BuffTriggerType.OnPushed, Dazak);
            }
        }

        public void Dazak(TriggerBuff buff, FightActor trigerrer, BuffTriggerType trigger, object token)
        {
            Handlers[0].Apply();
        }
    }
}
