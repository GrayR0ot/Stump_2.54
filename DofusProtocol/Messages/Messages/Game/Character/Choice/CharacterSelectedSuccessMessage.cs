using System;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class CharacterSelectedSuccessMessage : Message
    {
        public const uint Id = 153;

        public CharacterSelectedSuccessMessage(CharacterBaseInformations infos, bool isCollectingStats)
        {
            Infos = infos;
            IsCollectingStats = isCollectingStats;
        }

        public CharacterSelectedSuccessMessage()
        {
        }

        public override uint MessageId => Id;

        public CharacterBaseInformations Infos { get; set; }
        public bool IsCollectingStats { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            Infos.Serialize(writer);
            writer.WriteBoolean(IsCollectingStats);
        }

        public override void Deserialize(IDataReader reader)
        {
            Infos = new CharacterBaseInformations();
            Infos.Deserialize(reader);
            IsCollectingStats = reader.ReadBoolean();
        }
    }
}