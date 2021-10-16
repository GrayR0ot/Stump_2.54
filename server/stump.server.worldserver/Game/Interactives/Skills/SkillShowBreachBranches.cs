using Stump.Server.BaseServer.Database;
using Stump.Server.WorldServer.Database.Interactives;
using Stump.Server.WorldServer.Game.Actors.RolePlay.Characters;
using Stump.Server.WorldServer.Game.Songes;

namespace Stump.Server.WorldServer.Game.Interactives.Skills
{
    [Discriminator("ShowBreachBranches", typeof(Skill), typeof(int), typeof(InteractiveCustomSkillRecord),
        typeof(InteractiveObject))]
    public class SkillShowBreachBranches : CustomSkill
    {
        public SkillShowBreachBranches(int id, InteractiveCustomSkillRecord skillTemplate,
            InteractiveObject interactiveObject) : base(id, skillTemplate, interactiveObject)
        {
        }

        public override int StartExecute(Character character)
        {
            if (character.breachOwner == null) new BreachBranchesGUI(character).Open();
            return base.StartExecute(character);
        }
    }
}