using System;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class AlliancePartialListMessage : AllianceListMessage
    {
        public new const uint Id = 6427;

        public AlliancePartialListMessage(AllianceFactSheetInformations[] alliances)
        {
            Alliances = alliances;
        }

        public AlliancePartialListMessage()
        {
        }

        public override uint MessageId => Id;

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
        }
    }
}