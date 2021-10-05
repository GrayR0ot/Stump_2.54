using System;
using System.Collections.Generic;
using Stump.DofusProtocol.D2oClasses.Tools.D2o;

namespace Stump.DofusProtocol.D2oClasses
{
    [D2OClass("AlmanaxCalendar", "com.ankamagames.dofus.datacenter.almanax")]
    [Serializable]
    public class AlmanaxCalendar : IDataObject, IIndexedData
    {
        public const string MODULE = "AlmanaxCalendars";
        public List<int> bonusesIds;

        [I18NField] public uint descId;

        public int id;

        [I18NField] public uint nameId;

        public int npcId;

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
        public uint DescId
        {
            get => descId;
            set => descId = value;
        }

        [D2OIgnore]
        public int NpcId
        {
            get => npcId;
            set => npcId = value;
        }

        [D2OIgnore]
        public List<int> BonusesIds
        {
            get => bonusesIds;
            set => bonusesIds = value;
        }

        int IIndexedData.Id => id;
    }
}