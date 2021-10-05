using System;
using System.Collections.Generic;
using Stump.DofusProtocol.D2oClasses.Tools.D2o;

namespace Stump.DofusProtocol.D2oClasses
{
    [D2OClass("Smiley", "com.ankamagames.dofus.datacenter.communication")]
    [Serializable]
    public class Smiley : IDataObject, IIndexedData
    {
        public const string MODULE = "Smileys";
        public uint categoryId;
        public bool forPlayers;
        public string gfxId;
        public uint id;
        public uint order;
        public uint referenceId;
        public List<string> triggers;

        [D2OIgnore]
        public uint Id
        {
            get => id;
            set => id = value;
        }

        [D2OIgnore]
        public uint Order
        {
            get => order;
            set => order = value;
        }

        [D2OIgnore]
        public string GfxId
        {
            get => gfxId;
            set => gfxId = value;
        }

        [D2OIgnore]
        public bool ForPlayers
        {
            get => forPlayers;
            set => forPlayers = value;
        }

        [D2OIgnore]
        public List<string> Triggers
        {
            get => triggers;
            set => triggers = value;
        }

        [D2OIgnore]
        public uint ReferenceId
        {
            get => referenceId;
            set => referenceId = value;
        }

        [D2OIgnore]
        public uint CategoryId
        {
            get => categoryId;
            set => categoryId = value;
        }

        int IIndexedData.Id => (int) id;
    }
}