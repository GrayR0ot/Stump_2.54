using System;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class GameDataPaddockObjectAddMessage : Message
    {
        public const uint Id = 5990;

        public GameDataPaddockObjectAddMessage(PaddockItem paddockItemDescription)
        {
            PaddockItemDescription = paddockItemDescription;
        }

        public GameDataPaddockObjectAddMessage()
        {
        }

        public override uint MessageId => Id;

        public PaddockItem PaddockItemDescription { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            PaddockItemDescription.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            PaddockItemDescription = new PaddockItem();
            PaddockItemDescription.Deserialize(reader);
        }
    }
}