using System;
using Stump.DofusProtocol.D2oClasses.Tools.D2o;

namespace Stump.DofusProtocol.D2oClasses
{
    [D2OClass("Notification", "com.ankamagames.dofus.datacenter.notifications")]
    [Serializable]
    public class Notification : IDataObject, IIndexedData
    {
        public const string MODULE = "Notifications";
        public int iconId;
        public int id;

        [I18NField] public uint messageId;

        [I18NField] public uint titleId;

        public string trigger;
        public int typeId;

        [D2OIgnore]
        public int Id
        {
            get => id;
            set => id = value;
        }

        [D2OIgnore]
        public uint TitleId
        {
            get => titleId;
            set => titleId = value;
        }

        [D2OIgnore]
        public uint MessageId
        {
            get => messageId;
            set => messageId = value;
        }

        [D2OIgnore]
        public int IconId
        {
            get => iconId;
            set => iconId = value;
        }

        [D2OIgnore]
        public int TypeId
        {
            get => typeId;
            set => typeId = value;
        }

        [D2OIgnore]
        public string Trigger
        {
            get => trigger;
            set => trigger = value;
        }

        int IIndexedData.Id => id;
    }
}