using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class BreachTeleportRequestMessage : Message
    {
        public const uint Id = 6817;

        public override uint MessageId => Id;

        public override void Serialize(IDataWriter writer)
        {
        }

        public override void Deserialize(IDataReader reader)
        {
        }
    }
}