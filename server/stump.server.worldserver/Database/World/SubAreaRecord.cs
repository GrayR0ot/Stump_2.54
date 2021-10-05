﻿using System.Linq;
using Stump.Core.IO;
using Stump.Core.Reflection;
using Stump.DofusProtocol.D2oClasses.Tools.D2o;
using Stump.ORM;
using Stump.ORM.SubSonic.SQLGeneration.Schema;
using Stump.Server.WorldServer.Database.Achievements;
using Stump.Server.WorldServer.Database.I18n;
using Stump.Server.WorldServer.Game.Achievements;
using Stump.Server.WorldServer.Game.Maps;
using SubArea = Stump.DofusProtocol.D2oClasses.SubArea;

namespace Stump.Server.WorldServer.Database.World
{
    public class SubAreaRecordRelator
    {
        public static string FetchQuery = "SELECT * FROM world_subareas";
    }

    [TableName("world_subareas")]
    [D2OClass("SubArea", "com.ankamagames.dofus.datacenter.world")]
    public sealed class SubAreaRecord : IAssignedByD2O, ISaveIntercepter, IAutoGeneratedRecord
    {
        private AchievementTemplate m_achievement;
        private uint? m_achievementId;
        private uint[] m_customWorldMap;
        private string m_customWorldMapCSV;
        private uint[] m_mapsIds;
        private string m_mapsIdsCSV;
        private string m_name;
        private int[] m_shape;
        private string m_shapeCSV;

        [PrimaryKey("Id", false)] public int Id { get; set; }

        public uint NameId { get; set; }


        public string Name => m_name ?? (m_name = TextManager.Instance.GetText(NameId));

        public int AreaId { get; set; }

        public string MapsIdsCSV
        {
            get => m_mapsIdsCSV;
            set
            {
                m_mapsIdsCSV = value;
                m_mapsIds = value.FromCSV<uint>(",");
            }
        }

        [Ignore]
        public uint[] MapsIds
        {
            get => m_mapsIds;
            set
            {
                m_mapsIds = value;
                m_mapsIdsCSV = value.ToCSV(",");
            }
        }

        public string ShapeCSV
        {
            get => m_shapeCSV;
            set
            {
                m_shapeCSV = value;
                m_shape = value.FromCSV<int>(",");
            }
        }

        [Ignore]
        public int[] Shape
        {
            get => m_shape;
            set
            {
                m_shape = value;
                m_shapeCSV = value.ToCSV(",");
            }
        }

        public string CustomWorldMapCSV
        {
            get => m_customWorldMapCSV;
            set
            {
                m_customWorldMapCSV = value;
                m_customWorldMap = value.FromCSV<uint>(",");
            }
        }

        [Ignore]
        public uint[] CustomWorldMap
        {
            get => m_customWorldMap;
            set
            {
                m_customWorldMap = value;
                m_customWorldMapCSV = value.ToCSV(",");
            }
        }

        public int PackId { get; set; }

        public uint Level { get; set; }

        [DefaultSetting(2)] public Difficulty Difficulty { get; set; }

        [DefaultSetting(3)] public int SpawnsLimit { get; set; }

        public uint? CustomSpawnInterval { get; set; }

        [Ignore]
        public AchievementTemplate Achievement
        {
            get => m_achievement;
            set
            {
                m_achievement = value;
                m_achievementId = value == null ? new uint?() : m_achievement.Id;
            }
        }

        public uint? AchievementId
        {
            get => m_achievementId;
            set
            {
                m_achievementId = value;
                m_achievement = value.HasValue
                    ? Singleton<AchievementManager>.Instance.TryGetAchievement(value.Value)
                    : null;
            }
        }


        #region IAssignedByD2O Members

        public void AssignFields(object d2oObject)
        {
            var subarea = (SubArea) d2oObject;
            Id = subarea.id;
            NameId = subarea.nameId;
            AreaId = subarea.areaId;
            MapsIds = subarea.mapIds.Select(x => (uint) x).ToArray();
            Shape = subarea.shape.ToArray();
            CustomWorldMap = subarea.customWorldMap.ToArray();
            PackId = subarea.packId;
            Difficulty = Difficulty.Normal;
            SpawnsLimit = 3;
            Level = subarea.Level;
        }

        #endregion

        #region ISaveIntercepter Members

        public void BeforeSave(bool insert)
        {
            m_mapsIdsCSV = m_mapsIds.ToCSV(",");
            m_shapeCSV = m_shape.ToCSV(",");
            m_customWorldMapCSV = m_customWorldMap.ToCSV(",");
        }

        #endregion
    }
}