using System;
using Stump.DofusProtocol.D2oClasses.Tools.D2o;

namespace Stump.DofusProtocol.D2oClasses
{
    [D2OClass("InfoMessage", "com.ankamagames.dofus.datacenter.communication")]
    [Serializable]
    public class InfoMessage : IDataObject
    {
        public const string MODULE = "InfoMessages";
        public uint messageId;

        [I18NField] public uint textId;

        public uint typeId;

        [D2OIgnore]
        public uint TypeId
        {
            get => typeId;
            set => typeId = value;
        }

        [D2OIgnore]
        public uint MessageId
        {
            get => messageId;
            set => messageId = value;
        }

        [D2OIgnore]
        public uint TextId
        {
            get => textId;
            set => textId = value;
        }
    }
}