using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages.Custom
{
    public class ErrorMessage : Message
    {
        public byte[] data;
        public string error;

        public ErrorMessage(byte[] data, string error)
        {
            this.data = data;
            this.error = error;
        }

        public override uint MessageId => 0;

        public override void Serialize(IDataWriter writer)
        {
            throw new NotImplementedException();
        }

        public override void Deserialize(IDataReader reader)
        {
            throw new NotImplementedException();
        }
    }
}