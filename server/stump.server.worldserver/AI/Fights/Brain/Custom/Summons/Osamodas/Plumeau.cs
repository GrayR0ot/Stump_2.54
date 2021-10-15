using System.Linq;
using Stump.DofusProtocol.Enums;
using Stump.Server.WorldServer.Game.Actors.Fight;
using Stump.Server.WorldServer.Game.Effects;
using Stump.Server.WorldServer.Game.Effects.Handlers.Spells.Damage;
using Stump.Server.WorldServer.Game.Effects.Instances;
using Stump.Server.WorldServer.Game.Fights;
using Stump.Server.WorldServer.Game.Fights.Buffs;

namespace Stump.Server.WorldServer.Game.Spells.Casts.Osamodas
{
    [SpellCastHandler(SpellIdEnum.DUSTER_33)]
    public class Plumeau : DefaultSpellCastHandler
    {
        public Plumeau(SpellCastInformations cast)
            : base(cast)
        {
        }

        public override void Execute()
        {
            var fighter = Fight.GetOneFighter(TargetedCell);
            {
                var monsters = Fight.GetAllFighters<SummonedMonster>(x => x.Position.Point.IsInMap());
                var amountOfTofu = 0;
                foreach (var entry in monsters)
                    switch (entry.Monster.Template.Id)
                    {
                        case 5131:
                        case 4561:
                        case 4562:
                            amountOfTofu++;
                            if (entry.IsDead()) amountOfTofu--;
                            break;
                    }

                if (amountOfTofu == 1)
                {
                    var target = Fight.GetOneFighter(TargetedCell);

                    var buff = target.GetBuffs().Where(x => x.Dice.Id == 98).FirstOrDefault();
                    if (buff != null)
                        target.RemoveBuff(buff);

                    var effect = new EffectDice(EffectsEnum.Effect_98, 0, 32, 34);
                    if (Critical) effect = new EffectDice(EffectsEnum.Effect_98, 0, 42, 44);
                    var actorBuffId = Caster.PopNextBuffId();
                    var handler =
                        EffectManager.Instance.GetSpellEffectHandler(effect, Caster, this, TargetedCell, Critical);

                    var buff2 = new DirectDamage(effect, Caster, this, TargetedCell, false);
                    buff2.Apply();
                }
                else if (amountOfTofu == 2)
                {
                    var target = Fight.GetOneFighter(TargetedCell);

                    var buff = target.GetBuffs().Where(x => x.Dice.Id == 98).FirstOrDefault();
                    if (buff != null)
                        target.RemoveBuff(buff);

                    var effect = new EffectDice(EffectsEnum.Effect_98, 0, 37, 39);
                    if (Critical) effect = new EffectDice(EffectsEnum.Effect_98, 0, 47, 49);
                    var actorBuffId = Caster.PopNextBuffId();
                    var handler =
                        EffectManager.Instance.GetSpellEffectHandler(effect, Caster, this, TargetedCell, Critical);

                    var buff2 = new DirectDamage(effect, Caster, this, TargetedCell, false);
                    buff2.Apply();
                }
                else if (amountOfTofu >= 3)
                {
                    var target = Fight.GetOneFighter(TargetedCell);

                    var buff = target.GetBuffs().Where(x => x.Dice.Id == 98).FirstOrDefault();
                    if (buff != null)
                        target.RemoveBuff(buff);

                    var effect = new EffectDice(EffectsEnum.Effect_98, 0, 42, 44);
                    if (Critical) effect = new EffectDice(EffectsEnum.Effect_98, 0, 52, 54);
                    var actorBuffId = Caster.PopNextBuffId();
                    var handler =
                        EffectManager.Instance.GetSpellEffectHandler(effect, Caster, this, TargetedCell, Critical);

                    var buff2 = new DirectDamage(effect, Caster, this, TargetedCell, false);
                    buff2.Apply();
                }
                else
                {
                    Handlers[0].AddTriggerBuff(fighter, BuffTriggerType.Instant, PlumeauSpell);
                }
            }
        }

        public void PlumeauSpell(TriggerBuff buff, FightActor trigerrer, BuffTriggerType trigger, object token)
        {
            Handlers[0].Apply();
        }
    }
}