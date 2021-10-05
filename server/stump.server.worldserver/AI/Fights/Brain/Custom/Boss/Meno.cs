using Stump.DofusProtocol.Enums;
using Stump.Server.WorldServer.Game.Actors.Fight;
using Stump.Server.WorldServer.Game.Fights;
using Stump.Server.WorldServer.Game.Spells;
using Stump.Server.WorldServer.Game.Spells.Casts;
using System.Linq;

namespace Stump.Server.WorldServer.AI.Fights.Brain.Custom
{
    [BrainIdentifier((int)MonsterIdEnum.CAPITAINE_MENO)]
    public class Meno : Brain
    {
        public Meno(AIFighter fighter) : base(fighter)
        {
            fighter.Fight.FightStarted += Fight_FightStarted;
            fighter.SpellCasted += onSpellCasted;
        }

        private void Fight_FightStarted(IFight obj)
        {
            Fighter.Stats.Fields.FirstOrDefault(x => x.Key == PlayerFields.SummonLimit).Value.Base = 3;
            Fighter.CastAutoSpell(new Spell((int)SpellIdEnum.CALL_OF_THE_DEEP_SEA_6793, 1), Fighter.Cell);
            foreach(var entity in this.Fighter.Fight.GetAllFighters())
            {
                if(entity is MonsterFighter)
                {
                    var monster = (entity as MonsterFighter);
                    monster.Invulnerable = true;
                }
            }
        }

        private void onSpellCasted(FightActor caster, SpellCastHandler castHandler)
        {
            if (castHandler.Spell.Template.Id == 6808 || castHandler.Spell.Template.Id == 6812)
            {
                foreach (var entity in this.Fighter.Fight.GetAllFighters())
                {
                    if (entity is MonsterFighter)
                    {
                        var monster = (entity as MonsterFighter);
                        monster.Invulnerable = true;
                        if(monster.LifePoints >= 6000)
                        {
                            monster.InflictDirectDamage(1000);
                        }
                        if(monster.LifePoints < 3000)
                        {
                            monster.Die();
                        } 
                    }
                    if(entity is SummonedMonster)
                    {
                        var summonedMonster = (entity as SummonedMonster);
                        summonedMonster.Invulnerable = true;
                        if (summonedMonster.LifePoints >= 6000)
                        {
                            summonedMonster.InflictDirectDamage(1000);
                        }
                        if (summonedMonster.LifePoints < 3000)
                        {
                            summonedMonster.Die();
                        }
                    }
                }
            }
        }
    }
}
