using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class ObjectGroundAddedMessage : Message
    {
        public const uint Id = 3017;

        public ObjectGroundAddedMessage(ushort cellId, ushort objectGID)
        {
            CellId = cellId;
            ObjectGID = objectGID;
        }

        public ObjectGroundAddedMessage()
        {
        }

        public override uint MessageId => Id;

        public ushort CellId { get; set; }
        public ushort ObjectGID { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUShort(CellId);
            writer.WriteVarUShort(ObjectGID);
        }

        public override void Deserialize(IDataReader reader)
        {
            CellId = reader.ReadVarUShort();
            ObjectGID = reader.ReadVarUShort();
        }
    }
}