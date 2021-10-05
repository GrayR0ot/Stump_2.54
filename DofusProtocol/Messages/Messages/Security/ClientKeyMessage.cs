using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class ClientKeyMessage : Message
    {
        public const uint Id = 5607;

        public ClientKeyMessage(string key)
        {
            Key = key;
        }

        public ClientKeyMessage()
        {
        }

        public override uint MessageId => Id;

        public string Key { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteUTF(Key);
        }

        public override void Deserialize(IDataReader reader)
        {
            Key = reader.ReadUTF();
        }
    }
}