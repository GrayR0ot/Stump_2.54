using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class SpouseStatusMessage : Message
    {
        public const uint Id = 6265;

        public SpouseStatusMessage(bool hasSpouse)
        {
            HasSpouse = hasSpouse;
        }

        public SpouseStatusMessage()
        {
        }

        public override uint MessageId => Id;

        public bool HasSpouse { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteBoolean(HasSpouse);
        }

        public override void Deserialize(IDataReader reader)
        {
            HasSpouse = reader.ReadBoolean();
        }
    }
}