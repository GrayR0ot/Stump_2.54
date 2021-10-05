using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class SpellVariantActivationRequestMessage : Message
    {
        public const uint Id = 6707;
        public ushort spellId;

        public SpellVariantActivationRequestMessage(ushort spellId)
        {
            this.spellId = spellId;
        }

        public SpellVariantActivationRequestMessage()
        {
        }

        public override uint MessageId => Id;

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUShort(spellId);
        }

        public override void Deserialize(IDataReader reader)
        {
            spellId = reader.ReadVarUShort();
        }
    }
}