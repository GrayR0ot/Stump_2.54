using Stump.Server.WorldServer.Game.Actors.Fight;
using Stump.Server.WorldServer.Game.Fights;
using Stump.Server.WorldServer.Game.Fights.Buffs;

namespace Stump.Server.WorldServer.Game.Spells.Casts.Ecaflip
{
    [SpellCastHandler(10347)]
    public class DazakPM : DefaultSpellCastHandler
    {
        public DazakPM(SpellCastInformations cast)
            : base(cast)
        {
        }

        public override void Execute()
        {
            foreach (MonsterFighter monster in Fight.GetAllFighters<MonsterFighter>())
                if ((monster as MonsterFighter).Monster.Template.Id == 5319)
                {
                    Handlers[0].AddTriggerBuff(monster, BuffTriggerType.OnMoved, Dazak);
                }
        }

        public void Dazak(TriggerBuff buff, FightActor trigerrer, BuffTriggerType trigger, object token)
        {
            Handlers[0].Apply();
        }
    }
}
