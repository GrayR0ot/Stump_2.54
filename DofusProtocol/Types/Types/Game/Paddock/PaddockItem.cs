﻿using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Types
{
    [Serializable]
    public class PaddockItem : ObjectItemInRolePlay
    {
        public new const short Id = 185;

        public PaddockItem(ushort cellId, ushort objectGID, ItemDurability durability)
        {
            CellId = cellId;
            ObjectGID = objectGID;
            Durability = durability;
        }

        public PaddockItem()
        {
        }

        public override short TypeId => Id;

        public ItemDurability Durability { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            Durability.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            Durability = new ItemDurability();
            Durability.Deserialize(reader);
        }
    }
}