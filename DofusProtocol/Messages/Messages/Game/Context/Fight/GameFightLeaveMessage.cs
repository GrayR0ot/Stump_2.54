using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class GameFightLeaveMessage : Message
    {
        public const uint Id = 721;

        public GameFightLeaveMessage(double charId)
        {
            CharId = charId;
        }

        public GameFightLeaveMessage()
        {
        }

        public override uint MessageId => Id;

        public double CharId { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteDouble(CharId);
        }

        public override void Deserialize(IDataReader reader)
        {
            CharId = reader.ReadDouble();
        }
    }
}