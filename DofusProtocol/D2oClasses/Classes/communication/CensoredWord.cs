using System;
using Stump.DofusProtocol.D2oClasses.Tools.D2o;

namespace Stump.DofusProtocol.D2oClasses
{
    [D2OClass("CensoredWord", "com.ankamagames.dofus.datacenter.communication")]
    [Serializable]
    public class CensoredWord : IDataObject, IIndexedData
    {
        public const string MODULE = "CensoredWords";
        public bool deepLooking;
        public uint id;
        public string language;
        public uint listId;
        public string word;

        [D2OIgnore]
        public uint Id
        {
            get => id;
            set => id = value;
        }

        [D2OIgnore]
        public uint ListId
        {
            get => listId;
            set => listId = value;
        }

        [D2OIgnore]
        public string Language
        {
            get => language;
            set => language = value;
        }

        [D2OIgnore]
        public string Word
        {
            get => word;
            set => word = value;
        }

        [D2OIgnore]
        public bool DeepLooking
        {
            get => deepLooking;
            set => deepLooking = value;
        }

        int IIndexedData.Id => (int) id;
    }
}