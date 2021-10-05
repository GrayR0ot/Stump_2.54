using Stump.DofusProtocol.Enums;
using Stump.Server.WorldServer.Game.Actors.Fight;
using Stump.Server.WorldServer.Game.Fights;
using Stump.Server.WorldServer.Game.Fights.Buffs;
using System.Collections.Generic;
using System.Linq;

namespace Stump.Server.WorldServer.Game.Spells.Casts.Ecaflip
{
    [SpellCastHandler(5972)]
    public class RazofSpell : DefaultSpellCastHandler
    {
        public RazofSpell(SpellCastInformations cast)
            : base(cast)
        {
        }

        public override void Execute()
        {

            Handlers[0].DefaultDispellableStatus = FightDispellableEnum.NOT_DISPELLABLE;
            Handlers[1].DefaultDispellableStatus = FightDispellableEnum.NOT_DISPELLABLE;
            Handlers[0].AddTriggerBuff(Caster, BuffTriggerType.OnDamaged, Razof);
            Handlers[1].AddTriggerBuff(Caster, BuffTriggerType.OnTurnBegin, Razof);

        }

        private void Razof(TriggerBuff buff, FightActor trigerrer, BuffTriggerType trigger, object token)
        {
            IEnumerable<SummonedMonster> monsters =
                Fight.GetAllFighters<SummonedMonster>(x => x.Position.Point.IsInMap());

            if (monsters.Count() >= 2)
            {
                if ((Caster as MonsterFighter).Monster.Template.Id == 4803)
                    Handlers[0].Apply();
            }
            if (monsters.Count() < 2)
            {
                if ((Caster as MonsterFighter).Monster.Template.Id == 4803)
                    Handlers[1].Apply();
            }

        }
    }
}
