using System;
using System.Collections.Generic;
using Stump.DofusProtocol.D2oClasses.Tools.D2o;

namespace Stump.DofusProtocol.D2oClasses
{
    [D2OClass("NpcMessage", "com.ankamagames.dofus.datacenter.npcs")]
    [Serializable]
    public class NpcMessage : IDataObject, IIndexedData
    {
        public const string MODULE = "NpcMessages";
        public int id;

        [I18NField] public uint messageId;

        public List<string> messageParams;

        [D2OIgnore]
        public int Id
        {
            get => id;
            set => id = value;
        }

        [D2OIgnore]
        public uint MessageId
        {
            get => messageId;
            set => messageId = value;
        }

        [D2OIgnore]
        public List<string> MessageParams
        {
            get => messageParams;
            set => messageParams = value;
        }

        int IIndexedData.Id => id;
    }
}