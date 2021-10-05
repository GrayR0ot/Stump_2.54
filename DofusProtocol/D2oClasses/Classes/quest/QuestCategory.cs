﻿using System;
using System.Collections.Generic;
using Stump.DofusProtocol.D2oClasses.Tools.D2o;

namespace Stump.DofusProtocol.D2oClasses
{
    [D2OClass("QuestCategory", "com.ankamagames.dofus.datacenter.quest")]
    [Serializable]
    public class QuestCategory : IDataObject, IIndexedData
    {
        public const string MODULE = "QuestCategory";
        public uint id;

        [I18NField] public uint nameId;

        public uint order;
        public List<uint> questIds;

        [D2OIgnore]
        public uint Id
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
        public uint Order
        {
            get => order;
            set => order = value;
        }

        [D2OIgnore]
        public List<uint> QuestIds
        {
            get => questIds;
            set => questIds = value;
        }

        int IIndexedData.Id => (int) id;
    }
}