using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class RoomAvailableUpdateMessage : Message
    {
        public const uint Id = 6630;

        public RoomAvailableUpdateMessage(byte nbRoom)
        {
            NbRoom = nbRoom;
        }

        public RoomAvailableUpdateMessage()
        {
        }

        public override uint MessageId => Id;

        public byte NbRoom { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteByte(NbRoom);
        }

        public override void Deserialize(IDataReader reader)
        {
            NbRoom = reader.ReadByte();
        }
    }
}