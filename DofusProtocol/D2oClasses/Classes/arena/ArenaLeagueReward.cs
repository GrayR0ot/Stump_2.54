using System;
using System.Collections.Generic;
using Stump.DofusProtocol.D2oClasses.Tools.D2o;

namespace Stump.DofusProtocol.D2oClasses
{
    [D2OClass("ArenaLeagueReward", "com.ankamagames.dofus.datacenter.arena")]
    [Serializable]
    public class ArenaLeagueReward : IDataObject, IIndexedData
    {
        public const string MODULE = "ArenaLeagueRewards";
        public bool endSeasonRewards;
        public int id;
        public uint leagueId;
        public uint seasonId;
        public List<uint> titlesRewards;

        [D2OIgnore]
        public int Id
        {
            get => id;
            set => id = value;
        }

        [D2OIgnore]
        public uint SeasonId
        {
            get => seasonId;
            set => seasonId = value;
        }

        [D2OIgnore]
        public uint LeagueId
        {
            get => leagueId;
            set => leagueId = value;
        }

        [D2OIgnore]
        public List<uint> TitlesRewards
        {
            get => titlesRewards;
            set => titlesRewards = value;
        }

        [D2OIgnore]
        public bool EndSeasonRewards
        {
            get => endSeasonRewards;
            set => endSeasonRewards = value;
        }

        int IIndexedData.Id => id;
    }
}