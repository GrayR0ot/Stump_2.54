using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class LockableUseCodeMessage : Message
    {
        public const uint Id = 5667;

        public LockableUseCodeMessage(string code)
        {
            Code = code;
        }

        public LockableUseCodeMessage()
        {
        }

        public override uint MessageId => Id;

        public string Code { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteUTF(Code);
        }

        public override void Deserialize(IDataReader reader)
        {
            Code = reader.ReadUTF();
        }
    }
}