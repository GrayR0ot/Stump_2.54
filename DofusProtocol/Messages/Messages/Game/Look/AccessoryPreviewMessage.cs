using System;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class AccessoryPreviewMessage : Message
    {
        public const uint Id = 6517;

        public AccessoryPreviewMessage(EntityLook look)
        {
            Look = look;
        }

        public AccessoryPreviewMessage()
        {
        }

        public override uint MessageId => Id;

        public EntityLook Look { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            Look.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            Look = new EntityLook();
            Look.Deserialize(reader);
        }
    }
}