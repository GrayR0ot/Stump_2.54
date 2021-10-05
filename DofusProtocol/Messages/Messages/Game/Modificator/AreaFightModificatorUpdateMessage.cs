using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class AreaFightModificatorUpdateMessage : Message
    {
        public const uint Id = 6493;

        public AreaFightModificatorUpdateMessage(int spellPairId)
        {
            SpellPairId = spellPairId;
        }

        public AreaFightModificatorUpdateMessage()
        {
        }

        public override uint MessageId => Id;

        public int SpellPairId { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteInt(SpellPairId);
        }

        public override void Deserialize(IDataReader reader)
        {
            SpellPairId = reader.ReadInt();
        }
    }
}