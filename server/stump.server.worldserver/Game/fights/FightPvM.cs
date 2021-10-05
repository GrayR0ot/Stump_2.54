using Stump.Core.Attributes;
using Stump.Core.Mathematics;
using Stump.DofusProtocol.Enums;
using Stump.ORM.SubSonic.Extensions;
using Stump.Server.WorldServer.Game.Actors.Fight;
using Stump.Server.WorldServer.Game.Actors.RolePlay.Characters;
using Stump.Server.WorldServer.Game.Diverse;
using Stump.Server.WorldServer.Game.Fights.Challenges;
using Stump.Server.WorldServer.Game.Fights.Results;
using Stump.Server.WorldServer.Game.Fights.Teams;
using Stump.Server.WorldServer.Game.Formulas;
using Stump.Server.WorldServer.Game.Items;
using Stump.Server.WorldServer.Game.Items.Player;
using Stump.Server.WorldServer.Game.Items.Player.Custom;
using Stump.Server.WorldServer.Game.Maps;
using Stump.Server.WorldServer.Game.Zaap;
using Stump.Server.WorldServer.Handlers.Context;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Stump.Server.WorldServer.Game.Fights
{
    public class FightPvM : Fight<FightMonsterTeam, FightPlayerTeam>
    {
        [Variable] public static int MaxClassesCountPairFight = 4;
        private bool m_ageBonusDefined;

        public FightPvM(int id, Map fightMap, FightMonsterTeam defendersTeam, FightPlayerTeam challengersTeam)
            : base(id, fightMap, defendersTeam, challengersTeam)
        {
        }

        public override void StartPlacement()
        {
            base.StartPlacement();

            m_placementTimer = Map.Area.CallDelayed(FightConfiguration.PlacementPhaseTime, StartFighting);
        }

        public override void StartFighting()
        {
            m_placementTimer.Dispose();
            if (PlayerTeam.Leader.Character.IsPartyLeader())
                ActiveIdols = PlayerTeam.Leader.Character.Party.IdolInventory.ComputeIdols(this).ToList();
            else
                ActiveIdols = PlayerTeam.Leader.Character.IdolInventory.ComputeIdols(this).ToList();

            base.StartFighting();
        }

        protected override void OnFightStarted()
        {
            base.OnFightStarted();

            if (!Map.AllowFightChallenges)
                return;

            initChallenge();

            if (Map.IsDungeon() || IsPvMArenaFight)
                initChallenge();

            if (Map.IsDungeon())
            {
                foreach (var fighter in Fighters.OfType<CharacterFighter>())
                    fighter.Character.Record.BackDungeon = Map.Id;
            }

            void initChallenge()
            {
                var challenge = ChallengeManager.Instance.GetRandomChallenge(this);

                // no challenge found
                if (challenge == null)
                    return;

                challenge.Initialize();
                AddChallenge(challenge);
            }
        }

        protected override void OnFighterAdded(FightTeam team, FightActor actor)
        {
            base.OnFighterAdded(team, actor);

            if (!(team is FightMonsterTeam) || m_ageBonusDefined)
                return;

            if (team.Leader is MonsterFighter monsterFighter)
                AgeBonus = monsterFighter.Monster.Group.AgeBonus;

            m_ageBonusDefined = true;
        }

        public FightPlayerTeam PlayerTeam => Teams.FirstOrDefault(x => x.TeamType == TeamTypeEnum.TEAM_TYPE_PLAYER) as FightPlayerTeam;

        public FightMonsterTeam MonsterTeam => Teams.FirstOrDefault(x => x.TeamType == TeamTypeEnum.TEAM_TYPE_MONSTER) as FightMonsterTeam;

        public override FightTypeEnum FightType => FightTypeEnum.FIGHT_TYPE_PvM;

        public override bool IsPvP => false;

        public bool IsPvMArenaFight
        {
            get;
            set;
        }

        //private DroppedItem LootOrbs(int prospec)
        //{
        //    var listMonster = Fighters.Where(x => x is MonsterFighter);
        //    //if (listMonster.Count() > 8)
        //    //{
        //    //    for (int i = 0; i < listMonster.Count() - 8; i++)
        //    //    {
        //    //        listMonster.ToList().RemoveAt(listMonster.Count() - i - 1);
        //    //        i++;
        //    //    }
        //    //}


        //    int levelTotal = listMonster.Select(x => (int)x.Level).Sum();

        //    var calc = (uint)(levelTotal / 4 * prospec / 120f);


        //    if (levelTotal > 199)
        //        calc = (uint)(levelTotal / 3 * prospec / 120f);

        //    if (levelTotal > 1600)
        //        calc = (uint)(levelTotal * prospec / 120f);

        //    if (calc <= 0)
        //        calc = 1;


        //    return new DroppedItem(30000, calc); ;


        //}

        protected override List<IFightResult> GetResults()
        {
            var results = new List<IFightResult>();
            results.AddRange(GetFightersAndLeavers().Where(entry => entry.HasResult).Select(entry => entry.GetFightResult()));

            var taxCollectors = Map.SubArea.Maps.Select(x => x.TaxCollector).Where(x => x != null && x.CanGatherLoots());
            results.AddRange(taxCollectors.Select(x => new TaxCollectorProspectingResult(x, this)));

            foreach (var team in m_teams)
            {
                double finalBonus = FightFormulas.getRandomFinalBonus();
                IEnumerable<FightActor> droppers = team.OpposedTeam.GetAllFighters(entry => entry.IsDead() && entry.CanDrop()).ToList();

                var looters = results.Where(x => x.CanLoot(team) && !(x is TaxCollectorProspectingResult)).OrderByDescending(entry => entry.Prospecting).

                    Concat(results.OfType<TaxCollectorProspectingResult>().Where(x => x.CanLoot(team)).OrderByDescending(x => x.Prospecting)); // tax collector loots at the end

                var teamPP = team.GetAllFighters<CharacterFighter>().Sum(entry => (entry.Stats[PlayerFields.Prospecting].Total >= 100) ? 100 : entry.Stats[PlayerFields.Prospecting].Total);

                var looterx = looters.ToList();

                var kamas = Winners == team ? droppers.Sum(entry => entry.GetDroppedKamas()) * team.GetAllFighters<CharacterFighter>().Count() : 0;

                CryptoRandom cryptoRandom = new CryptoRandom();

                foreach (var looter in looters)
                {
                    if (team == Winners && looter is FightPlayerResult)
                    {
                        Character character = (looter as FightPlayerResult).Character;
                        var incrementKamas = false;
                        //SAVE DUNGEON
                        if (character.Record.BackDungeon == Map.Id)
                            character.Record.BackDungeon = 0;

                        if (character.WorldAccount.Vip >= 1)
                            incrementKamas = true;

                        looter.Loot.Kamas = FightFormulas.CalculateEarnedKamas(looter, team.GetAllFighters(), droppers) * (incrementKamas ? 3 : 1);

                        /*if (looter is FightPlayerResult)
                        {
                            (looter as FightPlayerResult).Character.SendServerMessage($"Kamas : x {(incrementKamas ? 3 : 1)}");
                        }*/
                    }

                    //looter.Loot.Kamas = FightFormulas.CalculateEarnedKamas(looter, team.GetAllFighters(), droppers);
                    if (team == Winners)
                    {
                        foreach (var item in droppers.SelectMany(dropper => dropper.RollLoot(looter)))
                        {
                            //Prevent dofus items being dropped twice
                            switch (item.ItemId)
                            {
                                case 20987:
                                case 20286:
                                case 19629:
                                case 19398:
                                case 18043:
                                case 17078:
                                case 16061:
                                case 8698:
                                case 8072:
                                case 7754:
                                case 7115:
                                case 7114:
                                case 6980:
                                case 972:
                                case 739:
                                case 737:
                                case 694:
                                case 7043:
                                    break;
                                default:
                                    item.Amount = (uint)(item.Amount * Rates.ResourceDropRate);
                                    break;
                            }

                            var ipDropped = false;
                            foreach (var currentLooter in looters)
                            {
                                if (!(currentLooter is TaxCollectorProspectingResult) && (!(looter is TaxCollectorProspectingResult)))
                                {
                                    if (currentLooter is FightPlayerResult && (currentLooter as FightPlayerResult).Character != null)
                                    {
                                        Character currentCharacter = (currentLooter as FightPlayerResult).Character;
                                        if (currentCharacter.IsIpDrop)
                                        {
                                            if (currentCharacter.Client != null && currentCharacter.Client.IP != null)
                                            {
                                                if (currentCharacter.Client.IP == (looter as FightPlayerResult).Character.Client.IP)
                                                {
                                                    currentLooter.Loot.AddItem(item);
                                                    ipDropped = true;
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                            if (!ipDropped)
                            {
                                looter.Loot.AddItem(item);
                            }

                        }


                        #region equipmentDrop
                        List<int> types = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 16, 17, 19 };
                        List<int> blacklist = new List<int>() { 30124, 30123, 30122, 30121, 30671, 15157, 13424, 14030, 17648, 8918, 18145, 17961, 8829, 6863, 6802, 6662, 8854, 6660, 18146, 778, 6886, 19641, 6801, 2118, 2119, 6800, 677, 30239, 30240, 30241, 30242, 30243, 30244, 30245, 30246, 30128, 30127, 30126, 30125, 30124, 30123, 30122, 30121, 30671, 30672, 15157, 13424, 30623, 30624, 30625, 30626, 30627, 30628, 30629, 30630, 30631, 30632, 30633, 32103, 32104, 32100, 32106, 30634, 30547, 21010, 32102, 32105, 32107, 32101, 21009, 20363, 20364, 20365, 20361, 20366, 20362, 20359, 20353, 20360, 20357, 20356, 20358 };

                        int amountOfRuns = (this.DefendersTeam.GetAllFighters().Count() > 2) ? this.DefendersTeam.GetAllFighters().Count() / 2 : 1;
                        int monsterLevel = (int)this.DefendersTeam.GetAllFighters().Average(entry => entry.Level);
                        for (int i = 0; i < amountOfRuns; i++)
                        {
                            int monsterLevelRound = ((int)(monsterLevel / 10) * 10);
                            var maxLuck = 0;
                            if (monsterLevel < 50 && monsterLevel >= 21)
                            {
                                maxLuck = 250;
                                foreach (var itemTemplate in ItemManager.Instance.GetTemplates().Where(x => !x.Etheral).Where(x => !x.IsLinkedToOwner).OrderBy(a => cryptoRandom.Next()).OrderBy(a => cryptoRandom.Next()).OrderBy(a => cryptoRandom.Next()))
                                {
                                    if (itemTemplate != null && itemTemplate.Type != null)
                                    {
                                        int itemLevelRound = ((int)(itemTemplate.Level / 10) * 10);
                                        if (itemLevelRound == monsterLevelRound)
                                        {
                                            if (types.Contains(itemTemplate.Type.Id))
                                            {
                                                if (!blacklist.Contains(itemTemplate.Id))
                                                {
                                                    dropItem(looter, new DroppedItem(itemTemplate.Id, 1), cryptoRandom, maxLuck);
                                                    break;
                                                }
                                            }
                                        }
                                    }

                                }
                            }
                            else if (monsterLevel < 100 && monsterLevel >= 50)
                            {
                                maxLuck = 750;
                                foreach (var itemTemplate in ItemManager.Instance.GetTemplates().Where(x => !x.Etheral).Where(x => !x.IsLinkedToOwner).OrderBy(a => cryptoRandom.Next()).OrderBy(a => cryptoRandom.Next()).OrderBy(a => cryptoRandom.Next()))
                                {
                                    if (itemTemplate != null && itemTemplate.Type != null)
                                    {
                                        int itemLevelRound = ((int)(itemTemplate.Level / 10) * 10);
                                        if (itemLevelRound == monsterLevelRound)
                                        {
                                            if (types.Contains(itemTemplate.Type.Id))
                                            {
                                                if (!blacklist.Contains(itemTemplate.Id))
                                                {
                                                    dropItem(looter, new DroppedItem(itemTemplate.Id, 1), cryptoRandom, maxLuck);
                                                    break;
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                            else if (monsterLevel < 150 && monsterLevel >= 100)
                            {
                                maxLuck = 1500;
                                foreach (var itemTemplate in ItemManager.Instance.GetTemplates().Where(x => !x.Etheral).Where(x => !x.IsLinkedToOwner).OrderBy(a => cryptoRandom.Next()).OrderBy(a => cryptoRandom.Next()).OrderBy(a => cryptoRandom.Next()))
                                {
                                    if (itemTemplate != null && itemTemplate.Type != null)
                                    {
                                        int itemLevelRound = ((int)(itemTemplate.Level / 10) * 10);
                                        if (itemLevelRound == monsterLevelRound)
                                        {
                                            if (types.Contains(itemTemplate.Type.Id))
                                            {
                                                if (!blacklist.Contains(itemTemplate.Id))
                                                {
                                                    dropItem(looter, new DroppedItem(itemTemplate.Id, 1), cryptoRandom, maxLuck);
                                                    break;
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                            else if (monsterLevel < 200 && monsterLevel >= 150)
                            {
                                maxLuck = 2000;
                                foreach (var itemTemplate in ItemManager.Instance.GetTemplates().Where(x => !x.Etheral).Where(x => !x.IsLinkedToOwner).OrderBy(a => cryptoRandom.Next()).OrderBy(a => cryptoRandom.Next()).OrderBy(a => cryptoRandom.Next()))
                                {
                                    if (itemTemplate != null && itemTemplate.Type != null)
                                    {
                                        int itemLevelRound = ((int)(itemTemplate.Level / 10) * 10);
                                        if (itemLevelRound == monsterLevelRound)
                                        {
                                            if (types.Contains(itemTemplate.Type.Id))
                                            {
                                                if (!blacklist.Contains(itemTemplate.Id))
                                                {
                                                    dropItem(looter, new DroppedItem(itemTemplate.Id, 1), cryptoRandom, maxLuck);
                                                    break;
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                            else if (monsterLevel >= 200)
                            {
                                maxLuck = 3000;
                                foreach (var itemTemplate in ItemManager.Instance.GetTemplates().Where(x => !x.Etheral).Where(x => !x.IsLinkedToOwner).OrderBy(a => cryptoRandom.Next()).OrderBy(a => cryptoRandom.Next()).OrderBy(a => cryptoRandom.Next()))
                                {
                                    if (itemTemplate != null && itemTemplate.Type != null)
                                    {
                                        int itemLevelRound = ((int)(itemTemplate.Level / 10) * 10);
                                        if (itemLevelRound >= 200)
                                        {
                                            if (types.Contains(itemTemplate.Type.Id))
                                            {
                                                if (!blacklist.Contains(itemTemplate.Id))
                                                {
                                                    dropItem(looter, new DroppedItem(itemTemplate.Id, 1), cryptoRandom, maxLuck);
                                                    break;
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        #endregion



                        #region Petloot

                        Random random1 = new Random();
                        Random random2 = new Random();
                        foreach (var monster in this.DefendersTeam.GetAllFighters())
                        {
                            if (monster is MonsterFighter)
                            {
                                if (monster.Level <= 50)
                                {
                                    dropPetLoot(looters, new DroppedItem(19382, 1), random1);
                                    dropFoodLoot(looters, new DroppedItem(20125, 1), random2);
                                }
                                else if (monster.Level <= 100)
                                {
                                    dropPetLoot(looters, new DroppedItem(19382, 2), random1);
                                    dropFoodLoot(looters, new DroppedItem(20125, 2), random2);
                                }
                                else if (monster.Level <= 150)
                                {
                                    dropPetLoot(looters, new DroppedItem(19382, 3), random1);
                                    dropFoodLoot(looters, new DroppedItem(20125, 4), random2);
                                }
                                else
                                {
                                    dropPetLoot(looters, new DroppedItem(19382, 4), random1);
                                    dropFoodLoot(looters, new DroppedItem(20125, 8), random2);
                                }

                            }

                        }

                        #endregion

                        #region chasseur
                        if (team == Winners && looter is FightPlayerResult)
                        {
                            Character character = (looter as FightPlayerResult).Character;
                            BasePlayerItem Arme = character.Inventory.TryGetItem(CharacterInventoryPositionEnum.ACCESSORY_POSITION_WEAPON);
                            var items = character.Inventory.GetEquipedItems();
                            //var effectDamage = Arme.Effects.Find(x => x.EffectId == EffectsEnum.Effect_795);

                            if (Arme != null)
                            {
                                foreach (var item in items)
                                {
                                    if (item.Effects.Exists(x => x.EffectId == EffectsEnum.Effect_795))
                                    {
                                        foreach (MonsterFighter monster in this.DefendersTeam.GetAllFighters().Where(x => x is MonsterFighter))
                                        {
                                            int m_templates = monster.Monster.Template.Id;
                                            if (ChasseurManager.Instance.DropExist(m_templates))
                                            {
                                                if (Arme != null)
                                                {
                                                    if ((int)character.Jobs[(int)JobEnum.CHASSEUR].Level >= ChasseurManager.Instance.Level(m_templates))
                                                    {
                                                        looter.Loot.AddItem(new DroppedItem(ChasseurManager.Instance.ItemId(m_templates), (uint)1));
                                                    }
                                                }
                                            }
                                        }
                                    }

                                }

                            }
                        }
                        #endregion



                        #region Ascension Boss
                        if (team == Winners && looter is FightPlayerResult)
                        {
                            foreach (var monster in this.DefendersTeam.GetAllFighters())
                            {
                                if (monster is MonsterFighter)
                                {
                                    Actors.RolePlay.Characters.Character character = (looter as FightPlayerResult).Character;
                                    if (AscensionEnum.getAscensionFloorMap(character.GetAscensionStair())[0].Equals(character.Map.Id))
                                    {
                                        foreach (var item in AscensionEnum.getAscensionFloorLoots(character.GetAscensionStair()))
                                        {
                                            looter.Loot.AddItem(new DroppedItem(item[0], (uint)item[1])); // si oui on loot l'item
                                        }
                                        if (character.GetAscensionStair() < 100)
                                        {
                                            character.SendServerMessage("Vous avez terminé l'étage " + (character.AscensionStair + 1));
                                            character.AddAscensionStair(1);
                                            if (character.GetAscensionStair() == 99)
                                            {
                                                character.SendServerMessage("Vous avez terminé tous les étages");
                                                World.Instance.SendAnnounce("<b>" + character.Name + "</b> a terminé tous les étages de la Tour de l'Ascension.", Color.Yellow);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        #endregion

                        #region Doplons
                        foreach (var monster in this.DefendersTeam.GetAllFighters())
                        {
                            if (monster is MonsterFighter)
                            {
                                if ((monster as MonsterFighter).Monster.Template.Id != 494 && monster.SubArea.Id == 62)
                                {
                                    double amount = (10 / ChallengersTeam.GetAllFighters().Count());
                                    looter.Loot.AddItem(new DroppedItem(13052, (uint)amount));
                                }
                            }
                        }
                        #endregion

                        #region DungeonKeys
                        Random random = new Random();
                        List<DungeonKey> dungeonsKeys = new List<DungeonKey>();
                        dungeonsKeys.Add(new DungeonKey(152829952, 8545)); //kardo
                        dungeonsKeys.Add(new DungeonKey(121373185, 1568));  //bouftou
                        dungeonsKeys.Add(new DungeonKey(190449664, 8143));  //champs
                        dungeonsKeys.Add(new DungeonKey(193725440, 8437));  //emsablé
                        dungeonsKeys.Add(new DungeonKey(146675712, 15991));  //kankreblath
                        dungeonsKeys.Add(new DungeonKey(163578368, 11799));  //maison hanté
                        dungeonsKeys.Add(new DungeonKey(87033344, 1570));  //squelette
                        dungeonsKeys.Add(new DungeonKey(94110720, 8139));  //scara
                        dungeonsKeys.Add(new DungeonKey(96338946, 7918));  //batofu
                        dungeonsKeys.Add(new DungeonKey(181665792, 19041));  //magik riktus
                        dungeonsKeys.Add(new DungeonKey(155713536, 8156));  //meulou
                        dungeonsKeys.Add(new DungeonKey(187432960, 19515)); //bethel
                        dungeonsKeys.Add(new DungeonKey(55050240, 11174));  //royalmouth
                        dungeonsKeys.Add(new DungeonKey(17564931, 7310));  //bulbe
                        dungeonsKeys.Add(new DungeonKey(184690945, 19216));  //ilyzaelle
                        dungeonsKeys.Add(new DungeonKey(87295489, 1569)); //forgeron
                        dungeonsKeys.Add(new DungeonKey(104595969, 8135)); //bwork
                        dungeonsKeys.Add(new DungeonKey(64749568, 12017)); //kwakwa
                        dungeonsKeys.Add(new DungeonKey(106954752, 7927)); //craqueleur
                        dungeonsKeys.Add(new DungeonKey(56098816, 11175)); //mansot
                        dungeonsKeys.Add(new DungeonKey(40108544, 8438)); //rat brak
                        dungeonsKeys.Add(new DungeonKey(56360960, 11176)); //ben
                        dungeonsKeys.Add(new DungeonKey(169345024, 18068)); //koutoulou
                        dungeonsKeys.Add(new DungeonKey(22282240, 8971)); //arche oto
                        dungeonsKeys.Add(new DungeonKey(176947200, 12073)); //nelwenn
                        dungeonsKeys.Add(new DungeonKey(157286400, 17112)); //moon
                        dungeonsKeys.Add(new DungeonKey(159125512, 7926)); //corbac
                        dungeonsKeys.Add(new DungeonKey(176160768, 18544)); //talkasha
                        dungeonsKeys.Add(new DungeonKey(109576705, 14046)); //nileza
                        dungeonsKeys.Add(new DungeonKey(110362624, 14045)); //klime
                        dungeonsKeys.Add(new DungeonKey(98566657, 996)); //gelées
                        dungeonsKeys.Add(new DungeonKey(166986752, 9248)); //blop
                        dungeonsKeys.Add(new DungeonKey(72351744, 8320)); //dc
                        dungeonsKeys.Add(new DungeonKey(118226944, 14560)); //dramak
                        dungeonsKeys.Add(new DungeonKey(149684224, 7557)); //Aancestral
                        dungeonsKeys.Add(new DungeonKey(149423104, 8436)); //chene mou
                        dungeonsKeys.Add(new DungeonKey(79430145, 12735)); //daigoro
                        dungeonsKeys.Add(new DungeonKey(22808576, 8972)); //rasboul
                        dungeonsKeys.Add(new DungeonKey(27787264, 8343)); //croca
                        dungeonsKeys.Add(new DungeonKey(125831681, 15093)); //kanigroula
                        dungeonsKeys.Add(new DungeonKey(96338948, 8142)); //tofu royal
                        dungeonsKeys.Add(new DungeonKey(89391104, 8975)); //tynril
                        dungeonsKeys.Add(new DungeonKey(57148161, 11177)); //obsi
                        dungeonsKeys.Add(new DungeonKey(157548544, 11798)); //kaniboul
                        dungeonsKeys.Add(new DungeonKey(116392448, 14464)); //wa wabit
                        dungeonsKeys.Add(new DungeonKey(34473474, 7924)); //minotoror
                        dungeonsKeys.Add(new DungeonKey(34472450, 8307)); //minotot
                        dungeonsKeys.Add(new DungeonKey(96994817, 7423)); //larves
                        dungeonsKeys.Add(new DungeonKey(174064128, 18422)); //elpiko
                        dungeonsKeys.Add(new DungeonKey(132907008, 15162)); //truche
                        dungeonsKeys.Add(new DungeonKey(149160960, 16179)); //reine nyée
                        dungeonsKeys.Add(new DungeonKey(157024256, 17113)); //chouque
                        dungeonsKeys.Add(new DungeonKey(174326272, 18421)); //mastdonte
                        dungeonsKeys.Add(new DungeonKey(21495808, 8977)); //kimbo
                        dungeonsKeys.Add(new DungeonKey(116654593, 14465)); //wa wobot
                        dungeonsKeys.Add(new DungeonKey(27000832, 8439)); //rat bonta
                        dungeonsKeys.Add(new DungeonKey(5243139, 8917)); //hesk
                        dungeonsKeys.Add(new DungeonKey(26738688, 31232)); //kralamour geant
                        dungeonsKeys.Add(new DungeonKey(130286592, 15278)); //mallefisk
                        dungeonsKeys.Add(new DungeonKey(143138823, 15806)); //fraktal
                        dungeonsKeys.Add(new DungeonKey(161743872, 17563)); //pounicheur
                        dungeonsKeys.Add(new DungeonKey(107216896, 7908)); //koulosse
                        dungeonsKeys.Add(new DungeonKey(137102336, 15475)); //rdv
                        dungeonsKeys.Add(new DungeonKey(136578048, 15477)); //ekarlate
                        dungeonsKeys.Add(new DungeonKey(136840192, 15476)); //toxo
                        dungeonsKeys.Add(new DungeonKey(130548736, 15279)); //phossile
                        dungeonsKeys.Add(new DungeonKey(129500160, 15280)); //nidas
                        dungeonsKeys.Add(new DungeonKey(143917569, 15807)); //xlii
                        dungeonsKeys.Add(new DungeonKey(143393281, 15808)); //vortex
                        dungeonsKeys.Add(new DungeonKey(162004992, 17564)); //ush
                        dungeonsKeys.Add(new DungeonKey(160564224, 17565)); //chaloeil
                        dungeonsKeys.Add(new DungeonKey(140771328, 15690)); //baleine
                        dungeonsKeys.Add(new DungeonKey(119277057, 14870)); //merkator
                        dungeonsKeys.Add(new DungeonKey(110100480, 14044)); //sylargh
                                                                            //dungeonsKeys.Add(new DungeonKey(173934082, ),285); croco
                        dungeonsKeys.Add(new DungeonKey(187957506, 19514)); //solar
                        dungeonsKeys.Add(new DungeonKey(182714368, 19049)); //4patte
                        dungeonsKeys.Add(new DungeonKey(107481088, 8073)); //skeunk
                        dungeonsKeys.Add(new DungeonKey(195035136, 19963)); //dazak
                        dungeonsKeys.Add(new DungeonKey(112201217, 14047)); //conte harebourg
                        dungeonsKeys.Add(new DungeonKey(169869312, 18066)); //meno
                        dungeonsKeys.Add(new DungeonKey(18088960, 7311)); //kitsoun
                        dungeonsKeys.Add(new DungeonKey(17302528, 7309)); //pandikaze
                        dungeonsKeys.Add(new DungeonKey(59511808, 11178)); //givrefoux
                        dungeonsKeys.Add(new DungeonKey(16516867, 7312)); //firefoux
                        dungeonsKeys.Add(new DungeonKey(62915584, 11179)); //korri
                        dungeonsKeys.Add(new DungeonKey(61865984, 11180)); //kolosso
                        dungeonsKeys.Add(new DungeonKey(62130696, 11181)); //glours
                        dungeonsKeys.Add(new DungeonKey(109838849, 14043));//frizz
                        dungeonsKeys.Add(new DungeonKey(57934593, 8329)); //grolum
                        dungeonsKeys.Add(new DungeonKey(102760961, 12351)); //sphincter
                        dungeonsKeys.Add(new DungeonKey(179568640, 18736)); //razoff
                        dungeonsKeys.Add(new DungeonKey(104333825, 6884)); //bworker
                        dungeonsKeys.Add(new DungeonKey(182327297, 9247)); //ougah
                        dungeonsKeys.Add(new DungeonKey(101188608, 13333)); // halloween
                        dungeonsKeys.Add(new DungeonKey(169607168, 18067)); //dentinea
                        dungeonsKeys.Add(new DungeonKey(123207680, 14935));// ombre
                        dungeonsKeys.Add(new DungeonKey(176030208, 18552)); // pervert
                        dungeonsKeys.Add(new DungeonKey(74973185, 31019)); // grozilla

                        foreach (var monster in this.DefendersTeam.GetAllFighters())
                        {
                            if (monster is MonsterFighter)
                            {
                                foreach (DungeonKey dungeonKey in dungeonsKeys)
                                {
                                    Map currentMap = World.Instance.GetMap(dungeonKey.getDungeon());
                                    if (currentMap.Area.Id == Map.Area.Id)
                                    {
                                        dropKey(looters, new DroppedItem(dungeonKey.getKey(), 1), random);
                                    }

                                }
                            }
                        }
                        #endregion

                        #region Asyliumkey
                        var Luck = 16;
                        List<AsyliumKey> asyliumkeys = new List<AsyliumKey>();
                        //fragments
                        asyliumkeys.Add(new AsyliumKey(143393281, 31244)); //1
                        asyliumkeys.Add(new AsyliumKey(109840899, 31245)); //2
                        asyliumkeys.Add(new AsyliumKey(195039232, 31246)); //3
                        asyliumkeys.Add(new AsyliumKey(187437056, 31247)); //4
                        asyliumkeys.Add(new AsyliumKey(160564224, 31248)); //5
                        asyliumkeys.Add(new AsyliumKey(176164864, 31249)); //6
                        asyliumkeys.Add(new AsyliumKey(119277059, 31250)); //7
                        asyliumkeys.Add(new AsyliumKey(112203523, 31251)); //8
                        asyliumkeys.Add(new AsyliumKey(187957512, 31252)); //9
                        asyliumkeys.Add(new AsyliumKey(184686337, 31253)); //10

                        List<AsyliumDofus> asyliumdofus = new List<AsyliumDofus>();
                        //dofus
                        asyliumdofus.Add(new AsyliumDofus(175113216, 30453)); //terre
                        asyliumdofus.Add(new AsyliumDofus(173937152, 30456)); //feu
                        asyliumdofus.Add(new AsyliumDofus(175114242, 31015)); //air
                        asyliumdofus.Add(new AsyliumDofus(173934080, 30455)); //eau
                        asyliumdofus.Add(new AsyliumDofus(173934082, 31240)); //galactique

                        foreach (var monster in this.DefendersTeam.GetAllFighters())
                        {
                            if (monster is MonsterFighter)
                            {
                                if ((monster as MonsterFighter).Monster.Template.IsBoss)
                                {
                                    foreach (AsyliumKey asyliumkey in asyliumkeys)
                                    {
                                        Map currentMap = World.Instance.GetMap(asyliumkey.getDungeon());
                                        if (currentMap.Id == Map.Id)
                                        {
                                            dropKeyasylium(looters, new DroppedItem(asyliumkey.getKey(), 1));
                                        }

                                    }
                                }

                            }
                        }
                        foreach (var monster in this.DefendersTeam.GetAllFighters())
                        {

                            if (monster is MonsterFighter)
                                if ((monster as MonsterFighter).Monster.Template.IsBoss)
                                {
                                    foreach (AsyliumDofus asyliumdof in asyliumdofus)
                                    {
                                        Map currentMap = World.Instance.GetMap(asyliumdof.getDungeon());
                                        if (currentMap.Id == Map.Id && currentMap.Id != 173934082)
                                        {
                                            dropDofus(looter, new DroppedItem(asyliumdof.getKey(), 1), cryptoRandom, Luck);
                                        }
                                        else if (currentMap.Id == Map.Id && currentMap.Id == 173934082)
                                        {
                                            Luck = 48;
                                            dropDofus(looter, new DroppedItem(asyliumdof.getKey(), 1), cryptoRandom, Luck);

                                        }

                                    }
                                }
                        }

                        #endregion
                        #region BountyMonster
                        foreach (var monster in this.DefendersTeam.GetAllFighters())
                        {
                            if (monster is MonsterFighter)
                            {
                                switch ((monster as MonsterFighter).Monster.Template.Id)
                                {
                                    case 463:
                                        new BountyRewardQuest(20).addLoot(looter);
                                        looter.Loot.AddItem(new DroppedItem(15793, 1));
                                        break;
                                    case 460:
                                        new BountyRewardQuest(30).addLoot(looter);
                                        looter.Loot.AddItem(new DroppedItem(15478, 1));
                                        break;
                                    case 3525:
                                    case 3526:
                                        new BountyRewardQuest(30).addLoot(looter);
                                        break;
                                    case 462:
                                        new BountyRewardQuest(50).addLoot(looter);
                                        break;
                                    case 464:
                                        looter.Loot.AddItem(new DroppedItem(16009, 1));
                                        new BountyRewardQuest(60).addLoot(looter);
                                        break;
                                    case 554:
                                    case 3527:
                                        new BountyRewardQuest(60).addLoot(looter);
                                        break;
                                    case 481:
                                        new BountyRewardQuest(70).addLoot(looter);
                                        break;
                                    case 446:
                                    case 552:
                                    case 4014:
                                    case 4618:
                                        new BountyRewardQuest(80).addLoot(looter);
                                        break;
                                    case 550:
                                    case 4814:
                                        new BountyRewardQuest(90).addLoot(looter);
                                        break;
                                    case 4027:
                                    case 4240:
                                    case 4815:
                                    case 3670:
                                        new BountyRewardQuest(100).addLoot(looter);
                                        break;
                                    case 3762:
                                        looter.Loot.AddItem(new DroppedItem(16010, 1));
                                        new BountyRewardQuest(120).addLoot(looter);
                                        break;
                                    case 4041:
                                    case 2901:
                                    case 3845:
                                        new BountyRewardQuest(120).addLoot(looter);
                                        break;

                                    case 3524:
                                        looter.Loot.AddItem(new DroppedItem(15541, 1));
                                        new BountyRewardQuest(130).addLoot(looter);
                                        break;
                                    case 459:
                                    case 2902:
                                    case 4622:
                                        new BountyRewardQuest(130).addLoot(looter);
                                        break;
                                    case 4015:
                                    case 3528:
                                    case 2903:
                                        new BountyRewardQuest(140).addLoot(looter);
                                        break;
                                    case 555:
                                    case 3669:
                                        looter.Loot.AddItem(new DroppedItem(17114, 1));
                                        new BountyRewardQuest(150).addLoot(looter);
                                        break;
                                    case 2904:
                                        new BountyRewardQuest(150).addLoot(looter);
                                        break;
                                    case 4017:
                                        looter.Loot.AddItem(new DroppedItem(17115, 1));
                                        new BountyRewardQuest(160).addLoot(looter);
                                        break;
                                    case 2905:
                                    case 3760:
                                        new BountyRewardQuest(160).addLoot(looter);
                                        break;
                                    case 4016:
                                        looter.Loot.AddItem(new DroppedItem(17116, 1));
                                        new BountyRewardQuest(170).addLoot(looter);
                                        break;
                                    case 2908:
                                        looter.Loot.AddItem(new DroppedItem(15485, 1));
                                        new BountyRewardQuest(170).addLoot(looter);
                                        break;
                                    case 2906:
                                    case 4737:
                                    case 3848:
                                        new BountyRewardQuest(170).addLoot(looter);
                                        break;
                                    case 4816:
                                        new BountyRewardQuest(180).addLoot(looter);
                                        break;
                                    case 4028:
                                        looter.Loot.AddItem(new DroppedItem(17118, 1));
                                        new BountyRewardQuest(190).addLoot(looter);
                                        break;
                                    case 3533:
                                        looter.Loot.AddItem(new DroppedItem(16008, 1));
                                        new BountyRewardQuest(190).addLoot(looter);
                                        break;
                                    case 4834:
                                    case 3400:
                                    case 2909:
                                    case 2910:
                                        new BountyRewardQuest(190).addLoot(looter);
                                        break;
                                    case 3668:
                                        looter.Loot.AddItem(new DroppedItem(17117, 1));
                                        new BountyRewardQuest(200).addLoot(looter);
                                        break;
                                    case 3761:
                                        looter.Loot.AddItem(new DroppedItem(15551, 1));
                                        new BountyRewardQuest(200).addLoot(looter);
                                        break;
                                    case 4506:
                                    case 4507:
                                    case 4532:
                                    case 3851:
                                    case 4328:
                                    case 4329:
                                    case 4330:
                                    case 3403:
                                    case 3402:
                                    case 3373:
                                    case 3413:
                                        new BountyRewardQuest(200).addLoot(looter);
                                        break;
                                    default:
                                        break;
                                }
                            }
                        }

                        #endregion

                        #region Viandes

                        #endregion

                    }



                    if (looter is IExperienceResult)
                    {
                        var winXP = FightFormulas.CalculateWinExp(looter, team.GetAllFighters<CharacterFighter>(), droppers);

                        var biggestwave = DefendersTeam.m_wavesFighters.OrderByDescending(x => x.WaveNumber).FirstOrDefault();
                        if (biggestwave != null)
                            winXP = FightFormulas.CalculateWinExp(looter, team.GetAllFighters<CharacterFighter>(), droppers, (biggestwave.WaveNumber + 1));

                        winXP = (long)(winXP * finalBonus);
                        this.AgeBonus = (short)((finalBonus * 100) - 100);
                        if (looter is FightPlayerResult)
                        {
                            if ((looter as FightPlayerResult).Character.WorldAccount.Vip >= 2)
                            {
                                winXP = (long)(winXP * Rates.VipBonusXp);
                            }
                        }
                        
                        (looter as IExperienceResult).AddEarnedExperience(team == Winners ? winXP : (long)Math.Round(winXP * 0.10));

                        if (FighterPlaying.Fight.DefendersTeam.Fighters.Any(x => x.Level >= 120))
                        {
                            if (looter is FightPlayerResult)
                            {
                                (looter as FightPlayerResult).Character.Record.WinPvm++;
                            }
                        }
                    }
                }
            }

            if (Winners == null || Draw)
            {
                return results;
            }

            else if (DefendersTeam.Fighters.Any(x => x is MonsterFighter && (x as MonsterFighter).Monster.Nani))
            {
                var NaniMonster = Map.NaniMonster;
                if (NaniMonster == null) return results;

                MonsterNaniManager.Instance.ResetSpawn(Map.NaniMonster);
                Map.NaniMonster = null;

                var characters = Winners.Fighters.OfType<CharacterFighter>();
                if (characters.Count() < 1) return results;

                if (Winners.TeamType == TeamTypeEnum.TEAM_TYPE_PLAYER) World.Instance.SendAnnounce("<b>" + string.Join(",", characters.Select(x => x.Name)) + "</b> ont vaincu : <b>" + NaniMonster.Template.Name + "</b>.");

            }
            return results;
        }

        protected override void SendGameFightJoinMessage(CharacterFighter fighter)
        {
            ContextHandler.SendGameFightJoinMessage(fighter.Character.Client, true, true, IsStarted, IsStarted ? 0 : (int)GetPlacementTimeLeft().TotalMilliseconds / 100, FightType);
        }

        protected override bool CanCancelFight() => false;

        public override TimeSpan GetPlacementTimeLeft()
        {
            var timeleft = FightConfiguration.PlacementPhaseTime - (DateTime.Now - CreationTime).TotalMilliseconds;

            if (timeleft < 0)
                timeleft = 0;

            return TimeSpan.FromMilliseconds(timeleft);
        }

        protected override void OnDisposed()
        {
            if (m_placementTimer != null)
                m_placementTimer.Dispose();

            base.OnDisposed();
        }

        private void dropKey(IEnumerable<IFightResult> looters, DroppedItem droppedItem, Random random)
        {

            int rand = random.Next(800);
            if (rand == 1)
            {
                foreach (var looter in looters)
                {
                    looter.Loot.AddItem(droppedItem);
                }
            }
        }
        private void dropPetLoot(IEnumerable<IFightResult> looters, DroppedItem droppedItem, Random random1)
        {

            int rand = random1.Next(2000);
            if (rand == 1)
            {
                foreach (var looter in looters)
                {
                    looter.Loot.AddItem(droppedItem);
                }
            }
        }
        private void dropFoodLoot(IEnumerable<IFightResult> looters, DroppedItem droppedItem, Random random2)
        {

            int rand = random2.Next(64);
            if (rand == 1)
            {
                foreach (var looter in looters)
                {
                    looter.Loot.AddItem(droppedItem);
                }
            }
        }

        private void dropItem(IFightResult looter, DroppedItem droppedItem, CryptoRandom cryptoRandom, int maxLuck)
        {
            int rand = cryptoRandom.Next(maxLuck);
            if (rand == 1)
            {
                looter.Loot.AddItem(droppedItem);
            }
        }
        private void dropKeyasylium(IEnumerable<IFightResult> looters, DroppedItem droppedItem)
        {
            foreach (var looter in looters)
            {
                looter.Loot.AddItem(droppedItem);
            }
        }
        private void dropDofus(IFightResult looter, DroppedItem droppedItem, CryptoRandom cryptoRandomDofus, int Luck)
        {

            int rand = cryptoRandomDofus.Next(Luck);
            if (rand == 1)
            {

                looter.Loot.AddItem(droppedItem);

            }
        }
    }
}
