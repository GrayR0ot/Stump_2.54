using System;
using System.Collections.Generic;
using Stump.DofusProtocol.D2oClasses.Tools.D2o;

namespace Stump.DofusProtocol.D2oClasses
{
    [D2OClass("Server", "com.ankamagames.dofus.datacenter.servers")]
    [Serializable]
    public class Server : IDataObject, IIndexedData
    {
        public const string MODULE = "Servers";

        [I18NField] public uint commentId;

        public int communityId;
        public uint gameTypeId;
        public int id;
        public string language;
        public bool monoAccount;

        [I18NField] public uint nameId;

        public double openingDate;
        public int populationId;
        public List<string> restrictedToLanguages;

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
        public uint CommentId
        {
            get => commentId;
            set => commentId = value;
        }

        [D2OIgnore]
        public double OpeningDate
        {
            get => openingDate;
            set => openingDate = value;
        }

        [D2OIgnore]
        public string Language
        {
            get => language;
            set => language = value;
        }

        [D2OIgnore]
        public int PopulationId
        {
            get => populationId;
            set => populationId = value;
        }

        [D2OIgnore]
        public uint GameTypeId
        {
            get => gameTypeId;
            set => gameTypeId = value;
        }

        [D2OIgnore]
        public int CommunityId
        {
            get => communityId;
            set => communityId = value;
        }

        [D2OIgnore]
        public List<string> RestrictedToLanguages
        {
            get => restrictedToLanguages;
            set => restrictedToLanguages = value;
        }

        [D2OIgnore]
        public bool MonoAccount
        {
            get => monoAccount;
            set => monoAccount = value;
        }

        int IIndexedData.Id => id;
    }
}