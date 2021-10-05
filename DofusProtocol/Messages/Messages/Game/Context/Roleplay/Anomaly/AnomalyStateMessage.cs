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

        public short subAreaId;
        public bool open;
        public long closingTime;
        

        public AnomalyStateMessage()
        {
        }

        public AnomalyStateMessage(short subAreaId, bool open, long closingTime)
        {
            this.subAreaId = subAreaId;
            this.open = open;
            this.closingTime = closingTime;
        }
        

        public override void Serialize(IDataWriter writer)
        {

            writer.WriteVarShort(subAreaId);
            writer.WriteBoolean(open);
            writer.WriteVarLong(closingTime);
            

        }

        public override void Deserialize(IDataReader reader)
        {

            subAreaId = reader.ReadVarShort();
            open = reader.ReadBoolean();
            closingTime = reader.ReadVarLong();
            

        }


    }


}