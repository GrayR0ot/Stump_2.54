using Stump.Core.IO;

namespace Stump.DofusProtocol.Types
{

    public class ObjectItemQuantityPriceDateEffects : ObjectItemGenericQuantity
    {

        public const short Id = 577;
        public override short TypeId
        {
            get { return Id; }
        }

        public double price;
        public ObjectEffects effects;
        public uint date;
        

        public ObjectItemQuantityPriceDateEffects()
        {
        }

        public ObjectItemQuantityPriceDateEffects(uint objectGID, uint quantity, double price, ObjectEffects effects, uint date)
            : base(objectGID, quantity)
        {
            this.price = price;
            this.effects = effects;
            this.date = date;
        }
        

        public override void Serialize(IDataWriter writer)
        {

            base.Serialize(writer);
            writer.WriteVarLong((long)price);
            effects.Serialize(writer);
            writer.WriteUInt(date);
            

        }

        public override void Deserialize(IDataReader reader)
        {

            base.Deserialize(reader);
            price = reader.ReadVarULong();
            effects = new ObjectEffects();
            effects.Deserialize(reader);
            date = reader.ReadUInt();
            

        }


    }


}