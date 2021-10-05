using Stump.Server.BaseServer.Database;
using Stump.Server.WorldServer.Database.Interactives;
using Stump.Server.WorldServer.Game.Actors.RolePlay.Characters;
using Stump.Server.WorldServer.Game.Exchanges.Bank;

namespace Stump.Server.WorldServer.Game.Interactives.Skills
{
    [Discriminator("HavenbagChest", typeof(Skill), typeof(int), typeof(InteractiveCustomSkillRecord),
        typeof(InteractiveObject))]
    public class HavenbagChestSkill : CustomSkill
    {
        public HavenbagChestSkill(int id, InteractiveCustomSkillRecord skillTemplate,
            InteractiveObject interactiveObject)
            : base(id, skillTemplate, interactiveObject)
        {
        }

        public override int StartExecute(Character character)
        {
            var dialog = new BankDialog(character);
            dialog.Open();

            return base.StartExecute(character);
        }
    }
}