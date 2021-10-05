using System;
using Stump.DofusProtocol.D2oClasses.Tools.D2o;

namespace Stump.DofusProtocol.D2oClasses
{
    [D2OClass("Document", "com.ankamagames.dofus.datacenter.documents")]
    [Serializable]
    public class Document : IDataObject, IIndexedData
    {
        private const string MODULE = "Documents";

        [I18NField] public uint authorId;

        public string clientProperties;
        public string contentCSS;

        [I18NField] public uint contentId;

        public int id;
        public bool showBackgroundImage;
        public bool showTitle;

        [I18NField] public uint subTitleId;

        [I18NField] public uint titleId;

        public uint typeId;

        [D2OIgnore]
        public int Id
        {
            get => id;
            set => id = value;
        }

        [D2OIgnore]
        public uint TypeId
        {
            get => typeId;
            set => typeId = value;
        }

        [D2OIgnore]
        public bool ShowTitle
        {
            get => showTitle;
            set => showTitle = value;
        }

        [D2OIgnore]
        public bool ShowBackgroundImage
        {
            get => showBackgroundImage;
            set => showBackgroundImage = value;
        }

        [D2OIgnore]
        public uint TitleId
        {
            get => titleId;
            set => titleId = value;
        }

        [D2OIgnore]
        public uint AuthorId
        {
            get => authorId;
            set => authorId = value;
        }

        [D2OIgnore]
        public uint SubTitleId
        {
            get => subTitleId;
            set => subTitleId = value;
        }

        [D2OIgnore]
        public uint ContentId
        {
            get => contentId;
            set => contentId = value;
        }

        [D2OIgnore]
        public string ContentCSS
        {
            get => contentCSS;
            set => contentCSS = value;
        }

        [D2OIgnore]
        public string ClientProperties
        {
            get => clientProperties;
            set => clientProperties = value;
        }

        int IIndexedData.Id => id;
    }
}