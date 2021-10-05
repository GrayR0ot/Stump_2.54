using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class HaapiApiKeyMessage : Message
    {
        public const uint Id = 6649;

        public HaapiApiKeyMessage(string token)
        {
            Token = token;
        }

        public HaapiApiKeyMessage()
        {
        }

        public override uint MessageId => Id;

        public string Token { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteUTF(Token);
        }

        public override void Deserialize(IDataReader reader)
        {
            Token = reader.ReadUTF();
        }
    }
}