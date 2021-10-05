using System;
using Stump.DofusProtocol.D2oClasses.Tools.D2o;

namespace Stump.DofusProtocol.D2oClasses
{
    [D2OClass("HavenbagTheme", "com.ankamagames.dofus.datacenter.houses")]
    [Serializable]
    public class HavenbagTheme : IDataObject, IIndexedData
    {
        public const string MODULE = "HavenbagThemes";
        public int id;
        public double mapId;

        [I18NField] public int nameId;

        [D2OIgnore]
        public int Id
        {
            get => id;
            set => id = value;
        }

        [D2OIgnore]
        public int NameId
        {
            get => nameId;
            set => nameId = value;
        }

        [D2OIgnore]
        public double MapId
        {
            get => mapId;
            set => mapId = value;
        }

        int IIndexedData.Id => id;
    }
}