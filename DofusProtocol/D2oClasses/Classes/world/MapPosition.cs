using System;
using System.Collections.Generic;
using Stump.DofusProtocol.D2oClasses.Tools.D2o;

namespace Stump.DofusProtocol.D2oClasses
{
    [D2OClass("MapPosition", "com.ankamagames.dofus.datacenter.world")]
    [Serializable]
    public class MapPosition : IDataObject, IIndexedData
    {
        public const string MODULE = "MapPositions";
        public bool allowPrism;
        public int capabilities;
        public bool hasPriorityOnWorldmap;
        public double id;
        public bool isTransition;

        [I18NField] public int nameId;

        public bool outdoor;
        public List<List<int>> playlists;
        public int posX;
        public int posY;
        public bool showNameOnFingerpost;
        public List<AmbientSound> sounds;
        public int subAreaId;
        public uint tacticalModeTemplateId;
        public int worldMap;

        [D2OIgnore]
        public double Id
        {
            get => id;
            set => id = value;
        }

        [D2OIgnore]
        public int PosX
        {
            get => posX;
            set => posX = value;
        }

        [D2OIgnore]
        public int PosY
        {
            get => posY;
            set => posY = value;
        }

        [D2OIgnore]
        public bool Outdoor
        {
            get => outdoor;
            set => outdoor = value;
        }

        [D2OIgnore]
        public int Capabilities
        {
            get => capabilities;
            set => capabilities = value;
        }

        [D2OIgnore]
        public int NameId
        {
            get => nameId;
            set => nameId = value;
        }

        [D2OIgnore]
        public bool ShowNameOnFingerpost
        {
            get => showNameOnFingerpost;
            set => showNameOnFingerpost = value;
        }

        [D2OIgnore]
        public List<AmbientSound> Sounds
        {
            get => sounds;
            set => sounds = value;
        }

        [D2OIgnore]
        public List<List<int>> Playlists
        {
            get => playlists;
            set => playlists = value;
        }

        [D2OIgnore]
        public int SubAreaId
        {
            get => subAreaId;
            set => subAreaId = value;
        }

        [D2OIgnore]
        public int WorldMap
        {
            get => worldMap;
            set => worldMap = value;
        }

        [D2OIgnore]
        public bool HasPriorityOnWorldmap
        {
            get => hasPriorityOnWorldmap;
            set => hasPriorityOnWorldmap = value;
        }

        [D2OIgnore]
        public bool AllowPrism
        {
            get => allowPrism;
            set => allowPrism = value;
        }

        [D2OIgnore]
        public bool IsTransition
        {
            get => isTransition;
            set => isTransition = value;
        }

        [D2OIgnore]
        public uint TacticalModeTemplateId
        {
            get => tacticalModeTemplateId;
            set => tacticalModeTemplateId = value;
        }

        int IIndexedData.Id => (int) id;
    }
}