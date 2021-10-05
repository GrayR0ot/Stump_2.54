using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class ExchangeSetCraftRecipeMessage : Message
    {
        public const uint Id = 6389;

        public ExchangeSetCraftRecipeMessage(ushort objectGID)
        {
            ObjectGID = objectGID;
        }

        public ExchangeSetCraftRecipeMessage()
        {
        }

        public override uint MessageId => Id;

        public ushort ObjectGID { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUShort(ObjectGID);
        }

        public override void Deserialize(IDataReader reader)
        {
            ObjectGID = reader.ReadVarUShort();
        }
    }
}