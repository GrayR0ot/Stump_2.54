using System.Drawing;
using Stump.DofusProtocol.Enums;
using Stump.Server.WorldServer.Game.Actors.Fight;
using Stump.Server.WorldServer.Game.Fights;
using Stump.Server.WorldServer.Game.Fights.Buffs;
using Stump.Server.WorldServer.Game.Spells.Casts;

namespace Stump.Server.WorldServer.AI.Fights.Brain.Custom.Summons
{
    [BrainIdentifier((int) MonsterIdEnum.LEVITROF)]
    public class Levitrof : Brain
    {
        public Levitrof(AIFighter fighter)
            : base(fighter)
        {
            fighter.DamageInflicted += OnDamageInflicted;
            fighter.SpellCasted += OnSpellCasted;
        }

        private void OnSpellCasted(FightActor caster, SpellCastHandler castHandler)
        {
            if (castHandler.Spell.Template.Id == 4521)
            {
                var target = caster.Fight.GetOneFighter(castHandler.TargetedCell);
                target.Look.AddColor(0, Color.YellowGreen);
                target.Look.AddColor(1, Color.YellowGreen);
                target.Look.AddColor(2, Color.YellowGreen);
                target.Look.AddColor(3, Color.YellowGreen);
                target.Look.AddColor(4, Color.YellowGreen);
                target.Look.AddColor(5, Color.YellowGreen);
            }
        }

        private void OnDamageInflicted(FightActor fighter, Damage dmg)
        {
            if (fighter == dmg.Source)
                return;
            var player = dmg.Source;
            Buff buff = null;
            foreach (var effect in player.GetBuffs())
                if (effect.Effect.Id == 141)
                    if (effect.Caster == Fighter)
                    {
                        Fighter.Telefrag(Fighter, player);
                        buff = effect;
                        if (player is CharacterFighter)
                        {
                            var characterFighter = player as CharacterFighter;
                            characterFighter.Look = characterFighter.OriginalLook;
                            characterFighter.UpdateLook();
                        }
                    }

            if (buff != null) player.RemoveBuff(buff);
        }
    }
}