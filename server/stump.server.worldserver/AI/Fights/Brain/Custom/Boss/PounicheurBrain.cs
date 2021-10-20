using System.Linq;
using Stump.DofusProtocol.Enums;
using Stump.Server.WorldServer.Game.Actors.Fight;
using Stump.Server.WorldServer.Game.Spells;

namespace Stump.Server.WorldServer.AI.Fights.Brain.Custom.Boss
{
    [BrainIdentifier((int) MonsterIdEnum.POUNICHEUR)]
    public class PounicheurBrain : Brain
    {
        public PounicheurBrain(AIFighter fighter)
            : base(fighter)
        {
            fighter.GetAlive += OnGetAlive;
        }

        private void OnGetAlive(FightActor fighter)
        {
            Fighter.Stats.Fields.FirstOrDefault(x => x.Key == PlayerFields.SummonLimit).Value.Base = 3;
            Fighter.CastAutoSpell(new Spell((int) SpellIdEnum.POUGENITURE_6278, 1), Fighter.Cell);
        }
    }
}