using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class DungeonPartyFinderAvailableDungeonsRequestMessage : Message
    {
        public const uint Id = 6240;

        public override uint MessageId => Id;

        public override void Serialize(IDataWriter writer)
        {
        }

        public override void Deserialize(IDataReader reader)
        {
        }
    }
}