using System;
using Stump.DofusProtocol.D2oClasses.Tools.D2o;

namespace Stump.DofusProtocol.D2oClasses
{
    [D2OClass("ChatChannel", "com.ankamagames.dofus.datacenter.communication")]
    [Serializable]
    public class ChatChannel : IDataObject, IIndexedData
    {
        public const string MODULE = "ChatChannels";
        public bool allowObjects;
        public uint descriptionId;
        public uint id;
        public bool isPrivate;

        [I18NField] public uint nameId;

        public string shortcut;
        public string shortcutKey;

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
        public uint DescriptionId
        {
            get => descriptionId;
            set => descriptionId = value;
        }

        [D2OIgnore]
        public string Shortcut
        {
            get => shortcut;
            set => shortcut = value;
        }

        [D2OIgnore]
        public string ShortcutKey
        {
            get => shortcutKey;
            set => shortcutKey = value;
        }

        [D2OIgnore]
        public bool IsPrivate
        {
            get => isPrivate;
            set => isPrivate = value;
        }

        [D2OIgnore]
        public bool AllowObjects
        {
            get => allowObjects;
            set => allowObjects = value;
        }

        int IIndexedData.Id => (int) id;
    }
}