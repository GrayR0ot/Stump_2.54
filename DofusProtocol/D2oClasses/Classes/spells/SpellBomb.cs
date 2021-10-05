using System;
using Stump.DofusProtocol.D2oClasses.Tools.D2o;

namespace Stump.DofusProtocol.D2oClasses
{
    [D2OClass("SpellBomb", "com.ankamagames.dofus.datacenter.spells")]
    [Serializable]
    public class SpellBomb : IDataObject, IIndexedData
    {
        public const string MODULE = "SpellBombs";
        public int chainReactionSpellId;
        public int comboCoeff;
        public int explodSpellId;
        public int id;
        public int instantSpellId;
        public int wallId;

        [D2OIgnore]
        public int Id
        {
            get => id;
            set => id = value;
        }

        [D2OIgnore]
        public int ChainReactionSpellId
        {
            get => chainReactionSpellId;
            set => chainReactionSpellId = value;
        }

        [D2OIgnore]
        public int ExplodSpellId
        {
            get => explodSpellId;
            set => explodSpellId = value;
        }

        [D2OIgnore]
        public int WallId
        {
            get => wallId;
            set => wallId = value;
        }

        [D2OIgnore]
        public int InstantSpellId
        {
            get => instantSpellId;
            set => instantSpellId = value;
        }

        [D2OIgnore]
        public int ComboCoeff
        {
            get => comboCoeff;
            set => comboCoeff = value;
        }

        int IIndexedData.Id => id;
    }
}