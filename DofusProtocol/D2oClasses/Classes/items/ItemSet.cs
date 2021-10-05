using System;
using System.Collections.Generic;
using Stump.DofusProtocol.D2oClasses.Tools.D2o;

namespace Stump.DofusProtocol.D2oClasses
{
    [D2OClass("ItemSet", "com.ankamagames.dofus.datacenter.items")]
    [Serializable]
    public class ItemSet : IDataObject, IIndexedData
    {
        public const string MODULE = "ItemSets";
        public bool bonusIsSecret;
        public List<List<EffectInstance>> effects;
        public uint id;
        public List<uint> items;

        [I18NField] public uint nameId;

        [D2OIgnore]
        public uint Id
        {
            get => id;
            set => id = value;
        }

        [D2OIgnore]
        public List<uint> Items
        {
            get => items;
            set => items = value;
        }

        [D2OIgnore]
        public uint NameId
        {
            get => nameId;
            set => nameId = value;
        }

        [D2OIgnore]
        public List<List<EffectInstance>> Effects
        {
            get => effects;
            set => effects = value;
        }

        [D2OIgnore]
        public bool BonusIsSecret
        {
            get => bonusIsSecret;
            set => bonusIsSecret = value;
        }

        int IIndexedData.Id => (int) id;
    }
}