using System;
using System.Linq;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class UpdateMountCharacteristicsMessage : Message
    {
        public const uint Id = 6753;

        public UpdateMountCharacteristicsMessage(int rideId, UpdateMountCharacteristic[] boostToUpdateList)
        {
            RideId = rideId;
            BoostToUpdateList = boostToUpdateList;
        }

        public UpdateMountCharacteristicsMessage()
        {
        }

        public override uint MessageId => Id;

        public int RideId { get; set; }
        public UpdateMountCharacteristic[] BoostToUpdateList { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarInt(RideId);
            writer.WriteShort((short) BoostToUpdateList.Count());
            for (var boostToUpdateListIndex = 0;
                boostToUpdateListIndex < BoostToUpdateList.Count();
                boostToUpdateListIndex++)
            {
                var objectToSend = BoostToUpdateList[boostToUpdateListIndex];
                writer.WriteShort(objectToSend.TypeId);
                objectToSend.Serialize(writer);
            }
        }

        public override void Deserialize(IDataReader reader)
        {
            RideId = reader.ReadVarInt();
            var boostToUpdateListCount = reader.ReadUShort();
            BoostToUpdateList = new UpdateMountCharacteristic[boostToUpdateListCount];
            for (var boostToUpdateListIndex = 0;
                boostToUpdateListIndex < boostToUpdateListCount;
                boostToUpdateListIndex++)
            {
                var objectToAdd = ProtocolTypeManager.GetInstance<UpdateMountCharacteristic>(reader.ReadShort());
                objectToAdd.Deserialize(reader);
                BoostToUpdateList[boostToUpdateListIndex] = objectToAdd;
            }
        }
    }
}