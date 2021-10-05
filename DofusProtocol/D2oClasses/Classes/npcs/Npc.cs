using System;
using System.Collections.Generic;
using Stump.DofusProtocol.D2oClasses.Tools.D2o;
using WorldEditor.D2OClasses;

namespace Stump.DofusProtocol.D2oClasses
{
    [D2OClass("Npc", "com.ankamagames.dofus.datacenter.npcs")]
    [Serializable]
    public class Npc : IDataObject, IIndexedData
    {
        public const string MODULE = "Npcs";
        public List<uint> actions;
        public List<AnimFunNpcData> animFunList;
        public List<List<int>> dialogMessages;
        public List<List<int>> dialogReplies;
        public bool fastAnimsFun;
        public uint gender;
        public int id;
        public string look;

        [I18NField] public uint nameId;

        public int tokenShop;

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
        public List<List<int>> DialogMessages
        {
            get => dialogMessages;
            set => dialogMessages = value;
        }

        [D2OIgnore]
        public List<List<int>> DialogReplies
        {
            get => dialogReplies;
            set => dialogReplies = value;
        }

        [D2OIgnore]
        public List<uint> Actions
        {
            get => actions;
            set => actions = value;
        }

        [D2OIgnore]
        public uint Gender
        {
            get => gender;
            set => gender = value;
        }

        [D2OIgnore]
        public string Look
        {
            get => look;
            set => look = value;
        }

        [D2OIgnore]
        public int TokenShop
        {
            get => tokenShop;
            set => tokenShop = value;
        }

        [D2OIgnore]
        public List<AnimFunNpcData> AnimFunList
        {
            get => animFunList;
            set => animFunList = value;
        }

        [D2OIgnore]
        public bool FastAnimsFun
        {
            get => fastAnimsFun;
            set => fastAnimsFun = value;
        }

        int IIndexedData.Id => id;
    }
}