using Stump.Core.Attributes;
using Stump.Core.Mathematics;
using Stump.DofusProtocol.Enums;
using Stump.ORM.SubSonic.Extensions;
using Stump.Server.WorldServer.Game.Actors.Fight;
using Stump.Server.WorldServer.Game.Actors.RolePlay.Characters;
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
using ServiceStack.Text;

namespace Stump.Server.WorldServer.Game.Fights
{
    public class FightPvM : Fight<FightMonsterTeam, FightPlayerTeam>
    {
        [Variable] public static int MaxClassesCountPairFight = 4;

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

            /*if (Map.IsDungeon())
            {
                foreach (var fighter in Fighters.OfType<CharacterFighter>())
                    fighter.Character.Record.BackDungeon = Map.Id;
            }*/

            void initChallenge()
            {
                for (int i = 0; i < (Map.IsDungeon() ? 2 : 1); i++)
                {
                    var challenge = ChallengeManager.Instance.GetRandomChallenge(this);

                    // no challenge found
                    if (challenge == null)
                        return;

                    challenge.Initialize();
                    AddChallenge(challenge);
                }
            }
        }

        public FightPlayerTeam PlayerTeam =>
            Teams.FirstOrDefault(x => x.TeamType == TeamTypeEnum.TEAM_TYPE_PLAYER) as FightPlayerTeam;

        public FightMonsterTeam MonsterTeam =>
            Teams.FirstOrDefault(x => x.TeamType == TeamTypeEnum.TEAM_TYPE_MONSTER) as FightMonsterTeam;

        public override FightTypeEnum FightType => FightTypeEnum.FIGHT_TYPE_PvM;

        public override bool IsPvP => false;

        public bool IsPvMArenaFight { get; set; }

        protected override List<IFightResult> GetResults()
        {
            var results = new List<IFightResult>();
            results.AddRange(GetFightersAndLeavers().Where(entry => entry.HasResult)
                .Select(entry => entry.GetFightResult()));

            var taxCollectors = Map.SubArea.Maps.Select(x => x.TaxCollector)
                .Where(x => x != null && x.CanGatherLoots());
            results.AddRange(taxCollectors.Select(x => new TaxCollectorProspectingResult(x, this)));

            foreach (var team in m_teams)
            {
                IEnumerable<FightActor> droppers =
                    team.OpposedTeam.GetAllFighters(entry => entry.IsDead() && entry.CanDrop()).ToList();

                var looters = results.Where(x => x.CanLoot(team) && !(x is TaxCollectorProspectingResult))
                    .OrderByDescending(entry => entry.Prospecting).Concat(results
                        .OfType<TaxCollectorProspectingResult>().Where(x => x.CanLoot(team))
                        .OrderByDescending(x => x.Prospecting)); // tax collector loots at the end

                var teamPP = team.GetAllFighters<CharacterFighter>().Sum(entry =>
                    (entry.Stats[PlayerFields.Prospecting].Total >= 100)
                        ? 100
                        : entry.Stats[PlayerFields.Prospecting].Total);

                var looterx = looters.ToList();

                var kamas = Winners == team
                    ? droppers.Sum(entry => entry.GetDroppedKamas()) * team.GetAllFighters<CharacterFighter>().Count()
                    : 0;

                CryptoRandom cryptoRandom = new CryptoRandom();

                foreach (var looter in looters)
                {
                    if (team == Winners && looter is FightPlayerResult)
                    {
                        Character character = (looter as FightPlayerResult).Character;
                        //SAVE DUNGEON
                        /*if (character.Record.BackDungeon == Map.Id)
                            character.Record.BackDungeon = 0;*/

                        looter.Loot.Kamas =
                            FightFormulas.CalculateEarnedKamas(looter, team.GetAllFighters(), droppers) *
                            (character.WorldAccount.Vip >= 1 ? 3 : 1);
                    }

                    if (team == Winners)
                    {
                        foreach (var item in droppers.SelectMany(dropper => dropper.RollLoot(looter)))
                        {
                            var ipDropped = false;
                            foreach (var currentLooter in looters)
                            {
                                if (!(currentLooter is TaxCollectorProspectingResult) &&
                                    (!(looter is TaxCollectorProspectingResult)))
                                {
                                    if (currentLooter is FightPlayerResult &&
                                        (currentLooter as FightPlayerResult).Character != null)
                                    {
                                        Character currentCharacter = (currentLooter as FightPlayerResult).Character;
                                        if (currentCharacter.IsIpDrop)
                                        {
                                            if (currentCharacter.Client != null && currentCharacter.Client.IP != null)
                                            {
                                                if (currentCharacter.Client.IP ==
                                                    (looter as FightPlayerResult).Character.Client.IP)
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

                        #region Doplons

                        foreach (var monster in this.DefendersTeam.GetAllFighters())
                        {
                            if (monster is MonsterFighter)
                            {
                                if ((monster as MonsterFighter).Monster.Template.Id != 494 && monster.SubArea.Id == 62)
                                {
                                    double amount = (10 / ChallengersTeam.GetAllFighters().Count());
                                    looter.Loot.AddItem(new DroppedItem(13052, (uint) amount));
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
                    }


                    if (looter is IExperienceResult)
                    {
                        var winXP = FightFormulas.CalculateWinExp(looter, team.GetAllFighters<CharacterFighter>(),
                            droppers);

                        var biggestwave = DefendersTeam.m_wavesFighters.OrderByDescending(x => x.WaveNumber)
                            .FirstOrDefault();
                        if (biggestwave != null)
                            winXP = FightFormulas.CalculateWinExp(looter, team.GetAllFighters<CharacterFighter>(),
                                droppers, (biggestwave.WaveNumber + 1));

                        double bonus = (((double) Map.SubArea.Bonus + 100) / 100);
                        winXP = (long) (winXP * bonus);
                        this.Bonus = (short) ((bonus * 100) - 100);
                        if (looter is FightPlayerResult)
                        {
                            if ((looter as FightPlayerResult).Character.WorldAccount.Vip >= 2)
                            {
                                winXP = (long) (winXP * Rates.VipBonusXp);
                            }
                        }

                        (looter as IExperienceResult).AddEarnedExperience(team == Winners
                            ? winXP
                            : (long) Math.Round(winXP * 0.10));

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

            return results;
        }

        protected override void SendGameFightJoinMessage(CharacterFighter fighter)
        {
            ContextHandler.SendGameFightJoinMessage(fighter.Character.Client, true, true, IsStarted,
                IsStarted ? 0 : (int) GetPlacementTimeLeft().TotalMilliseconds / 100, FightType);
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