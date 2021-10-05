using System;
using System.Linq;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Types
{
    [Serializable]
    public class EntityMovementInformations
    {
        public const short Id = 63;

        public EntityMovementInformations(int objectId, sbyte[] steps)
        {
            ObjectId = objectId;
            Steps = steps;
        }

        public EntityMovementInformations()
        {
        }

        public virtual short TypeId => Id;

        public int ObjectId { get; set; }
        public sbyte[] Steps { get; set; }

        public virtual void Serialize(IDataWriter writer)
        {
            writer.WriteInt(ObjectId);
            writer.WriteShort((short) Steps.Count());
            for (var stepsIndex = 0; stepsIndex < Steps.Count(); stepsIndex++) writer.WriteSByte(Steps[stepsIndex]);
        }

        public virtual void Deserialize(IDataReader reader)
        {
            ObjectId = reader.ReadInt();
            var stepsCount = reader.ReadUShort();
            Steps = new sbyte[stepsCount];
            for (var stepsIndex = 0; stepsIndex < stepsCount; stepsIndex++) Steps[stepsIndex] = reader.ReadSByte();
        }
    }
}