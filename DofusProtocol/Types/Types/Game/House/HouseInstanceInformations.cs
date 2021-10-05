using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Types
{
    [Serializable]
    public class HouseInstanceInformations
    {
        public const short Id = 511;

        public HouseInstanceInformations(bool secondHand, bool isLocked, bool isSaleLocked, int instanceId,
            string ownerName, long price)
        {
            SecondHand = secondHand;
            IsLocked = isLocked;
            IsSaleLocked = isSaleLocked;
            InstanceId = instanceId;
            OwnerName = ownerName;
            Price = price;
        }

        public HouseInstanceInformations()
        {
        }

        public virtual short TypeId => Id;

        public bool SecondHand { get; set; }
        public bool IsLocked { get; set; }
        public bool IsSaleLocked { get; set; }
        public int InstanceId { get; set; }
        public string OwnerName { get; set; }
        public long Price { get; set; }

        public virtual void Serialize(IDataWriter writer)
        {
            var flag = new byte();
            flag = BooleanByteWrapper.SetFlag(flag, 0, SecondHand);
            flag = BooleanByteWrapper.SetFlag(flag, 1, IsLocked);
            flag = BooleanByteWrapper.SetFlag(flag, 2, IsSaleLocked);
            writer.WriteByte(flag);
            writer.WriteInt(InstanceId);
            writer.WriteUTF(OwnerName);
            writer.WriteVarLong(Price);
        }

        public virtual void Deserialize(IDataReader reader)
        {
            var flag = reader.ReadByte();
            SecondHand = BooleanByteWrapper.GetFlag(flag, 0);
            IsLocked = BooleanByteWrapper.GetFlag(flag, 1);
            IsSaleLocked = BooleanByteWrapper.GetFlag(flag, 2);
            InstanceId = reader.ReadInt();
            OwnerName = reader.ReadUTF();
            Price = reader.ReadVarLong();
        }
    }
}