﻿using System;
using System.Collections.Generic;
using System.Linq;
using Stump.Core.Attributes;
using Stump.Server.WorldServer.Game.Actors.RolePlay.Characters;

namespace Stump.Server.WorldServer.Game.Arena
{
    public class ArenaQueueMember
    {
        [Variable] public static int ArenaMargeIncreasePerMinutes = 30;

        [Variable(true, DefinableRunning = true)]
        public static bool ArenaCheckIP = true;

        public ArenaQueueMember(Character character, int mode)
        {
            Character = character;
            InQueueSince = DateTime.Now;
            character.ArenaMode = mode;
        }

        public ArenaQueueMember(ArenaParty party)
        {
            Party = party;
            InQueueSince = DateTime.Now;
        }

        public Character Character { get; }

        public ArenaParty Party { get; }

        public int Level => Party != null ? Party.GroupLevelAverage : Character.Level;

        public int ArenaRank => Party != null ? Party.GroupRankAverage :
            Character.ArenaMode == 1 ? Character.ArenaRank_1vs1 : Character.ArenaRank_3vs3;

        public int MaxMatchableRank =>
            (int) (ArenaRank + ArenaMargeIncreasePerMinutes * (DateTime.Now - InQueueSince).TotalMinutes);

        public int MinMatchableRank =>
            (int) (ArenaRank - ArenaMargeIncreasePerMinutes * (DateTime.Now - InQueueSince).TotalMinutes);

        public DateTime InQueueSince { get; set; }

        public int MembersCount => Party != null ? Party.MembersCount : 1;

        public bool IsBusy()
        {
            return EnumerateCharacters().Any(x => !x.CanEnterArena(false));
        }

        public IEnumerable<Character> EnumerateCharacters()
        {
            return Party != null ? Party.Members : Enumerable.Repeat(Character, 1);
        }

        public bool IsCompatibleWith(ArenaQueueMember member, bool isAlone)
        {
            if (isAlone && member.EnumerateCharacters()
                .Any(x => EnumerateCharacters().Any(y => y.CharacterToSeekName == x.Account.Nickname)))
                return false;
            return Math.Max(member.MinMatchableRank, MinMatchableRank) <=
                   Math.Max(member.MaxMatchableRank, MaxMatchableRank)
                   && (member.Character.Experience >= 5555424000 ||
                       Math.Abs(member.Level - Level) < ArenaManager.ArenaMaxLevelDifference) && (!ArenaCheckIP ||
                       !member.EnumerateCharacters()
                           .Any(x => EnumerateCharacters().Any(y => y.Client.IP == x.Client.IP)))
                   && member.Character?.ArenaMode == Character?.ArenaMode;
        }
    }
}