using System;
using System.Collections.Generic;
using System.Linq;
using Stump.DofusProtocol.Enums;
using Stump.DofusProtocol.Types;
using Stump.Server.WorldServer.Game.Actors.Fight;
using Stump.Server.WorldServer.Game.Actors.RolePlay.Characters;
using Stump.Server.WorldServer.Game.Actors.RolePlay.Monsters;
using Stump.Server.WorldServer.Game.Fights.Results.Data;
using Stump.Server.WorldServer.Game.Fights.Teams;
using Stump.Server.WorldServer.Game.Formulas;
using Stump.Server.WorldServer.Game.Guilds;
using Stump.Server.WorldServer.Game.Items;
using Stump.Server.WorldServer.Game.Items.Player;
using Stump.Server.WorldServer.Handlers.Characters;
using Stump.Server.WorldServer.Handlers.Inventory;

namespace Stump.Server.WorldServer.Game.Fights.Results
{
    public class FightPlayerResult : FightResult<CharacterFighter>, IExperienceResult, IPvpResult
    {
        public FightPlayerResult(CharacterFighter fighter, FightOutcomeEnum outcome, FightLoot loot)
            : base(fighter, outcome, loot)
        {
        }

        public Character Character => Fighter.Character;
        protected FightTeam[] m_teams;
        public new ushort Level => Character.Level;

        public override bool CanLoot(FightTeam team) => Fighter.Team == team && (!Fighter.HasLeft() || Fighter.IsDisconnected);

        public FightExperienceData ExperienceData
        {
            get;
            private set;
        }

        public FightExperienceDataLos ExperienceDatalos
        {
            get;
            private set;
        }

        public FightPvpData PvpData
        {
            get;
            private set;
        }


        public override FightResultListEntry GetFightResultListEntry()
        {
            var additionalDatas = new List<DofusProtocol.Types.FightResultAdditionalData>();

            if (ExperienceData != null)
                additionalDatas.Add(ExperienceData.GetFightResultAdditionalData());
                 


            if (ExperienceDatalos != null)
                additionalDatas.Remove(ExperienceDatalos.GetFightResultAdditionalData());

            if (PvpData != null)
                additionalDatas.Add(PvpData.GetFightResultAdditionalData());

            return new FightResultPlayerListEntry((ushort)Outcome, 0, Loot.GetFightLoot(), Id, Alive, (ushort)Level,
                additionalDatas.ToArray());
        }
        #region loot kamas
        public override void Apply()
        {
            Character.Inventory.AddKamas((ulong)Loot.Kamas);

            foreach (var drop in Loot.Items.Values)
            {
                // just diplay purpose
                if (drop.IgnoreGeneration)
                    continue;

                var template = ItemManager.Instance.TryGetTemplate(drop.ItemId);

                if (template != null && template.Effects != null && template.Effects.Count > 0)
                    for (var i = 0; i < drop.Amount; i++)
                    {
                        var item = ItemManager.Instance.CreatePlayerItem(Character, drop.ItemId, 1);
                        Character.Inventory.AddItem(item, false);
                    }
                else
                {
                    try
                    {
                        var item = ItemManager.Instance.CreatePlayerItem(Character, drop.ItemId, (int)drop.Amount);
                        Character.Inventory.AddItem(item, false);
                    } catch(Exception e)
                    {
                        Console.WriteLine("Unable to create drop with template #" + drop.ItemId);
                    }
                }
            }

            #endregion

            if (ExperienceData != null)
                ExperienceData.Apply();


            if (ExperienceDatalos != null)
                ExperienceDatalos.Apply();

            if (PvpData != null)
            {
                PvpData.Apply();
                Character.SaveLater();
            }

            CharacterHandler.SendCharacterStatsListMessage(Character.Client);
            InventoryHandler.SendInventoryContentMessage(Character.Client);
        }




        public void AddEarnedExperience(long experience)
        {
            if (Fighter.HasLeft() && !Fighter.IsDisconnected)
                return;

            if (ExperienceData == null)
                ExperienceData = new FightExperienceData(Character);


            #region xp dd
            if (Character.IsRiding && Character.EquippedMount.GivenExperience > 0)
            {
                int difference = Math.Min((int) Character.Level, 200) - Character.EquippedMount.Level;
                double rate = 1;
                if (difference >= 70)
                {
                    rate = 0.01;
                } else if (difference >= 61)
                {
                    rate = 0.015;
                } else if (difference >= 51)
                {
                    rate = 0.02;
                } else if (difference >= 41)
                {
                    rate = 0.03;
                } else if (difference >= 31)
                {
                    rate = 0.04;
                } else if (difference >= 21)
                {
                    rate = 0.06;
                } else if (difference >= 11)
                {
                    rate = 0.08;
                }
                else
                {
                    rate = 0.1;
                }
                var xp = (long)(experience * (Character.EquippedMount.GivenExperience * rate));
                var mountXp = (int)Character.EquippedMount.AdjustGivenExperience(Character, xp);

                experience -= xp;
                if (mountXp > 0)
                {
                    ExperienceData.ShowExperienceForMount = true;
                    ExperienceData.ExperienceForMount += mountXp;
                }
            }
            #endregion

            #region xp guilde
            if (Character.GuildMember != null && Character.GuildMember.GivenPercent > 0)
            {
                int difference = Math.Min((int) Character.Level, 200) - Character.Guild.Level;
                double rate = 1;
                if (difference >= 70)
                {
                    rate = 0.01;
                } else if (difference >= 61)
                {
                    rate = 0.015;
                } else if (difference >= 51)
                {
                    rate = 0.02;
                } else if (difference >= 41)
                {
                    rate = 0.03;
                } else if (difference >= 31)
                {
                    rate = 0.04;
                } else if (difference >= 21)
                {
                    rate = 0.06;
                } else if (difference >= 11)
                {
                    rate = 0.08;
                }
                else
                {
                    rate = 0.1;
                }
                var xp = (int)(experience*(Character.GuildMember.GivenPercent * rate));
                var guildXp = (int)Character.Guild.AdjustGivenExperience(Character, xp);

                experience -= xp;
                guildXp = guildXp > Guild.MaxGuildXP ? Guild.MaxGuildXP : guildXp;

                if (guildXp > 0)
                {
                    ExperienceData.ShowExperienceForGuild = true;
                    ExperienceData.ExperienceForGuild += guildXp;
                }
            }
            #endregion

            //VIP
            var multiplicator = 1.0f;
            if (World.Instance.GetCharacters(x => x.Client.IP == Character.Client.IP).ToList().Exists(x => x.WorldAccount.Vip >= 1))
            {
                multiplicator = Rates.VipBonusXp;
            }

            ExperienceData.ShowExperienceFightDelta = true;
            ExperienceData.ShowExperience = true;
            ExperienceData.ShowExperienceLevelFloor = true;
            ExperienceData.ShowExperienceNextLevelFloor = true;
            ExperienceData.ExperienceFightDelta += (long)(experience * multiplicator);
        }

      
        
        public void SetEarnedHonor(short honor, short dishonor)
        {
            if (PvpData == null)
                PvpData = new FightPvpData(Character);

            PvpData.HonorDelta = honor;
            PvpData.DishonorDelta = dishonor;
            PvpData.Honor = Character.Honor;
            PvpData.Dishonor = Character.Dishonor;
            PvpData.Grade = (byte) Character.AlignmentGrade;
            PvpData.MinHonorForGrade = Character.LowerBoundHonor;
            PvpData.MaxHonorForGrade = Character.UpperBoundHonor;
        }
    }
}
 