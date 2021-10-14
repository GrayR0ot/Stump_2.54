using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    public class ExchangeBidHouseInListRemovedMessage : Message
    {
        public const uint Id = 5950;

        public override uint MessageId
        {
            get { return Id; }
        }

        public int itemUID;
        public uint objectGID;
        public int objectType;


        public ExchangeBidHouseInListRemovedMessage()
        {
        }

        public ExchangeBidHouseInListRemovedMessage(int itemUID, uint objectGID, int objectType)
        {
            this.itemUID = itemUID;
            this.objectGID = objectGID;
            this.objectType = objectType;
        }


        public override void Serialize(IDataWriter writer)
        {
            writer.WriteInt(itemUID);
            writer.WriteVarShort((short) objectGID);
            writer.WriteInt(objectType);
        }

        public override void Deserialize(IDataReader reader)
        {
            itemUID = reader.ReadInt();
            objectGID = reader.ReadVarUShort();
            objectType = reader.ReadInt();
        }
    }
}