using System;
using Stump.DofusProtocol.D2oClasses.Tools.D2o;

namespace Stump.DofusProtocol.D2oClasses
{
    [D2OClass("MapScrollAction", "com.ankamagames.dofus.datacenter.world")]
    [Serializable]
    public class MapScrollAction : IDataObject, IIndexedData
    {
        public const string MODULE = "MapScrollActions";
        public bool bottomExists;
        public double bottomMapId;
        public double id;
        public bool leftExists;
        public double leftMapId;
        public bool rightExists;
        public double rightMapId;
        public bool topExists;
        public double topMapId;

        [D2OIgnore]
        public double Id
        {
            get => id;
            set => id = value;
        }

        [D2OIgnore]
        public bool RightExists
        {
            get => rightExists;
            set => rightExists = value;
        }

        [D2OIgnore]
        public bool BottomExists
        {
            get => bottomExists;
            set => bottomExists = value;
        }

        [D2OIgnore]
        public bool LeftExists
        {
            get => leftExists;
            set => leftExists = value;
        }

        [D2OIgnore]
        public bool TopExists
        {
            get => topExists;
            set => topExists = value;
        }

        [D2OIgnore]
        public double RightMapId
        {
            get => rightMapId;
            set => rightMapId = value;
        }

        [D2OIgnore]
        public double BottomMapId
        {
            get => bottomMapId;
            set => bottomMapId = value;
        }

        [D2OIgnore]
        public double LeftMapId
        {
            get => leftMapId;
            set => leftMapId = value;
        }

        [D2OIgnore]
        public double TopMapId
        {
            get => topMapId;
            set => topMapId = value;
        }

        int IIndexedData.Id => (int) id;
    }
}