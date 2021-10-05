using System;
using Stump.DofusProtocol.D2oClasses.Tools.D2o;

namespace Stump.DofusProtocol.D2oClasses
{
    [D2OClass("ServerGameType", "com.ankamagames.dofus.datacenter.servers")]
    [Serializable]
    public class ServerGameType : IDataObject, IIndexedData
    {
        public const string MODULE = "ServerGameTypes";

        [I18NField] public uint descriptionId;

        public int id;

        [I18NField] public uint nameId;

        [I18NField] public uint rulesId;

        public bool selectableByPlayer;

        [D2OIgnore]
        public int Id
        {
            get => id;
            set => id = value;
        }

        [D2OIgnore]
        public bool SelectableByPlayer
        {
            get => selectableByPlayer;
            set => selectableByPlayer = value;
        }

        [D2OIgnore]
        public uint NameId
        {
            get => nameId;
            set => nameId = value;
        }

        [D2OIgnore]
        public uint RulesId
        {
            get => rulesId;
            set => rulesId = value;
        }

        [D2OIgnore]
        public uint DescriptionId
        {
            get => descriptionId;
            set => descriptionId = value;
        }

        int IIndexedData.Id => id;
    }
}