using System;
using System.Collections.Generic;
using Stump.DofusProtocol.D2oClasses.Tools.D2o;

namespace Stump.DofusProtocol.D2oClasses
{
    [D2OClass("SmileyPack", "com.ankamagames.dofus.datacenter.communication")]
    [Serializable]
    public class SmileyPack : IDataObject, IIndexedData
    {
        public const string MODULE = "SmileyPacks";
        public uint id;

        [I18NField] public uint nameId;

        public uint order;
        public List<uint> smileys;

        [D2OIgnore]
        public uint Id
        {
            get => id;
            set => id = value;
        }

        [D2OIgnore]
        public uint NameId
        {
            get => nameId;
            set => nameId = value;
        }

        [D2OIgnore]
        public uint Order
        {
            get => order;
            set => order = value;
        }

        [D2OIgnore]
        public List<uint> Smileys
        {
            get => smileys;
            set => smileys = value;
        }

        int IIndexedData.Id => (int) id;
    }
}