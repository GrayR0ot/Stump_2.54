using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class GameFightTurnFinishMessage : Message
    {
        public const uint Id = 718;

        public GameFightTurnFinishMessage(bool isAfk)
        {
            IsAfk = isAfk;
        }

        public GameFightTurnFinishMessage()
        {
        }

        public override uint MessageId => Id;

        public bool IsAfk { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteBoolean(IsAfk);
        }

        public override void Deserialize(IDataReader reader)
        {
            IsAfk = reader.ReadBoolean();
        }
    }
}