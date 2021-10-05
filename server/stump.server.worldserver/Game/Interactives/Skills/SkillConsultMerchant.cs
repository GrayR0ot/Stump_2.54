using System.Collections.Generic;
using System.Linq;
using Stump.Server.BaseServer.Database;
using Stump.Server.WorldServer.Database.Interactives;
using Stump.Server.WorldServer.Game.Actors.RolePlay.Characters;
using Stump.Server.WorldServer.Game.Exchanges.BidHouse;

namespace Stump.Server.WorldServer.Game.Interactives.Skills
{
    [Discriminator("Consult", typeof(Skill), typeof(int), typeof(InteractiveCustomSkillRecord),
        typeof(InteractiveObject))]
    public class SkillConsultMerchant : CustomSkill
    {
        public SkillConsultMerchant(int id, InteractiveCustomSkillRecord skillTemplate,
            InteractiveObject interactiveObject)
            : base(id, skillTemplate, interactiveObject)
        {
        }

        public string Types => Record.GetParameter<string>(0);

        public IEnumerable<int> ListOfTypes => Types.Split(',').Select(int.Parse);

        public override int StartExecute(Character character)
        {
            var ad = new BidHouseExchange(character, ListOfTypes, 200, true);
            ad.Open();

            return base.StartExecute(character);
        }
    }
}