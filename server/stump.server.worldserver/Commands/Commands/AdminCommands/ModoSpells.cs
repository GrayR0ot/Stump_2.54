using Stump.DofusProtocol.Enums;
using Stump.Server.WorldServer.Commands.Commands.Patterns;
using Stump.Server.WorldServer.Commands.Trigger;

namespace Stump.Server.WorldServer.Commands.Commands
{
    public class ModoSpells : InGameCommand
    {
        public ModoSpells()
        {
            Aliases = new string[1]
            {
                "modospells"
            };
            RequiredRole = RoleEnum.Administrator;
            Description = "Ajoute des sorts de modération et des sorts utiles.";
        }

        public override void Execute(GameTrigger trigger)
        {
            {
                trigger.Character.Spells.LearnSpell(411);
                trigger.Character.Spells.LearnSpell(415);
                trigger.Character.Spells.LearnSpell(728);
                trigger.Character.Spells.BoostSpell(728, 6); //boost le level du sort
                trigger.Character.Spells.LearnSpell(350);
                trigger.Character.Spells.LearnSpell(364);
                trigger.Character.Spells.LearnSpell(214);
                trigger.Character.Spells.LearnSpell(3506);
                trigger.Character.Spells.LearnSpell(368);
                trigger.Character.Spells.LearnSpell(369);
                trigger.Character.Spells.LearnSpell(367);
                trigger.Character.Spells.LearnSpell(366);
                trigger.Character.Spells.LearnSpell(373);
                trigger.Character.Spells.LearnSpell(370);
                trigger.Character.Spells.LearnSpell(413);
                trigger.Character.Spells.LearnSpell(414);
                trigger.Character.Spells.LearnSpell(3450);
                trigger.Reply("Les sorts de modérations ont été ajoutés à votre personnage !");
            }
        }
    }
}