using System;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class PaddockPropertiesMessage : Message
    {
        public const uint Id = 5824;

        public PaddockPropertiesMessage(PaddockInstancesInformations properties)
        {
            Properties = properties;
        }

        public PaddockPropertiesMessage()
        {
        }

        public override uint MessageId => Id;

        public PaddockInstancesInformations Properties { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            Properties.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            Properties = new PaddockInstancesInformations();
            Properties.Deserialize(reader);
        }
    }
}