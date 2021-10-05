using Stump.Core.IO;

namespace Stump.DofusProtocol.Types
{
    public class GameFightEffectTriggerCount
    {
        public const short Id = 569;

        public virtual short TypeId
        {
            get { return Id; }
        }

        public uint effectId;
        public double targetId;
        public sbyte count;


        public GameFightEffectTriggerCount()
        {
        }

        public GameFightEffectTriggerCount(uint effectId, double targetId, sbyte count)
        {
            this.effectId = effectId;
            this.targetId = targetId;
            this.count = count;
        }


        public virtual void Serialize(IDataWriter writer)
        {
            writer.WriteVarInt((int) effectId);
            writer.WriteDouble(targetId);
            writer.WriteSByte(count);
        }

        public virtual void Deserialize(IDataReader reader)
        {
            effectId = reader.ReadVarUInt();
            targetId = reader.ReadDouble();
            count = reader.ReadSByte();
        }
    }
}