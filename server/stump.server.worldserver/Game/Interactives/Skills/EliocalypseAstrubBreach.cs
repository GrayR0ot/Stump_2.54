using Stump.Server.BaseServer.Database;
using Stump.Server.WorldServer.Database.Interactives;
using Stump.Server.WorldServer.Game.Actors.RolePlay.Characters;

namespace Stump.Server.WorldServer.Game.Interactives.Skills
{
    [Discriminator("EliocalypseAstrubBreach", typeof(Skill), typeof(int), typeof(InteractiveCustomSkillRecord),
        typeof(InteractiveObject))]
    public class EliocalypseAstrubBreach : CustomSkill
    {
        public EliocalypseAstrubBreach(int id, InteractiveCustomSkillRecord skillTemplate,
            InteractiveObject interactiveObject) : base(id, skillTemplate, interactiveObject)
        {
        }

        public override int StartExecute(Character character)
        {
            character.SendServerMessage("Faille pour aller aux zones eliocalypse!");

            return base.StartExecute(character);
        }
    }
}