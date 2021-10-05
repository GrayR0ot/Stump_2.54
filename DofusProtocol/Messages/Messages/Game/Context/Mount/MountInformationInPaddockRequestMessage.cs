using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class MountInformationInPaddockRequestMessage : Message
    {
        public const uint Id = 5975;

        public MountInformationInPaddockRequestMessage(int mapRideId)
        {
            MapRideId = mapRideId;
        }

        public MountInformationInPaddockRequestMessage()
        {
        }

        public override uint MessageId => Id;

        public int MapRideId { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarInt(MapRideId);
        }

        public override void Deserialize(IDataReader reader)
        {
            MapRideId = reader.ReadVarInt();
        }
    }
}