using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class HouseLockFromInsideRequestMessage : LockableChangeCodeMessage
    {
        public new const uint Id = 5885;

        public HouseLockFromInsideRequestMessage(string code)
        {
            Code = code;
        }

        public HouseLockFromInsideRequestMessage()
        {
        }

        public override uint MessageId => Id;

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