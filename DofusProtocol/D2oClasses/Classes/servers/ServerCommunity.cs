using System;
using System.Collections.Generic;
using Stump.DofusProtocol.D2oClasses.Tools.D2o;

namespace Stump.DofusProtocol.D2oClasses
{
    [D2OClass("ServerCommunity", "com.ankamagames.dofus.datacenter.servers")]
    [Serializable]
    public class ServerCommunity : IDataObject, IIndexedData
    {
        public const string MODULE = "ServerCommunities";
        public List<string> defaultCountries;
        public int id;

        [I18NField] public uint nameId;

        public int namingRuleAdminId;
        public int namingRuleAllianceNameId;
        public int namingRuleAllianceTagId;
        public int namingRuleGuildNameId;
        public int namingRuleModoId;
        public int namingRuleMountNameId;
        public int namingRuleNameGeneratorId;
        public int namingRulePartyNameId;
        public int namingRulePlayerNameId;
        public string shortId;
        public List<int> supportedLangIds;

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
        public string ShortId
        {
            get => shortId;
            set => shortId = value;
        }

        [D2OIgnore]
        public List<string> DefaultCountries
        {
            get => defaultCountries;
            set => defaultCountries = value;
        }

        [D2OIgnore]
        public List<int> SupportedLangIds
        {
            get => supportedLangIds;
            set => supportedLangIds = value;
        }

        [D2OIgnore]
        public int NamingRulePlayerNameId
        {
            get => namingRulePlayerNameId;
            set => namingRulePlayerNameId = value;
        }

        [D2OIgnore]
        public int NamingRuleGuildNameId
        {
            get => namingRuleGuildNameId;
            set => namingRuleGuildNameId = value;
        }

        [D2OIgnore]
        public int NamingRuleAllianceNameId
        {
            get => namingRuleAllianceNameId;
            set => namingRuleAllianceNameId = value;
        }

        [D2OIgnore]
        public int NamingRuleAllianceTagId
        {
            get => namingRuleAllianceTagId;
            set => namingRuleAllianceTagId = value;
        }

        [D2OIgnore]
        public int NamingRulePartyNameId
        {
            get => namingRulePartyNameId;
            set => namingRulePartyNameId = value;
        }

        [D2OIgnore]
        public int NamingRuleMountNameId
        {
            get => namingRuleMountNameId;
            set => namingRuleMountNameId = value;
        }

        [D2OIgnore]
        public int NamingRuleNameGeneratorId
        {
            get => namingRuleNameGeneratorId;
            set => namingRuleNameGeneratorId = value;
        }

        [D2OIgnore]
        public int NamingRuleAdminId
        {
            get => namingRuleAdminId;
            set => namingRuleAdminId = value;
        }

        [D2OIgnore]
        public int NamingRuleModoId
        {
            get => namingRuleModoId;
            set => namingRuleModoId = value;
        }

        int IIndexedData.Id => id;
    }
}