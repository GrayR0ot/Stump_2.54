using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class AcquaintanceSearchMessage : Message
    {
        public const uint Id = 6144;

        public AcquaintanceSearchMessage(string nickname)
        {
            Nickname = nickname;
        }

        public AcquaintanceSearchMessage()
        {
        }

        public override uint MessageId => Id;

        public string Nickname { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteUTF(Nickname);
        }

        public override void Deserialize(IDataReader reader)
        {
            Nickname = reader.ReadUTF();
        }
    }
}