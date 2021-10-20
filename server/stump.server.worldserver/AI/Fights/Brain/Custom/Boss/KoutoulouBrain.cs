using Stump.DofusProtocol.Enums;
using Stump.Server.WorldServer.Game.Actors.Fight;
using Stump.Server.WorldServer.Game.Fights;
using Stump.Server.WorldServer.Game.Spells;

namespace Stump.Server.WorldServer.AI.Fights.Brain.Custom
{
    [BrainIdentifier((int) MonsterIdEnum.LARVE_DE_KOUTOULOU)]
    public class KoutoulouBrain : Brain
    {
        public KoutoulouBrain(AIFighter fighter) : base(fighter)
        {
            fighter.Fight.FightStarted += Fight_FightStarted;
        }

        private void Fight_FightStarted(IFight obj)
        {
            Fighter.CastAutoSpell(new Spell((int) SpellIdEnum.HORREUR_COSMIQUE_6749, 1), Fighter.Cell);
        }
    }
}