using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class GuildCreationResultMessage : Message
    {
        public const uint Id = 5554;

        public GuildCreationResultMessage(sbyte result)
        {
            Result = result;
        }

        public GuildCreationResultMessage()
        {
        }

        public override uint MessageId => Id;

        public sbyte Result { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteSByte(Result);
        }

        public override void Deserialize(IDataReader reader)
        {
            Result = reader.ReadSByte();
        }
    }
}