using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using Stump.Core.Extensions;
using Stump.Server.BaseServer.Database;
using Stump.Server.WorldServer.Database.Interactives;
using Stump.Server.WorldServer.Game.Actors.RolePlay.Characters;
using Stump.Server.WorldServer.Game.Items;

namespace Stump.Server.WorldServer.Game.Interactives.Skills
{
    [Discriminator("Loterie", typeof(Skill), typeof(int), typeof(InteractiveCustomSkillRecord),
        typeof(InteractiveObject))]
    public class LoterieSkill : CustomSkill
    {
        public LoterieSkill(int id, InteractiveCustomSkillRecord skillTemplate, InteractiveObject interactiveObject)
            : base(id, skillTemplate, interactiveObject)
        {
        }

        public override int StartExecute(Character character)
        {
            if (character.WorldAccount.LastLoterieDate != null &&
                character.WorldAccount.LastLoterieDate.Date == DateTime.Now.Date)
            {
                var ticket = character.Inventory.GetItems().FirstOrDefault(x => x.Template.Id == 13417);
                if (ticket != null)
                {
                    character.Inventory.RemoveItem(ticket, 1);
                    character.SendServerMessage(
                        "Vous venez d'utiliser un ticket de loterie ! Écaflip prie pour que le hasard soit avec vous !",
                        Color.YellowGreen);
                    //var nbr = nbr1;
                    //character.Inventory.AddItem(ItemManager.Instance.TryGetTemplate(12124), nbr);
                    //character.OpenPopup("Vous avez obtenu "+ nbr + "<b>Points boutiques.</b>");
                    GetPrice(character);
                }
                else
                {
                    character.OpenPopup("La loterie est gratuite une fois par jour uniquement.");
                }
            }
            else
            {
                GetPrice(character);
            }

            return base.StartExecute(character);
        }

        private void GetPrice(Character character)
        {
            var Items = new Dictionary<int, double>();

            //AJOUT DES ITEMS ID / Chance/100
            //Items Chacha
            Items.Add(15123, 70);
            Items.Add(14623, 70);
            Items.Add(1090, 70);
            Items.Add(9652, 70);
            Items.Add(17490, 70);
            Items.Add(12504, 70);
            Items.Add(14804, 70);
            Items.Add(16235, 70);
            Items.Add(20299, 70);
            Items.Add(18528, 70);
            Items.Add(13305, 70);
            Items.Add(9541, 70);
            Items.Add(9414, 70);
            Items.Add(15158, 70);
            Items.Add(17847, 70);
            Items.Add(7999, 70);
            Items.Add(11372, 70);
            Items.Add(11397, 70);
            Items.Add(17732, 70);
            Items.Add(20369, 70);
            Items.Add(19993, 70);
            Items.Add(20306, 70);
            Items.Add(15098, 70);
            Items.Add(20141, 70);
            Items.Add(20767, 70);
            Items.Add(19724, 70);
            Items.Add(14801, 70);
            Items.Add(20318, 70);
            Items.Add(20032, 70);
            Items.Add(16223, 70);
            Items.Add(19146, 70);
            Items.Add(16016, 70);
            Items.Add(12503, 70);
            Items.Add(15097, 70);
            Items.Add(9194, 70);
            Items.Add(9936, 70);
            Items.Add(19465, 70);
            Items.Add(14299, 70);
            Items.Add(20996, 70);
            Items.Add(20305, 70);
            Items.Add(19722, 70);
            Items.Add(16015, 70);
            Items.Add(2520, 70);
            Items.Add(17298, 70);
            Items.Add(17296, 70);
            Items.Add(9184, 70);
            Items.Add(17299, 70);
            Items.Add(14796, 70);
            Items.Add(16224, 70);
            Items.Add(11398, 70);
            Items.Add(15159, 70);
            Items.Add(8678, 70);
            Items.Add(21101, 70);
            Items.Add(12597, 70);
            Items.Add(11377, 70);
            Items.Add(13015, 70);
            Items.Add(12881, 70);
            Items.Add(11383, 70);
            Items.Add(11394, 70);
            Items.Add(10170, 70);
            Items.Add(11049, 70);
            Items.Add(15542, 70);
            Items.Add(19147, 70);
            Items.Add(18883, 70);
            Items.Add(9190, 70);
            Items.Add(9185, 70);
            Items.Add(10188, 70);
            Items.Add(9577, 70);
            Items.Add(20739, 70);
            Items.Add(14632, 70);
            Items.Add(14631, 70);
            Items.Add(10989, 70);
            Items.Add(10988, 70);
            Items.Add(12885, 70);
            Items.Add(9653, 70);
            Items.Add(13483, 70);
            Items.Add(13484, 70);
            Items.Add(18806, 70);
            Items.Add(18805, 70);
            Items.Add(7422, 70);
            Items.Add(14628, 70);
            Items.Add(14800, 70);
            Items.Add(2517, 70);
            Items.Add(2519, 70);
            Items.Add(1907, 70);
            Items.Add(9456, 70);
            Items.Add(9457, 70);
            Items.Add(20997, 70);
            Items.Add(21102, 70);
            Items.Add(14624, 70);
            Items.Add(9483, 70);
            Items.Add(19725, 70);
            Items.Add(20367, 70);
            Items.Add(13376, 70);
            Items.Add(20139, 70);
            Items.Add(20319, 70);
            Items.Add(15547, 70);
            Items.Add(9484, 70);
            Items.Add(16017, 70);
            Items.Add(17286, 70);
            Items.Add(10556, 70);
            Items.Add(10555, 70);
            Items.Add(10182, 70);
            Items.Add(14596, 70);
            Items.Add(21105, 70);
            Items.Add(13890, 70);
            Items.Add(16826, 70);
            Items.Add(351, 70);
            Items.Add(972, 70);
            Items.Add(8072, 70);
            Items.Add(20667, 70);
            Items.Add(20666, 70);
            Items.Add(21144, 70);
            Items.Add(18960, 70);
            Items.Add(18955, 70);
            Items.Add(18945, 70);
            Items.Add(18920, 70);
            Items.Add(18899, 70);
            Items.Add(18906, 70);
            Items.Add(20320, 70);
            Items.Add(20793, 70);
            Items.Add(21039, 70);
            Items.Add(20370, 70);
            Items.Add(19375, 70);
            Items.Add(19370, 70);
            Items.Add(19365, 70);
            Items.Add(19350, 70);
            Items.Add(19360, 70);
            Items.Add(19355, 70);
            Items.Add(18993, 70);
            Items.Add(18988, 70);
            Items.Add(18982, 70);
            Items.Add(18965, 70);
            Items.Add(18977, 70);
            Items.Add(18971, 70);
            Items.Add(20136, 70);
            Items.Add(19036, 70);
            Items.Add(19026, 70);
            Items.Add(19018, 70);
            Items.Add(19013, 70);
            Items.Add(18998, 70);
            Items.Add(19003, 70);
            Items.Add(19524, 2);
            Items.Add(19526, 2);
            Items.Add(30897, 2);
            Items.Add(30694, 2);
            Items.Add(30695, 2);
            Items.Add(18526, 5);
            Items.Add(18559, 5);
            Items.Add(30734, 2);
            Items.Add(30904, 2);
            Items.Add(30905, 2);
            Items.Add(30738, 2);
            Items.Add(7113, 1);
            Items.Add(10907, 1);
            Items.Add(9643, 70);
            Items.Add(9635, 70);
            Items.Add(14485, 5);
            Items.Add(10861, 5);
            Items.Add(20651, 1);
            Items.Add(20659, 1);
            Items.Add(20655, 1);
            Items.Add(20661, 1);
            Items.Add(20650, 1);
            Items.Add(20649, 1);
            Items.Add(20652, 1);
            Items.Add(20660, 1);
            Items.Add(20658, 1);
            Items.Add(20656, 1);
            Items.Add(20653, 1);
            Items.Add(20654, 1);
            Items.Add(20327, 1);
            Items.Add(30436, 1);
            Items.Add(15235, 1);
            Items.Add(20833, 1);


            var rnd = new Random();
            var randomfinded = rnd.Next(0, 1000) / 100d;

            var Sort = Items.Where(x => x.Value >= randomfinded);

            character.WorldAccount.LastLoterieDate = DateTime.Now;
            if (Sort != null)
            {
                character.Inventory.AddItem(ItemManager.Instance.TryGetTemplate(Sort.RandomElementOrDefault().Key));
                character.OpenPopup(
                    "Vous avez remporté un nouvel objet ! Allez le découvrir tout de suite dans votre inventaire !");
            }
            else
            {
                character.OpenPopup("Nous sommes désolé mais vous n'avez rien gagné réessayez demain ...");
            }
        }
    }
}