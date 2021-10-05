using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class EnterHavenBagRequestMessage : Message
    {
        public const uint Id = 6636;

        public EnterHavenBagRequestMessage(ulong havenBagOwner)
        {
            HavenBagOwner = havenBagOwner;
        }

        public EnterHavenBagRequestMessage()
        {
        }

        public override uint MessageId => Id;

        public ulong HavenBagOwner { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarULong(HavenBagOwner);
        }

        public override void Deserialize(IDataReader reader)
        {
            HavenBagOwner = reader.ReadVarULong();
        }
    }
}