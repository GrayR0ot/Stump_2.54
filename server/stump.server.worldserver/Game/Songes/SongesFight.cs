using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Stump.Core.Extensions;
using Stump.Core.Mathematics;
using Stump.DofusProtocol.Enums;
using Stump.DofusProtocol.Types;
using Stump.Server.WorldServer.Game.Actors.Fight;
using Stump.Server.WorldServer.Game.Actors.RolePlay.Characters;
using Stump.Server.WorldServer.Game.Effects.Handlers.Spells.Buffs;
using Stump.Server.WorldServer.Game.Effects.Instances;
using Stump.Server.WorldServer.Game.Fights;
using Stump.Server.WorldServer.Game.Fights.Buffs;
using Stump.Server.WorldServer.Game.Fights.Buffs.Customs;
using Stump.Server.WorldServer.Game.Fights.Challenges;
using Stump.Server.WorldServer.Game.Fights.Results;
using Stump.Server.WorldServer.Game.Fights.Teams;
using Stump.Server.WorldServer.Game.Formulas;
using Stump.Server.WorldServer.Game.Items;
using Stump.Server.WorldServer.Game.Maps;
using Stump.Server.WorldServer.Game.Maps.Cells;
using Stump.Server.WorldServer.Handlers.Characters;
using Stump.Server.WorldServer.Handlers.Context;

namespace Stump.Server.WorldServer.Game.Songes
{
    public class SongesFight : Fight<FightMonsterTeam, FightPlayerTeam>
    {
        private int step;
        private Character leader;

        public SongesFight(int id, Character leader, Map fightMap, FightMonsterTeam defendersTeam,
            FightPlayerTeam challengersTeam,
            int step) :
            base(id, fightMap, defendersTeam, challengersTeam)
        {
            this.leader = leader;
            this.step = step;
        }

        public FightPlayerTeam PlayerTeam =>
            Teams.FirstOrDefault(x => x.TeamType == TeamTypeEnum.TEAM_TYPE_PLAYER) as FightPlayerTeam;

        public FightMonsterTeam MonsterTeam =>
            Teams.FirstOrDefault(x => x.TeamType == TeamTypeEnum.TEAM_TYPE_MONSTER) as FightMonsterTeam;

        public override FightTypeEnum FightType => FightTypeEnum.FIGHT_TYPE_BREACH;

        public override bool IsPvP => false;

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

        protected override void OnFightEnded()
        {
            foreach (var entry in this.ChallengersTeam.Fighters)
            {
                if (entry is CharacterFighter)
                {
                    Character character = (entry as CharacterFighter).Character;
                    Task.Delay(1000).ContinueWith(t =>
                    {
                        Map map = World.Instance.GetMap(195561472);
                        character.Teleport(new ObjectPosition(map, 300, character.Direction));
                    });
                }
            }
            leader.songesStep++;
            leader.songesBranches = SongeBranches.generateSongeBranches(leader);
            leader.songesBuyables = new BreachReward[]{};
            foreach (var boost in leader.currentSongeRoom.Rewards)
            {
                leader.songesBuyables = leader.songesBuyables.Add(boost);
            }
            if (leader.songesStep >= 201)
            {
                leader.songesBuyables = new BreachReward[]{};
                leader.OpenPopup("Vous venez de terminer votre run songes ! Retour à la salle 1 !");
                leader.songesStep = 1;
            }
            base.OnFightEnded();
        }
        
        protected override void OnFightStarted()
        {
            base.OnFightStarted();
            initChallenge();

            foreach (var characterFighter in this.ChallengersTeam.Fighters)
            {
                if (characterFighter is CharacterFighter)
                {
                    Character character = (characterFighter as CharacterFighter).Character;
                    foreach (var boost in leader.songesBoosts)
                    {
                        switch (boost.TypeId)
                        {
                            case 99:
                            case 113:
                            case 127:
                                character.Stats[PlayerFields.TackleEvade].Additional += (int)boost.Value;
                                break;
                            case 100:
                            case 114:
                            case 128:
                                character.Stats[PlayerFields.TackleBlock].Additional += (int)boost.Value;
                                break;
                            case 6:
                            case 103:
                            case 117:
                                character.Stats[PlayerFields.Intelligence].Additional += (int)boost.Value;
                                break;
                            case 7:
                            case 104:
                            case 118:
                                character.Stats[PlayerFields.Chance].Additional += (int)boost.Value;
                                break;
                            case 91:
                            case 105:
                            case 119:
                                character.Stats[PlayerFields.Agility].Additional += (int)boost.Value;
                                break;
                            case 92:
                            case 106:
                            case 120:
                                character.Stats[PlayerFields.Strength].Additional += (int)boost.Value;
                                break;
                            case 93:
                            case 107:
                            case 121:
                                character.Stats[PlayerFields.Vitality].Additional += (int)boost.Value;
                                break;
                            case 94:
                            case 108:
                            case 122:
                                character.Stats[PlayerFields.DamageBonus].Additional += (int)boost.Value;
                                break;
                            case 95:
                            case 109:
                            case 123:
                                character.Stats[PlayerFields.APAttack].Additional += (int)boost.Value;
                                break;
                            case 96:
                            case 110:
                            case 124:
                                character.Stats[PlayerFields.MPAttack].Additional += (int)boost.Value;
                                break;
                            default:
                                break;
                        }
                        characterFighter.Stats[PlayerFields.Agility].Additional = 9999;
                    }
                }
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

            if (!(team is FightMonsterTeam))
                return;
        }

        protected override List<IFightResult> GetResults()
        {
            var cryptoRandom = new CryptoRandom();
            var results = new List<IFightResult>();
            Character leader = this.leader;
            results.AddRange(GetFightersAndLeavers().Where(entry => entry.HasResult)
                .Select(entry => entry.GetFightResult()));
            {
                foreach (var team in m_teams)
                {
                    IEnumerable<FightActor> droppers = team.OpposedTeam
                        .GetAllFighters(entry => entry.IsDead() && entry.CanDrop()).ToList();
                    var looters = results.Where(x => x.CanLoot(team) && !(x is TaxCollectorProspectingResult))
                        .OrderByDescending(entry => entry.Prospecting).Concat(results
                            .OfType<TaxCollectorProspectingResult>().Where(x => x.CanLoot(team))
                            .OrderByDescending(x => x.Prospecting)); // tax collector loots at the end

                    foreach (var looter in looters)
                        if (team == Winners && looter is FightPlayerResult)
                        {
                            if (leader.songesStep < 200)
                            {
                                if (leader.songesStep % 5 == 0)
                                {
                                    if (leader.songesStep >= 150)
                                        looter.Loot.AddItem(new DroppedItem(31266, 1));
                                    else if (leader.songesStep >= 100)
                                        looter.Loot.AddItem(new DroppedItem(31263, 1));
                                    else if (leader.songesStep >= 50)
                                        looter.Loot.AddItem(new DroppedItem(31260, 1));
                                    else
                                        looter.Loot.AddItem(new DroppedItem(31257, 1));
                                }
                                else
                                {
                                    dropRandomSimpleChest(looter, leader, cryptoRandom);
                                }
                            }

                            if (looter is IExperienceResult)
                            {
                                var winXP = FightFormulas.CalculateWinExp(looter,
                                    team.GetAllFighters<CharacterFighter>(), droppers);

                                var biggestwave = DefendersTeam.m_wavesFighters.OrderByDescending(x => x.WaveNumber)
                                    .FirstOrDefault();
                                if (biggestwave != null)
                                    winXP = FightFormulas.CalculateWinExp(looter,
                                        team.GetAllFighters<CharacterFighter>(), droppers,
                                        biggestwave.WaveNumber + 1);
                                if (looter is FightPlayerResult)
                                    if ((looter as FightPlayerResult).Character.WorldAccount.Vip >= 2)
                                        winXP = (long) (winXP * Rates.VipBonusXp);

                                (looter as IExperienceResult).AddEarnedExperience(team == Winners
                                    ? winXP
                                    : (long) Math.Round(winXP * 0.10));

                                if (FighterPlaying.Fight.DefendersTeam.Fighters.Any(x => x.Level >= 120))
                                    if (looter is FightPlayerResult)
                                        (looter as FightPlayerResult).Character.Record.WinPvm++;
                            }
                        }

                    if (Winners == null || Draw) return results;
                }
            }
            this.leader.songesBudget += 100;
            return results;
        }

        protected override void SendGameFightJoinMessage(CharacterFighter fighter)
        {
            ContextHandler
                .SendGameFightJoinMessage(fighter.Character.Client, true, true, IsStarted,
                    IsStarted ? 0 : (int) GetPlacementTimeLeft().TotalMilliseconds / 100, FightType);
        }

        protected override bool CanCancelFight()
        {
            return false;
        }

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

        public void dropRandomSimpleChest(IFightResult fightResult, Character character, CryptoRandom cryptoRandom)
        {
            switch (cryptoRandom.Next(2))
            {
                case 0:
                    if (character.songesStep >= 150)
                        fightResult.Loot.AddItem(new DroppedItem(31265, 1));
                    else if (character.songesStep >= 100)
                        fightResult.Loot.AddItem(new DroppedItem(31265, 1));
                    else if (character.songesStep >= 50)
                        fightResult.Loot.AddItem(new DroppedItem(31259, 1));
                    else
                        fightResult.Loot.AddItem(new DroppedItem(31256, 1));
                    break;
                default:
                    if (character.songesStep >= 150)
                        fightResult.Loot.AddItem(new DroppedItem(31264, 1));
                    else if (character.songesStep >= 100)
                        fightResult.Loot.AddItem(new DroppedItem(31261, 1));
                    else if (character.songesStep >= 50)
                        fightResult.Loot.AddItem(new DroppedItem(31258, 1));
                    else
                        fightResult.Loot.AddItem(new DroppedItem(31255, 1));
                    break;
            }
        }
    }
}