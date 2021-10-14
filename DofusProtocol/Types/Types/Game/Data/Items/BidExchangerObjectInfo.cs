using System;
using System.Linq;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Types
{
    [Serializable]
    public class BidExchangerObjectInfo
    {
        public const short Id = 122;

        public BidExchangerObjectInfo(uint objectUID, uint objectGID, int objectType, ObjectEffect[] effects, ulong[] prices)
        {
            ObjectUID = objectUID;
            ObjectGID = objectGID;
            ObjectType = objectType;
            Effects = effects;
            Prices = prices;
        }

        public BidExchangerObjectInfo()
        {
        }

        public virtual short TypeId => Id;

        public uint ObjectUID { get; set; }
        public uint ObjectGID { get; set; }
        public int ObjectType { get; set; }
        public ObjectEffect[] Effects { get; set; }
        public ulong[] Prices { get; set; }

        public virtual void Serialize(IDataWriter writer)
        {
            writer.WriteVarUInt(ObjectUID);
            writer.WriteVarUInt(ObjectGID);
            writer.WriteInt(ObjectType);
            writer.WriteShort((short) Effects.Count());
            for (var effectsIndex = 0; effectsIndex < Effects.Count(); effectsIndex++)
            {
                var objectToSend = Effects[effectsIndex];
                writer.WriteShort(objectToSend.TypeId);
                objectToSend.Serialize(writer);
            }

            writer.WriteShort((short) Prices.Count());
            for (var pricesIndex = 0; pricesIndex < Prices.Count(); pricesIndex++)
                writer.WriteVarULong(Prices[pricesIndex]);
        }

        public virtual void Deserialize(IDataReader reader)
        {
            ObjectUID = reader.ReadVarUInt();
            ObjectGID = reader.ReadVarUInt();
            ObjectType = reader.ReadInt();
            var effectsCount = reader.ReadUShort();
            Effects = new ObjectEffect[effectsCount];
            for (var effectsIndex = 0; effectsIndex < effectsCount; effectsIndex++)
            {
                var objectToAdd = ProtocolTypeManager.GetInstance<ObjectEffect>(reader.ReadShort());
                objectToAdd.Deserialize(reader);
                Effects[effectsIndex] = objectToAdd;
            }

            var pricesCount = reader.ReadUShort();
            Prices = new ulong[pricesCount];
            for (var pricesIndex = 0; pricesIndex < pricesCount; pricesIndex++)
                Prices[pricesIndex] = reader.ReadVarULong();
        }
    }
}