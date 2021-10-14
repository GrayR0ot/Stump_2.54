using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{

    public class ExchangeOfflineSoldItemsMessage : Message
    {

        public const uint Id = 6613;
        public override uint MessageId
        {
            get { return Id; }
        }

        public ObjectItemQuantityPriceDateEffects[] bidHouseItems;
        public ObjectItemQuantityPriceDateEffects[] merchantItems;
        

        public ExchangeOfflineSoldItemsMessage()
        {
        }

        public ExchangeOfflineSoldItemsMessage(ObjectItemQuantityPriceDateEffects[] bidHouseItems, ObjectItemQuantityPriceDateEffects[] merchantItems)
        {
            this.bidHouseItems = bidHouseItems;
            this.merchantItems = merchantItems;
        }
        

        public override void Serialize(IDataWriter writer)
        {

            writer.WriteShort((short)bidHouseItems.Length);
            foreach (var entry in bidHouseItems)
            {
                entry.Serialize(writer);
            }
            writer.WriteShort((short)merchantItems.Length);
            foreach (var entry in merchantItems)
            {
                entry.Serialize(writer);
            }
            

        }

        public override void Deserialize(IDataReader reader)
        {

            var limit = (ushort)reader.ReadUShort();
            bidHouseItems = new ObjectItemQuantityPriceDateEffects[limit];
            for (int i = 0; i < limit; i++)
            {
                bidHouseItems[i] = new ObjectItemQuantityPriceDateEffects();
                bidHouseItems[i].Deserialize(reader);
            }
            limit = (ushort)reader.ReadUShort();
            merchantItems = new ObjectItemQuantityPriceDateEffects[limit];
            for (int i = 0; i < limit; i++)
            {
                merchantItems[i] = new ObjectItemQuantityPriceDateEffects();
                merchantItems[i].Deserialize(reader);
            }
            

        }


    }


}