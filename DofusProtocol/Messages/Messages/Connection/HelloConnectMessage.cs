using System;
using System.Linq;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class HelloConnectMessage : Message
    {
        public const uint Id = 3;

        public HelloConnectMessage(string salt, sbyte[] key)
        {
            Salt = salt;
            Key = key;
        }

        public HelloConnectMessage()
        {
        }

        public override uint MessageId => Id;

        public string Salt { get; set; }
        public sbyte[] Key { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteUTF(Salt);
            writer.WriteVarInt(Key.Count());
            for (var keyIndex = 0; keyIndex < Key.Count(); keyIndex++) writer.WriteSByte(Key[keyIndex]);
        }

        public override void Deserialize(IDataReader reader)
        {
            Salt = reader.ReadUTF();
            var keyCount = reader.ReadVarInt();
            Key = new sbyte[keyCount];
            for (var keyIndex = 0; keyIndex < keyCount; keyIndex++) Key[keyIndex] = reader.ReadSByte();
        }
    }
}