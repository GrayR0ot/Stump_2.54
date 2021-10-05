using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Types
{
    [Serializable]
    public class AchievementObjective
    {
        public const short Id = 404;

        public AchievementObjective(uint objectId, ushort maxValue)
        {
            ObjectId = objectId;
            MaxValue = maxValue;
        }

        public AchievementObjective()
        {
        }

        public virtual short TypeId => Id;

        public uint ObjectId { get; set; }
        public ushort MaxValue { get; set; }

        public virtual void Serialize(IDataWriter writer)
        {
            writer.WriteVarUInt(ObjectId);
            writer.WriteVarUShort(MaxValue);
        }

        public virtual void Deserialize(IDataReader reader)
        {
            ObjectId = reader.ReadVarUInt();
            MaxValue = reader.ReadVarUShort();
        }
    }
}