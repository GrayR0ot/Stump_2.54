using System;
using Stump.DofusProtocol.D2oClasses.Tools.D2o;

namespace Stump.DofusProtocol.D2oClasses
{
    [D2OClass("ExternalNotification", "com.ankamagames.dofus.datacenter.externalnotifications")]
    [Serializable]
    public class ExternalNotification : IDataObject, IIndexedData
    {
        public const string MODULE = "ExternalNotifications";
        public int categoryId;
        public int colorId;
        public bool defaultEnable;
        public bool defaultMultiAccount;
        public bool defaultNotify;
        public bool defaultSound;

        [I18NField] public uint descriptionId;

        public int iconId;
        public int id;

        [I18NField] public uint messageId;

        public string name;

        [D2OIgnore]
        public int Id
        {
            get => id;
            set => id = value;
        }

        [D2OIgnore]
        public int CategoryId
        {
            get => categoryId;
            set => categoryId = value;
        }

        [D2OIgnore]
        public int IconId
        {
            get => iconId;
            set => iconId = value;
        }

        [D2OIgnore]
        public int ColorId
        {
            get => colorId;
            set => colorId = value;
        }

        [D2OIgnore]
        public uint DescriptionId
        {
            get => descriptionId;
            set => descriptionId = value;
        }

        [D2OIgnore]
        public bool DefaultEnable
        {
            get => defaultEnable;
            set => defaultEnable = value;
        }

        [D2OIgnore]
        public bool DefaultSound
        {
            get => defaultSound;
            set => defaultSound = value;
        }

        [D2OIgnore]
        public bool DefaultNotify
        {
            get => defaultNotify;
            set => defaultNotify = value;
        }

        [D2OIgnore]
        public bool DefaultMultiAccount
        {
            get => defaultMultiAccount;
            set => defaultMultiAccount = value;
        }

        [D2OIgnore]
        public string Name
        {
            get => name;
            set => name = value;
        }

        [D2OIgnore]
        public uint MessageId
        {
            get => messageId;
            set => messageId = value;
        }

        int IIndexedData.Id => id;
    }
}