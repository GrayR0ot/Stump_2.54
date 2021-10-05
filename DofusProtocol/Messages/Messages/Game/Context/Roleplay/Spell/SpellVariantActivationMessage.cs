using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class SpellVariantActivationMessage : Message
    {
        public const uint Id = 6705;
        public bool result;
        public ushort spellId;

        public SpellVariantActivationMessage(ushort spellId, bool result)
        {
            this.spellId = spellId;
            this.result = result;
        }

        public SpellVariantActivationMessage()
        {
        }

        public override uint MessageId => Id;

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUShort(spellId);
            writer.WriteBoolean(result);
        }

        public override void Deserialize(IDataReader reader)
        {
            spellId = reader.ReadVarUShort();
            result = reader.ReadBoolean();
        }
    }
}