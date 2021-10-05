using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class TeleportHavenBagAnswerMessage : Message
    {
        public const uint Id = 6646;

        public TeleportHavenBagAnswerMessage(bool accept)
        {
            Accept = accept;
        }

        public TeleportHavenBagAnswerMessage()
        {
        }

        public override uint MessageId => Id;

        public bool Accept { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteBoolean(Accept);
        }

        public override void Deserialize(IDataReader reader)
        {
            Accept = reader.ReadBoolean();
        }
    }
}