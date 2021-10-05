using System;
using System.Collections.Generic;
using Stump.DofusProtocol.D2oClasses.Tools.D2o;

namespace Stump.DofusProtocol.D2oClasses
{
    [D2OClass("SpeakingItemsTrigger", "com.ankamagames.dofus.datacenter.livingObjects")]
    [Serializable]
    public class SpeakingItemsTrigger : IDataObject, IIndexedData
    {
        public const string MODULE = "SpeakingItemsTriggers";
        public List<int> states;
        public List<int> textIds;
        public int triggersId;

        [D2OIgnore]
        public int TriggersId
        {
            get => triggersId;
            set => triggersId = value;
        }

        [D2OIgnore]
        public List<int> TextIds
        {
            get => textIds;
            set => textIds = value;
        }

        [D2OIgnore]
        public List<int> States
        {
            get => states;
            set => states = value;
        }

        int IIndexedData.Id => triggersId;
    }
}