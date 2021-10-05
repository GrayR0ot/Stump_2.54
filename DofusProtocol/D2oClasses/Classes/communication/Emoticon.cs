using System;
using System.Collections.Generic;
using Stump.DofusProtocol.D2oClasses.Tools.D2o;

namespace Stump.DofusProtocol.D2oClasses
{
    [D2OClass("Emoticon", "com.ankamagames.dofus.datacenter.communication")]
    [Serializable]
    public class Emoticon : IDataObject, IIndexedData
    {
        public const string MODULE = "Emoticons";
        public List<string> anims;
        public bool aura;
        public uint cooldown = 1000;
        public string defaultAnim;
        public uint duration;
        public bool eight_directions;
        public uint id;

        [I18NField] public uint nameId;

        public uint order;
        public bool persistancy;

        [I18NField] public uint shortcutId;

        public uint spellLevelId;
        public uint weight;

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
        public uint ShortcutId
        {
            get => shortcutId;
            set => shortcutId = value;
        }

        [D2OIgnore]
        public uint Order
        {
            get => order;
            set => order = value;
        }

        [D2OIgnore]
        public string DefaultAnim
        {
            get => defaultAnim;
            set => defaultAnim = value;
        }

        [D2OIgnore]
        public bool Persistancy
        {
            get => persistancy;
            set => persistancy = value;
        }

        [D2OIgnore]
        public bool Eight_directions
        {
            get => eight_directions;
            set => eight_directions = value;
        }

        [D2OIgnore]
        public bool Aura
        {
            get => aura;
            set => aura = value;
        }

        [D2OIgnore]
        public List<string> Anims
        {
            get => anims;
            set => anims = value;
        }

        [D2OIgnore]
        public uint Cooldown
        {
            get => cooldown;
            set => cooldown = value;
        }

        [D2OIgnore]
        public uint Duration
        {
            get => duration;
            set => duration = value;
        }

        [D2OIgnore]
        public uint Weight
        {
            get => weight;
            set => weight = value;
        }

        [D2OIgnore]
        public uint SpellLevelId
        {
            get => spellLevelId;
            set => spellLevelId = value;
        }

        int IIndexedData.Id => (int) id;
    }
}