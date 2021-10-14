using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{

    public class ExchangeBidHouseInListAddedMessage : Message
    {

        public const uint Id = 5949;
        public override uint MessageId
        {
            get { return Id; }
        }

        public int itemUID;
        public uint objectGID;
        public int objectType;
        public Types.ObjectEffect[] effects;
        public ulong[] prices;
        

        public ExchangeBidHouseInListAddedMessage()
        {
        }

        public ExchangeBidHouseInListAddedMessage(int itemUID, uint objectGID, int objectType, Types.ObjectEffect[] effects, ulong[] prices)
        {
            this.itemUID = itemUID;
            this.objectGID = objectGID;
            this.objectType = objectType;
            this.effects = effects;
            this.prices = prices;
        }
        

        public override void Serialize(IDataWriter writer)
        {

            writer.WriteInt(itemUID);
            writer.WriteVarShort((short)objectGID);
            writer.WriteInt(objectType);
            writer.WriteShort((short)effects.Length);
            foreach (var entry in effects)
            {
                writer.WriteShort(entry.TypeId);
                entry.Serialize(writer);
            }
            writer.WriteShort((short)prices.Length);
            foreach (var entry in prices)
            {
                writer.WriteVarLong((long)entry);
            }
            

        }

        public override void Deserialize(IDataReader reader)
        {

            itemUID = reader.ReadInt();
            objectGID = reader.ReadVarUShort();
            objectType = reader.ReadInt();
            var limit = (ushort)reader.ReadUShort();
            effects = new Types.ObjectEffect[limit];
            for (int i = 0; i < limit; i++)
            {
                effects[i] = ProtocolTypeManager.GetInstance<Types.ObjectEffect>(reader.ReadShort());
                effects[i].Deserialize(reader);
            }
            limit = (ushort)reader.ReadUShort();
            prices = new ulong[limit];
            for (int i = 0; i < limit; i++)
            {
                prices[i] = reader.ReadVarULong();
            }
            

        }


    }


}