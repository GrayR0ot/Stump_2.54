using System;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class GameEntityDispositionMessage : Message
    {
        public const uint Id = 5693;

        public GameEntityDispositionMessage(IdentifiedEntityDispositionInformations disposition)
        {
            Disposition = disposition;
        }

        public GameEntityDispositionMessage()
        {
        }

        public override uint MessageId => Id;

        public IdentifiedEntityDispositionInformations Disposition { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            Disposition.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            Disposition = new IdentifiedEntityDispositionInformations();
            Disposition.Deserialize(reader);
        }
    }
}