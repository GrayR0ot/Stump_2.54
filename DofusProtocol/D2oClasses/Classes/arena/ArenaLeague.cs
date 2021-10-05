using System;
using Stump.DofusProtocol.D2oClasses.Tools.D2o;

namespace Stump.DofusProtocol.D2oClasses
{
    [D2OClass("ArenaLeague", "com.ankamagames.dofus.datacenter.arena")]
    [Serializable]
    public class ArenaLeague : IDataObject, IIndexedData
    {
        public const string MODULE = "ArenaLeagues";
        public string icon;
        public int id;
        public string illus;
        public bool isLastLeague;

        [I18NField] public uint nameId;

        public uint ornamentId;

        [D2OIgnore]
        public int Id
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
        public uint OrnamentId
        {
            get => ornamentId;
            set => ornamentId = value;
        }

        [D2OIgnore]
        public string Icon
        {
            get => icon;
            set => icon = value;
        }

        [D2OIgnore]
        public string Illus
        {
            get => illus;
            set => illus = value;
        }

        [D2OIgnore]
        public bool IsLastLeague
        {
            get => isLastLeague;
            set => isLastLeague = value;
        }

        int IIndexedData.Id => id;
    }
}