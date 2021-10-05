using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using Stump.Core.Extensions;
using Stump.DofusProtocol.Enums;
using Stump.Server.WorldServer.Commands.Commands.Patterns;
using Stump.Server.WorldServer.Commands.Trigger;
using Stump.Server.WorldServer.Game.Actors.RolePlay.Characters;
using Stump.Server.WorldServer.Game.Items;

namespace Stump.Server.WorldServer.Commands.Commands.Teleport
{
    public class Loterie : InGameCommand
    {
        public static GameTrigger perso;
        private static readonly Dictionary<int, double> Items = new Dictionary<int, double>();
        private static int loops;
        private static int randomfinded;
        private static int randomChoise;
        public bool ItemGenerated = false;


        public Loterie()
        {
            Aliases = new[] {"loterie", "l"};
            RequiredRole = RoleEnum.Player;
            Description = "Faites tourner la roue de loterie pour obtenir divers prix!";
            AddParameter<string>("(liste|jouer)", "(liste|jouer)", "(liste|jouer)");
        }

        public override void Execute(GameTrigger trigger)
        {
            perso = trigger;
            var player = trigger.Character;

            var ticket = trigger.Character.Inventory.GetItems((CharacterInventoryPositionEnum) 63)
                .FirstOrDefault(x => x.Template.Id == 7220);
            var items = trigger.Character.Inventory.GetItems();


            {
                var action = trigger.Get<string>("(liste|jouer)");
                var amount = 1;

                if (action == null)
                    player.SendServerMessage("tapez: <b>.loterie jouer</b> ou <b>.loterie liste</b>.", Color.OrangeRed);
                else
                    switch (action)
                    {
                        case "liste":
                            player.SendServerMessage("<b>Objets en jeu:</b>", Color.Azure);
                            player.SendServerMessage("50% | Coiffe Colo", Color.Yellow);
                            player.SendServerMessage("50% | Cape Colo", Color.Yellow);
                            player.SendServerMessage("50% | Bouclier Colo", Color.Yellow);
                            player.SendServerMessage("50% | Mimibiote", Color.Yellow);
                            player.SendServerMessage("★ 30% | Coiffe Samourivan", Color.LightSteelBlue);
                            player.SendServerMessage("★ 30% | Cape Samourivan", Color.LightSteelBlue);
                            player.SendServerMessage("★ 30% | Bouclier Samourivan", Color.LightSteelBlue);
                            player.SendServerMessage("★ 20% | Dofus du noob", Color.Green);
                            player.SendServerMessage("★ 20% | Dochatte", Color.Green);
                            player.SendServerMessage("★ 10% | Domac", Color.Violet);
                            player.SendServerMessage("★ 10% | Dofist", Color.Violet);
                            player.SendServerMessage("★ 10% | Costume beaucoup trop balèze", Color.Violet);
                            player.SendServerMessage("★ 10% | Dofus Kipik", Color.MistyRose);
                            player.SendServerMessage("★ 10% | Doflotte", Color.MistyRose);
                            player.SendServerMessage("★ 10% | Aerofus", Color.MistyRose);
                            player.SendServerMessage("★ 10% | Dofusote", Color.MistyRose);
                            player.SendServerMessage("★ 10% | Griphoris le souverrain", Color.MistyRose);
                            player.SendServerMessage("★ 10% | Pioute Camé", Color.MistyRose);

                            break;

                        case "jouer":
                            if (ticket.Stack < amount)
                            {
                                trigger.ReplyError("tu n'as pas de <b>Billet de loterie</b>.");
                            }
                            else
                            {
                                player.Inventory.RemoveItem(ticket, 1);
                                GetPrice(trigger.Character);
                            }

                            break;

                        default:
                            player.SendServerMessage("tapez: <b>.loterie jouer</b> ou <b>.loterie liste</b>.",
                                Color.OrangeRed);
                            break;

                            foreach (var basePlayerItem in items) trigger.Character.SaveLater();

                            trigger.Character.Inventory.LoadInventory();
                    }
            }
        }

        private void GetPrice(Character character)
        {
            var rnd = new Random();
            Items.Clear();
            switch (loops)
            {
                case 0:
                    Console.WriteLine("Case 0");
                    Items.Add(31233, 12.5); //ogrines
                    Items.Add(23022, 12.5); // dolmanax
                    Items.Add(23023, 12.5); // emeraude
                    Items.Add(23024, 12.5); // tutu
                    Items.Add(14485, 12.5); // pourpre
                    Items.Add(7043, 12.5); // ddg
                    Items.Add(7113, 12.5); //dofus sasa
                    Items.Add(10907, 12.5); // dofus pp

                    randomfinded = (int) (rnd.Next(0, 1000) / 100d);

                    var Sort1 = Items.Where(x => x.Value >= randomfinded);
                    randomChoise = rnd.Next(0, 2);
                    if (randomChoise == 0)
                    {
                        loops = 0;
                        if (Sort1.RandomElementOrDefault().Key == 31233)
                        {
                            character.Inventory.AddItem(ItemManager.Instance.TryGetTemplate(31233), 400);
                            character.OpenPopup(
                                "Vous n'avez pas remporté d'objet ! Le Dieu d'Asylium vous offre 400 ogrines en lot de consolation !");
                        }
                        else
                        {
                            character.Inventory.AddItem(
                                ItemManager.Instance.TryGetTemplate(Sort1.RandomElementOrDefault().Key));
                            character.OpenPopup(
                                "Vous avez remporté un nouvel objet ! Allez le découvrir tout de suite dans votre inventaire !");
                        }
                    }
                    else
                    {
                        loops++;
                        GetPrice(character);
                    }

                    break;
                case 1:
                    Console.WriteLine("Case 1");
                    Items.Add(31203, 34); // ivoire
                    Items.Add(31204, 33); // ebene
                    Items.Add(31205, 33); // nébuleux

                    randomfinded = (int) (rnd.Next(0, 1000) / 100d);
                    var Sort2 = Items.Where(x => x.Value >= randomfinded);
                    randomChoise = rnd.Next(0, 3);
                    if (randomChoise != 2)
                    {
                        loops = 0;
                        character.Inventory.AddItem(
                            ItemManager.Instance.TryGetTemplate(Sort2.RandomElementOrDefault().Key));
                        character.OpenPopup(
                            "Vous avez remporté un nouvel objet ! Allez le découvrir tout de suite dans votre inventaire !");
                    }
                    else
                    {
                        loops++;
                        GetPrice(character);
                    }

                    break;
                case 2:
                    Console.WriteLine("Case 2");

                    Items.Add(31191, 9); // costume
                    Items.Add(15235, 9); // domac
                    Items.Add(20833, 9); // dofist
                    Items.Add(30453, 9); //dofus kipik
                    Items.Add(30455, 9); //doflotte
                    Items.Add(30456, 9); //dofusote
                    Items.Add(31015, 9); //aerofus
                    Items.Add(31080, 9); //griphon
                    Items.Add(20137, 10); //pioute camé

                    loops = 0;
                    randomfinded = (int) (rnd.Next(0, 1000) / 100d);
                    var Sort3 = Items.Where(x => x.Value >= randomfinded);
                    character.Inventory.AddItem(
                        ItemManager.Instance.TryGetTemplate(Sort3.RandomElementOrDefault().Key));
                    character.OpenPopup(
                        "Vous avez remporté un nouvel objet ! Allez le découvrir tout de suite dans votre inventaire !");
                    break;
            }
        }
    }
}