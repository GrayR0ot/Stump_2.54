using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{

    public class WatchInventoryContentMessage : InventoryContentMessage
    {

        public const uint Id = 6849;
        public override uint MessageId
        {
            get { return Id; }
        }



        public WatchInventoryContentMessage()
        {
        }

        public WatchInventoryContentMessage(ObjectItem[] objects, ulong kamas)
            : base(objects, kamas)
        {
        }
        

        public override void Serialize(IDataWriter writer)
        {

            base.Serialize(writer);
            

        }

        public override void Deserialize(IDataReader reader)
        {

            base.Deserialize(reader);
            

        }


    }


}