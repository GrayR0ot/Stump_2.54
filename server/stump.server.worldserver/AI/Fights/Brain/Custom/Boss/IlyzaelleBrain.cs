using Stump.DofusProtocol.Enums;
using Stump.Server.WorldServer.Game.Actors.Fight;
using Stump.Server.WorldServer.Game.Fights;
using Stump.Server.WorldServer.Game.Spells;

namespace Stump.Server.WorldServer.AI.Fights.Brain.Custom.Boss
{
    [BrainIdentifier((int) MonsterIdEnum.ILYZAELLE)]
    public class IlyzaelleBrain : Brain
    {
        public IlyzaelleBrain(AIFighter fighter)
            : base(fighter)
        {
            fighter.Fight.FightStarted += Fight_FightStarted;
        }

        private void Fight_FightStarted(IFight obj)
        {
            Fighter.Stats[PlayerFields.SummonLimit].Additional = 9999;
            Fighter.Stats[PlayerFields.CriticalDamageReduction].Additional = 250;
            Fighter.CastAutoSpell(new Spell((int) SpellIdEnum.POSSESSION, 1), Fighter.Cell);
        }
    }
}