using Stump.DofusProtocol.Enums;
using Stump.Server.WorldServer.Game.Actors.Fight;
using Stump.Server.WorldServer.Game.Fights;
using Stump.Server.WorldServer.Game.Spells;

namespace Stump.Server.WorldServer.AI.Fights.Brain.Custom
{
    [BrainIdentifier((int)MonsterIdEnum.PHOSSILE)]
    public class PhossileBrain : Brain
    {
        public PhossileBrain(AIFighter fighter) : base(fighter)
        {
            fighter.Fight.FightStarted += Fight_FightStarted;
            fighter.Fight.TurnStarted += OnTurnStarted;
        }

        private void Fight_FightStarted(IFight obj)
        {

            Fighter.CastAutoSpell(new Spell((int)SpellIdEnum.DRHELL_FOR_GLORY_4497, 1), Fighter.Cell);
        }
        private void OnTurnStarted(IFight obj, FightActor actor)
        {

        }
    }
}
