using System;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class SpouseInformationsMessage : Message
    {
        public const uint Id = 6356;

        public SpouseInformationsMessage(FriendSpouseInformations spouse)
        {
            Spouse = spouse;
        }

        public SpouseInformationsMessage()
        {
        }

        public override uint MessageId => Id;

        public FriendSpouseInformations Spouse { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort(Spouse.TypeId);
            Spouse.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            Spouse = ProtocolTypeManager.GetInstance<FriendSpouseInformations>(reader.ReadShort());
            Spouse.Deserialize(reader);
        }
    }
}