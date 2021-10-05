using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class HaapiTokenMessage : Message
    {
        public const uint Id = 6767;

        public HaapiTokenMessage(string token)
        {
            Token = token;
        }

        public HaapiTokenMessage()
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