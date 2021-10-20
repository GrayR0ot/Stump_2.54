using Stump.DofusProtocol.Enums;
using Stump.Server.WorldServer.Game.Actors.Fight;
using Stump.Server.WorldServer.Game.Fights;
using Stump.Server.WorldServer.Game.Spells;

namespace Stump.Server.WorldServer.AI.Fights.Brain.Custom.Summons
{
    [BrainIdentifier((int) MonsterIdEnum.COMTE_HAREBOURG)]
    public class HarebourgBrain : Brain
    {
        public HarebourgBrain(AIFighter fighter)
            : base(fighter)
        {
            fighter.Fight.FightStarted += Fight_FightStarted;
            fighter.Fight.BeforeTurnStopped += OnTurnStopped;
        }

        private void Fight_FightStarted(IFight obj)
        {
            Fighter.CastAutoSpell(new Spell((int) SpellIdEnum.MI_TEMPS_3648, 1), Fighter.Cell);
        }

        private void OnTurnStopped(IFight obj, FightActor fightActor)
        {
        }
    }
}