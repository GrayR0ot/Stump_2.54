using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{

    public class ExchangeTypesItemsExchangerDescriptionForUserMessage : Message
    {

        public const uint Id = 5752;
        public override uint MessageId
        {
            get { return Id; }
        }

        public int objectType;
        public BidExchangerObjectInfo[] itemTypeDescriptions;
        

        public ExchangeTypesItemsExchangerDescriptionForUserMessage()
        {
        }

        public ExchangeTypesItemsExchangerDescriptionForUserMessage(int objectType, BidExchangerObjectInfo[] itemTypeDescriptions)
        {
            this.objectType = objectType;
            this.itemTypeDescriptions = itemTypeDescriptions;
        }
        

        public override void Serialize(IDataWriter writer)
        {

            writer.WriteInt(objectType);
            writer.WriteShort((short)itemTypeDescriptions.Length);
            foreach (var entry in itemTypeDescriptions)
            {
                entry.Serialize(writer);
            }
            

        }

        public override void Deserialize(IDataReader reader)
        {

            objectType = reader.ReadInt();
            var limit = (ushort)reader.ReadUShort();
            itemTypeDescriptions = new BidExchangerObjectInfo[limit];
            for (int i = 0; i < limit; i++)
            {
                itemTypeDescriptions[i] = new BidExchangerObjectInfo();
                itemTypeDescriptions[i].Deserialize(reader);
            }
            

        }


    }


}