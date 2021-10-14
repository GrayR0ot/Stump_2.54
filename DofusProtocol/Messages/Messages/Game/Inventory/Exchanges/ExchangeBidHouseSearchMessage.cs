using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{

    public class ExchangeBidHouseSearchMessage : Message
    {

        public const uint Id = 5806;
        public override uint MessageId
        {
            get { return Id; }
        }

        public ushort genId;
        public bool follow;
        

        public ExchangeBidHouseSearchMessage()
        {
        }

        public ExchangeBidHouseSearchMessage(ushort genId, bool follow)
        {
            this.genId = genId;
            this.follow = follow;
        }
        

        public override void Serialize(IDataWriter writer)
        {

            writer.WriteVarShort((short)genId);
            writer.WriteBoolean(follow);
            

        }

        public override void Deserialize(IDataReader reader)
        {

            genId = reader.ReadVarUShort();
            follow = reader.ReadBoolean();
            

        }


    }


}