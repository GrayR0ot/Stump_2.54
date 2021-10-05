﻿using Stump.ORM;
using Stump.ORM.SubSonic.SQLGeneration.Schema;
using Stump.Server.WorldServer.Game.Arena;

namespace Stump.Server.WorldServer.Database.Arena
{
    public class ArenaLeagueRelator
    {
        public static string FetchQuery = "SELECT * FROM arena_leagues";
    }

    [TableName("arena_leagues")]
    public class ArenaLeague : IAssignedByD2O, IAutoGeneratedRecord
    {
        [PrimaryKey("Id")] public int Id { get; set; }

        public int LeagueId { get; set; }

        public uint NameId { get; set; }

        public uint OrnamentId { get; set; }

        public string Icon { get; set; }

        public string Illus { get; set; }

        public bool IsLastLeague { get; set; }

        public string Name { get; set; }

        public int TypeId { get; set; }

        public int NextLeagueId { get; set; }

        [Ignore] public LeaguesEnum Type => (LeaguesEnum) TypeId;

        [Ignore] public int MinRequiredRank { get; set; }

        [Ignore] public int MaxRequiredRank { get; set; }

        public void AssignFields(object obj)
        {
            var league = (DofusProtocol.D2oClasses.ArenaLeague) obj;
            LeagueId = league.Id;
            NameId = league.NameId;
            OrnamentId = league.OrnamentId;
            Icon = league.Icon;
            Illus = league.Illus;
            IsLastLeague = league.IsLastLeague;
        }
    }
}