using System;
using Stump.DofusProtocol.D2oClasses.Tools.D2o;

namespace Stump.DofusProtocol.D2oClasses
{
    [D2OClass("Head", "com.ankamagames.dofus.datacenter.breeds")]
    [Serializable]
    public class Head : IDataObject, IIndexedData
    {
        public const string MODULE = "Heads";
        public string assetId;
        public uint breed;
        public uint gender;
        public int id;
        public string label;
        public uint order;
        public string skins;

        [D2OIgnore]
        public int Id
        {
            get => id;
            set => id = value;
        }

        [D2OIgnore]
        public string Skins
        {
            get => skins;
            set => skins = value;
        }

        [D2OIgnore]
        public string AssetId
        {
            get => assetId;
            set => assetId = value;
        }

        [D2OIgnore]
        public uint Breed
        {
            get => breed;
            set => breed = value;
        }

        [D2OIgnore]
        public uint Gender
        {
            get => gender;
            set => gender = value;
        }

        [D2OIgnore]
        public string Label
        {
            get => label;
            set => label = value;
        }

        [D2OIgnore]
        public uint Order
        {
            get => order;
            set => order = value;
        }

        int IIndexedData.Id => id;
    }
}