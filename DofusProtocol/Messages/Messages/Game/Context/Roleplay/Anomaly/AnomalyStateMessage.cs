using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{

    public class AnomalyStateMessage : Message
    {

        public const uint Id = 6831;
        public override uint MessageId
        {
            get { return Id; }
        }

        public uint subAreaId;
        public bool open;
        public double closingTime;
        

        public AnomalyStateMessage()
        {
        }

        public AnomalyStateMessage(uint subAreaId, bool open, double closingTime)
        {
            this.subAreaId = subAreaId;
            this.open = open;
            this.closingTime = closingTime;
        }
        

        public override void Serialize(IDataWriter writer)
        {

            writer.WriteVarUInt(subAreaId);
            writer.WriteBoolean(open);
            writer.WriteVarLong((long)closingTime);
            

        }

        public override void Deserialize(IDataReader reader)
        {

            subAreaId = reader.ReadVarUInt();
            open = reader.ReadBoolean();
            closingTime = reader.ReadVarULong();
            

        }


    }


}