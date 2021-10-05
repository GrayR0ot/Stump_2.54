using System;
using System.Linq;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Types
{
    [Serializable]
    public class ItemsPreset : Preset
    {
        public new const short Id = 517;

        public ItemsPreset(short objectId, ItemForPreset[] items, bool mountEquipped, EntityLook look)
        {
            ObjectId = objectId;
            Items = items;
            MountEquipped = mountEquipped;
            Look = look;
        }

        public ItemsPreset()
        {
        }

        public override short TypeId => Id;

        public ItemForPreset[] Items { get; set; }
        public bool MountEquipped { get; set; }
        public EntityLook Look { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteShort((short) Items.Count());
            for (var itemsIndex = 0; itemsIndex < Items.Count(); itemsIndex++)
            {
                var objectToSend = Items[itemsIndex];
                objectToSend.Serialize(writer);
            }

            writer.WriteBoolean(MountEquipped);
            Look.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            var itemsCount = reader.ReadUShort();
            Items = new ItemForPreset[itemsCount];
            for (var itemsIndex = 0; itemsIndex < itemsCount; itemsIndex++)
            {
                var objectToAdd = new ItemForPreset();
                objectToAdd.Deserialize(reader);
                Items[itemsIndex] = objectToAdd;
            }

            MountEquipped = reader.ReadBoolean();
            Look = new EntityLook();
            Look.Deserialize(reader);
        }
    }
}