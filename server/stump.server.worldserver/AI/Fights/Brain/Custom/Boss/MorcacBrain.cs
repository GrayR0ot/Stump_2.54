using Stump.DofusProtocol.Enums;
using Stump.Server.WorldServer.Game.Actors.Fight;
using Stump.Server.WorldServer.Game.Spells;

namespace Stump.Server.WorldServer.AI.Fights.Brain.Custom.Boss
{
    [BrainIdentifier((int) MonsterIdEnum.MORCAC)]
    public class MorcacBrain : Brain
    {
        public MorcacBrain(AIFighter fighter)
            : base(fighter)
        {
            fighter.GetAlive += OnGetAlive;
        }

        private void OnGetAlive(FightActor fighter)
        {
            Fighter.CastAutoSpell(new Spell((int) SpellIdEnum.MORZERK_6346, 1), Fighter.Cell);
        }
    }
}