using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class CharacterCanBeCreatedResultMessage : Message
    {
        public const uint Id = 6733;

        public CharacterCanBeCreatedResultMessage(bool yesYouCan)
        {
            YesYouCan = yesYouCan;
        }

        public CharacterCanBeCreatedResultMessage()
        {
        }

        public override uint MessageId => Id;

        public bool YesYouCan { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteBoolean(YesYouCan);
        }

        public override void Deserialize(IDataReader reader)
        {
            YesYouCan = reader.ReadBoolean();
        }
    }
}