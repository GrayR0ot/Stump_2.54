using System;
using Stump.Core.Attributes;
using Stump.Core.Mathematics;
using Stump.Core.Timers;
using Stump.DofusProtocol.Enums;
using Stump.Server.WorldServer.Database.Interactives;
using Stump.Server.WorldServer.Database.Items.Templates;
using Stump.Server.WorldServer.Game.Actors.RolePlay.Characters;
using Stump.Server.WorldServer.Game.Items;
using Stump.Server.WorldServer.Game.Jobs;
using Stump.Server.WorldServer.Handlers.Inventory;

namespace Stump.Server.WorldServer.Game.Interactives.Skills
{
    public class SkillHarvest : Skill, ISkillWithAgeBonus
    {
        public const short ClientStarsBonusLimit = 200;

        [Variable(true)] public static int StarsBonusRate = 1200;

        [Variable(true)] public static short StarsBonusLimit = 200;

        [Variable] public static int HarvestTime = 3000;

        [Variable] public static int RegrowTime = 600000;

        private readonly ItemTemplate m_harvestedItem;
        private TimedTimerEntry m_regrowTimer;

        public SkillHarvest(int id, InteractiveSkillTemplate skillTemplate, InteractiveObject interactiveObject)
            : base(id, skillTemplate, interactiveObject)
        {
            m_harvestedItem = ItemManager.Instance.TryGetTemplate(SkillTemplate.GatheredRessourceItem);
            CreationDate = DateTime.Now;

            if (m_harvestedItem == null)
                throw new Exception($"Harvested item {SkillTemplate.GatheredRessourceItem} doesn't exist");
        }

        public bool Harvested => HarvestedSince.HasValue &&
                                 (DateTime.Now - HarvestedSince).Value.TotalMilliseconds < RegrowTime;

        public DateTime CreationDate { get; }

        public DateTime EnabledSince => HarvestedSince + TimeSpan.FromMilliseconds(RegrowTime) ?? CreationDate;

        public DateTime? HarvestedSince { get; private set; }


        public short AgeBonus
        {
            get
            {
                var bonus = (DateTime.Now - EnabledSince).TotalSeconds / StarsBonusRate;

                if (bonus > StarsBonusLimit)
                    bonus = StarsBonusLimit;

                return (short) bonus;
            }
            set => HarvestedSince = DateTime.Now - TimeSpan.FromMilliseconds(RegrowTime) -
                                    TimeSpan.FromSeconds(value * StarsBonusRate);
        }


        public override int GetDuration(Character character, bool forNetwork = false)
        {
            return HarvestTime;
        }

        public override bool IsEnabled(Character character)
        {
            return base.IsEnabled(character) && !Harvested &&
                   character.Jobs[SkillTemplate.ParentJobId].Level >= SkillTemplate.LevelMin;
        }

        public override int StartExecute(Character character)
        {
            InteractiveObject.SetInteractiveState(InteractiveStateEnum.STATE_ANIMATED);

            base.StartExecute(character);

            return GetDuration(character);
        }

        public override void EndExecute(Character character)
        {
            var count = RollHarvestedItemCount(character);
            var bonus = (int) Math.Floor(count * (AgeBonus / 100d));
            var random = new CryptoRandom();
            var randomBag = random.Next(20);
            if (randomBag == 2)
                switch (m_harvestedItem.Id)
                {
                    //PAYSAN
                    case 289:
                        character.Inventory.AddItem(ItemManager.Instance.TryGetTemplate(2018));
                        character.Client.Character.SendServerMessage(
                            "Félicitation ! Vous venez de drop une ressource rare !");
                        break;
                    case 400:
                        character.Inventory.AddItem(ItemManager.Instance.TryGetTemplate(2032));
                        character.Client.Character.SendServerMessage(
                            "Félicitation ! Vous venez de drop une ressource rare !");
                        break;
                    case 533:
                        character.Inventory.AddItem(ItemManager.Instance.TryGetTemplate(2036));
                        character.Client.Character.SendServerMessage(
                            "Félicitation ! Vous venez de drop une ressource rare !");
                        break;
                    case 401:
                        character.Inventory.AddItem(ItemManager.Instance.TryGetTemplate(2021));
                        character.Client.Character.SendServerMessage(
                            "Félicitation ! Vous venez de drop une ressource rare !");
                        break;
                    case 423:
                        character.Inventory.AddItem(ItemManager.Instance.TryGetTemplate(2026));
                        character.Client.Character.SendServerMessage(
                            "Félicitation ! Vous venez de drop une ressource rare !");
                        break;
                    case 7018:
                        character.Inventory.AddItem(ItemManager.Instance.TryGetTemplate(16452));
                        character.Client.Character.SendServerMessage(
                            "Félicitation ! Vous venez de drop une ressource rare !");
                        break;
                    case 532:
                        character.Inventory.AddItem(ItemManager.Instance.TryGetTemplate(2029));
                        character.Client.Character.SendServerMessage(
                            "Félicitation ! Vous venez de drop une ressource rare !");
                        break;
                    case 405:
                        character.Inventory.AddItem(ItemManager.Instance.TryGetTemplate(16453));
                        character.Client.Character.SendServerMessage(
                            "Félicitation ! Vous venez de drop une ressource rare !");
                        break;
                    case 425:
                        character.Inventory.AddItem(ItemManager.Instance.TryGetTemplate(2035));
                        character.Client.Character.SendServerMessage(
                            "Félicitation ! Vous venez de drop une ressource rare !");
                        break;
                    case 16454:
                        character.Inventory.AddItem(ItemManager.Instance.TryGetTemplate(16455));
                        character.Client.Character.SendServerMessage(
                            "Félicitation ! Vous venez de drop une ressource rare !");
                        break;
                    case 16456:
                        character.Inventory.AddItem(ItemManager.Instance.TryGetTemplate(16457));
                        character.Client.Character.SendServerMessage(
                            "Félicitation ! Vous venez de drop une ressource rare !");
                        break;
                    case 11109:
                        character.Inventory.AddItem(ItemManager.Instance.TryGetTemplate(11499));
                        character.Client.Character.SendServerMessage(
                            "Félicitation ! Vous venez de drop une ressource rare !");
                        break;

                    //ALCHIMISTE
                    case 421:
                        character.Inventory.AddItem(ItemManager.Instance.TryGetTemplate(16378));
                        character.Client.Character.SendServerMessage(
                            "Félicitation ! Vous venez de drop une ressource rare !");
                        break;
                    case 428:
                        character.Inventory.AddItem(ItemManager.Instance.TryGetTemplate(16379));
                        character.Client.Character.SendServerMessage(
                            "Félicitation ! Vous venez de drop une ressource rare !");
                        break;
                    case 395:
                        character.Inventory.AddItem(ItemManager.Instance.TryGetTemplate(16380));
                        character.Client.Character.SendServerMessage(
                            "Félicitation ! Vous venez de drop une ressource rare !");
                        break;
                    case 380:
                        character.Inventory.AddItem(ItemManager.Instance.TryGetTemplate(16381));
                        character.Client.Character.SendServerMessage(
                            "Félicitation ! Vous venez de drop une ressource rare !");
                        break;
                    case 593:
                        character.Inventory.AddItem(ItemManager.Instance.TryGetTemplate(16382));
                        character.Client.Character.SendServerMessage(
                            "Félicitation ! Vous venez de drop une ressource rare !");
                        break;
                    case 594:
                        character.Inventory.AddItem(ItemManager.Instance.TryGetTemplate(16383));
                        character.Client.Character.SendServerMessage(
                            "Félicitation ! Vous venez de drop une ressource rare !");
                        break;
                    case 7059:
                        character.Inventory.AddItem(ItemManager.Instance.TryGetTemplate(16384));
                        character.Client.Character.SendServerMessage(
                            "Félicitation ! Vous venez de drop une ressource rare !");
                        break;
                    case 16385:
                        character.Inventory.AddItem(ItemManager.Instance.TryGetTemplate(16386));
                        character.Client.Character.SendServerMessage(
                            "Félicitation ! Vous venez de drop une ressource rare !");
                        break;
                    case 16387:
                        character.Inventory.AddItem(ItemManager.Instance.TryGetTemplate(16453));
                        character.Client.Character.SendServerMessage(
                            "Félicitation ! Vous venez de drop une ressource rare !");
                        break;
                    case 16389:
                        character.Inventory.AddItem(ItemManager.Instance.TryGetTemplate(16390));
                        character.Client.Character.SendServerMessage(
                            "Félicitation ! Vous venez de drop une ressource rare !");
                        break;
                    case 11102:
                        character.Inventory.AddItem(ItemManager.Instance.TryGetTemplate(13108));
                        character.Client.Character.SendServerMessage(
                            "Félicitation ! Vous venez de drop une ressource rare !");
                        break;

                    //BUCHERON
                    case 303:
                        character.Inventory.AddItem(ItemManager.Instance.TryGetTemplate(16909));
                        character.Client.Character.SendServerMessage(
                            "Félicitation ! Vous venez de drop une ressource rare !");
                        break;
                    case 473:
                        character.Inventory.AddItem(ItemManager.Instance.TryGetTemplate(16910));
                        character.Client.Character.SendServerMessage(
                            "Félicitation ! Vous venez de drop une ressource rare !");
                        break;
                    case 476:
                        character.Inventory.AddItem(ItemManager.Instance.TryGetTemplate(16911));
                        character.Client.Character.SendServerMessage(
                            "Félicitation ! Vous venez de drop une ressource rare !");
                        break;
                    case 460:
                        character.Inventory.AddItem(ItemManager.Instance.TryGetTemplate(16912));
                        character.Client.Character.SendServerMessage(
                            "Félicitation ! Vous venez de drop une ressource rare !");
                        break;
                    case 2358:
                        character.Inventory.AddItem(ItemManager.Instance.TryGetTemplate(16913));
                        character.Client.Character.SendServerMessage(
                            "Félicitation ! Vous venez de drop une ressource rare !");
                        break;
                    case 471:
                        character.Inventory.AddItem(ItemManager.Instance.TryGetTemplate(16914));
                        character.Client.Character.SendServerMessage(
                            "Félicitation ! Vous venez de drop une ressource rare !");
                        break;
                    case 2357:
                        character.Inventory.AddItem(ItemManager.Instance.TryGetTemplate(16915));
                        character.Client.Character.SendServerMessage(
                            "Félicitation ! Vous venez de drop une ressource rare !");
                        break;
                    case 461:
                        character.Inventory.AddItem(ItemManager.Instance.TryGetTemplate(16916));
                        character.Client.Character.SendServerMessage(
                            "Félicitation ! Vous venez de drop une ressource rare !");
                        break;
                    case 7013:
                        character.Inventory.AddItem(ItemManager.Instance.TryGetTemplate(16917));
                        character.Client.Character.SendServerMessage(
                            "Félicitation ! Vous venez de drop une ressource rare !");
                        break;
                    case 474:
                        character.Inventory.AddItem(ItemManager.Instance.TryGetTemplate(16918));
                        character.Client.Character.SendServerMessage(
                            "Félicitation ! Vous venez de drop une ressource rare !");
                        break;
                    case 16488:
                        character.Inventory.AddItem(ItemManager.Instance.TryGetTemplate(16919));
                        character.Client.Character.SendServerMessage(
                            "Félicitation ! Vous venez de drop une ressource rare !");
                        break;
                    case 499:
                        character.Inventory.AddItem(ItemManager.Instance.TryGetTemplate(16920));
                        character.Client.Character.SendServerMessage(
                            "Félicitation ! Vous venez de drop une ressource rare !");
                        break;
                    case 7925:
                        character.Inventory.AddItem(ItemManager.Instance.TryGetTemplate(16921));
                        character.Client.Character.SendServerMessage(
                            "Félicitation ! Vous venez de drop une ressource rare !");
                        break;
                    case 472:
                        character.Inventory.AddItem(ItemManager.Instance.TryGetTemplate(16922));
                        character.Client.Character.SendServerMessage(
                            "Félicitation ! Vous venez de drop une ressource rare !");
                        break;
                    case 7016:
                        character.Inventory.AddItem(ItemManager.Instance.TryGetTemplate(16923));
                        character.Client.Character.SendServerMessage(
                            "Félicitation ! Vous venez de drop une ressource rare !");
                        break;
                    case 470:
                        character.Inventory.AddItem(ItemManager.Instance.TryGetTemplate(16924));
                        character.Client.Character.SendServerMessage(
                            "Félicitation ! Vous venez de drop une ressource rare !");
                        break;
                    case 7014:
                        character.Inventory.AddItem(ItemManager.Instance.TryGetTemplate(16925));
                        character.Client.Character.SendServerMessage(
                            "Félicitation ! Vous venez de drop une ressource rare !");
                        break;
                    case 11107:
                        character.Inventory.AddItem(ItemManager.Instance.TryGetTemplate(16926));
                        character.Client.Character.SendServerMessage(
                            "Félicitation ! Vous venez de drop une ressource rare !");
                        break;

                    //PÊCHEUR
                    case 1782:
                        character.Inventory.AddItem(ItemManager.Instance.TryGetTemplate(1790));
                        character.Client.Character.SendServerMessage(
                            "Félicitation ! Vous venez de drop une ressource rare !");
                        break;
                    case 598:
                        character.Inventory.AddItem(ItemManager.Instance.TryGetTemplate(1786));
                        character.Client.Character.SendServerMessage(
                            "Félicitation ! Vous venez de drop une ressource rare !");
                        break;
                    case 1844:
                        character.Inventory.AddItem(ItemManager.Instance.TryGetTemplate(1846));
                        character.Client.Character.SendServerMessage(
                            "Félicitation ! Vous venez de drop une ressource rare !");
                        break;
                    case 1757:
                        character.Inventory.AddItem(ItemManager.Instance.TryGetTemplate(1759));
                        character.Client.Character.SendServerMessage(
                            "Félicitation ! Vous venez de drop une ressource rare !");
                        break;
                    case 603:
                        character.Inventory.AddItem(ItemManager.Instance.TryGetTemplate(1762));
                        character.Client.Character.SendServerMessage(
                            "Félicitation ! Vous venez de drop une ressource rare !");
                        break;
                    case 1750:
                        character.Inventory.AddItem(ItemManager.Instance.TryGetTemplate(1754));
                        character.Client.Character.SendServerMessage(
                            "Félicitation ! Vous venez de drop une ressource rare !");
                        break;
                    case 1794:
                        character.Inventory.AddItem(ItemManager.Instance.TryGetTemplate(1796));
                        character.Client.Character.SendServerMessage(
                            "Félicitation ! Vous venez de drop une ressource rare !");
                        break;
                    case 1805:
                        character.Inventory.AddItem(ItemManager.Instance.TryGetTemplate(1807));
                        character.Client.Character.SendServerMessage(
                            "Félicitation ! Vous venez de drop une ressource rare !");
                        break;
                    case 1847:
                        character.Inventory.AddItem(ItemManager.Instance.TryGetTemplate(1849));
                        character.Client.Character.SendServerMessage(
                            "Félicitation ! Vous venez de drop une ressource rare !");
                        break;
                    case 600:
                        character.Inventory.AddItem(ItemManager.Instance.TryGetTemplate(1799));
                        character.Client.Character.SendServerMessage(
                            "Félicitation ! Vous venez de drop une ressource rare !");
                        break;
                    case 16461:
                        character.Inventory.AddItem(ItemManager.Instance.TryGetTemplate(16462));
                        character.Client.Character.SendServerMessage(
                            "Félicitation ! Vous venez de drop une ressource rare !");
                        break;
                    case 16463:
                        character.Inventory.AddItem(ItemManager.Instance.TryGetTemplate(16464));
                        character.Client.Character.SendServerMessage(
                            "Félicitation ! Vous venez de drop une ressource rare !");
                        break;
                    case 1801:
                        character.Inventory.AddItem(ItemManager.Instance.TryGetTemplate(1803));
                        character.Client.Character.SendServerMessage(
                            "Félicitation ! Vous venez de drop une ressource rare !");
                        break;
                    case 1784:
                        character.Inventory.AddItem(ItemManager.Instance.TryGetTemplate(1788));
                        character.Client.Character.SendServerMessage(
                            "Félicitation ! Vous venez de drop une ressource rare !");
                        break;
                    case 16465:
                        character.Inventory.AddItem(ItemManager.Instance.TryGetTemplate(16466));
                        character.Client.Character.SendServerMessage(
                            "Félicitation ! Vous venez de drop une ressource rare !");
                        break;
                    case 602:
                        character.Inventory.AddItem(ItemManager.Instance.TryGetTemplate(1853));
                        character.Client.Character.SendServerMessage(
                            "Félicitation ! Vous venez de drop une ressource rare !");
                        break;
                    case 1779:
                        character.Inventory.AddItem(ItemManager.Instance.TryGetTemplate(1792));
                        character.Client.Character.SendServerMessage(
                            "Félicitation ! Vous venez de drop une ressource rare !");
                        break;
                    case 16467:
                        character.Inventory.AddItem(ItemManager.Instance.TryGetTemplate(16468));
                        character.Client.Character.SendServerMessage(
                            "Félicitation ! Vous venez de drop une ressource rare !");
                        break;
                    case 16469:
                        character.Inventory.AddItem(ItemManager.Instance.TryGetTemplate(16470));
                        character.Client.Character.SendServerMessage(
                            "Félicitation ! Vous venez de drop une ressource rare !");
                        break;
                    case 16471:
                        character.Inventory.AddItem(ItemManager.Instance.TryGetTemplate(16472));
                        character.Client.Character.SendServerMessage(
                            "Félicitation ! Vous venez de drop une ressource rare !");
                        break;
                    case 11106:
                        character.Inventory.AddItem(ItemManager.Instance.TryGetTemplate(11500));
                        character.Client.Character.SendServerMessage(
                            "Félicitation ! Vous venez de drop une ressource rare !");
                        break;

                    //MINEUR
                    case 312:
                    case 441:
                    case 442:
                    case 443:
                    case 445:
                    case 7032:
                    case 444:
                    case 350:
                    case 346:
                    case 313:
                    case 7033:
                    case 11110:
                    case 17995:
                        character.Inventory.AddItem(ItemManager.Instance.TryGetTemplate(466)); //SAPHIR
                        character.Inventory.AddItem(ItemManager.Instance.TryGetTemplate(465)); //CRISTAL
                        character.Inventory.AddItem(ItemManager.Instance.TryGetTemplate(315)); //DIAMANT
                        character.Inventory.AddItem(ItemManager.Instance.TryGetTemplate(316)); //EMERAUDE
                        character.Inventory.AddItem(ItemManager.Instance.TryGetTemplate(467)); //RUBIS
                        character.Inventory.AddItem(ItemManager.Instance.TryGetTemplate(7027)); //TOPAZE
                        character.Inventory.AddItem(ItemManager.Instance.TryGetTemplate(7028)); //AGATHE
                        character.Inventory.AddItem(ItemManager.Instance.TryGetTemplate(7026)); //AIGUE-MARINE
                        character.Client.Character.SendServerMessage(
                            "Félicitation ! Vous venez de drop une ressource rare !");
                        break;
                    default:
                        Console.WriteLine("Gathered: " + m_harvestedItem.Id); //RE
                        break;
                }


            SetHarvested();

            InteractiveObject.SetInteractiveState(InteractiveStateEnum.STATE_ACTIVATED);

            if (character.Inventory.IsFull(m_harvestedItem, count))
            {
                //Votre inventaire est plein. Votre récolte est perdue...
                character.SendInformationMessage(TextInformationTypeEnum.TEXT_INFORMATION_MESSAGE, 144);

                base.EndExecute(character);
                return;
            }

            character.Inventory.AddItem(m_harvestedItem, count + bonus);
            InventoryHandler.SendObtainedItemWithBonusMessage(character.Client, m_harvestedItem, count, bonus);

            if (SkillTemplate.ParentJobId != 1)
            {
                var xp = JobManager.Instance.GetHarvestJobXp((int) SkillTemplate.LevelMin);
                if (character.WorldAccount.Vip >= 1)
                    character.Jobs[SkillTemplate.ParentJobId].Experience +=
                        xp * (long) Rates.JobXpRate * (long) Rates.VipBonusJob;
                else
                    character.Jobs[SkillTemplate.ParentJobId].Experience += xp * (long) Rates.JobXpRate;
            }

            character.OnHarvestItem(m_harvestedItem, count + bonus);

            base.EndExecute(character);
        }

        public void SetHarvested()
        {
            HarvestedSince = DateTime.Now;
            InteractiveObject.Map.Refresh(InteractiveObject);
            m_regrowTimer = InteractiveObject.Area.CallDelayed(RegrowTime, Regrow);
        }

        public void Regrow()
        {
            Console.WriteLine("REGROW !");
            if (m_regrowTimer != null)
            {
                m_regrowTimer.Stop();
                m_regrowTimer = null;
            }

            InteractiveObject.Map.Refresh(InteractiveObject);
            InteractiveObject.SetInteractiveState(InteractiveStateEnum.STATE_NORMAL);
        }

        private int RollHarvestedItemCount(Character character)
        {
            var job = character.Jobs[SkillTemplate.ParentJobId];
            var minMax = JobManager.Instance.GetHarvestItemMinMax(job.Template, job.Level, SkillTemplate);
            return new CryptoRandom().Next(minMax.First, minMax.Second + 1);
        }
    }
}