using System;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class GameContextRefreshEntityLookMessage : Message
    {
        public const uint Id = 5637;

        public GameContextRefreshEntityLookMessage(double objectId, EntityLook look)
        {
            ObjectId = objectId;
            Look = look;
        }

        public GameContextRefreshEntityLookMessage()
        {
        }

        public override uint MessageId => Id;

        public double ObjectId { get; set; }
        public EntityLook Look { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteDouble(ObjectId);
            Look.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            ObjectId = reader.ReadDouble();
            Look = new EntityLook();
            Look.Deserialize(reader);
        }
    }
}