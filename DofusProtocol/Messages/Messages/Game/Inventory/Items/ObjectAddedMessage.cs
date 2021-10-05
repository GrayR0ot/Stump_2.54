using System;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class ObjectAddedMessage : Message
    {
        public const uint Id = 3025;

        public ObjectAddedMessage(ObjectItem @object, sbyte origin)
        {
            this.@object = @object;
            Origin = origin;
        }

        public ObjectAddedMessage()
        {
        }

        public override uint MessageId => Id;

        public ObjectItem @object { get; set; }
        public sbyte Origin { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            @object.Serialize(writer);
            writer.WriteSByte(Origin);
        }

        public override void Deserialize(IDataReader reader)
        {
            @object = new ObjectItem();
            @object.Deserialize(reader);
            Origin = reader.ReadSByte();
        }
    }
}