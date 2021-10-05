using System;
using System.Collections.Generic;
using Stump.DofusProtocol.D2oClasses.Tools.D2o;

namespace Stump.DofusProtocol.D2oClasses
{
    [D2OClass("AlignmentRankJntGift", "com.ankamagames.dofus.datacenter.alignments")]
    [Serializable]
    public class AlignmentRankJntGift : IDataObject, IIndexedData
    {
        public const string MODULE = "AlignmentRankJntGift";
        public List<int> gifts;
        public int id;
        public List<int> levels;
        public List<int> parameters;

        [D2OIgnore]
        public int Id
        {
            get => id;
            set => id = value;
        }

        [D2OIgnore]
        public List<int> Gifts
        {
            get => gifts;
            set => gifts = value;
        }

        [D2OIgnore]
        public List<int> Parameters
        {
            get => parameters;
            set => parameters = value;
        }

        [D2OIgnore]
        public List<int> Levels
        {
            get => levels;
            set => levels = value;
        }

        int IIndexedData.Id => id;
    }
}