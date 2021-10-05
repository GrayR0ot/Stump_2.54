using System;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class AchievementDetailsMessage : Message
    {
        public const uint Id = 6378;

        public AchievementDetailsMessage(Achievement achievement)
        {
            Achievement = achievement;
        }

        public AchievementDetailsMessage()
        {
        }

        public override uint MessageId => Id;

        public Achievement Achievement { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            Achievement.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            Achievement = new Achievement();
            Achievement.Deserialize(reader);
        }
    }
}