using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class HavenBagDailyLoteryMessage : Message
    {
        public const uint Id = 6644;

        public HavenBagDailyLoteryMessage(sbyte returnType, string gameActionId)
        {
            ReturnType = returnType;
            GameActionId = gameActionId;
        }

        public HavenBagDailyLoteryMessage()
        {
        }

        public override uint MessageId => Id;

        public sbyte ReturnType { get; set; }
        public string GameActionId { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteSByte(ReturnType);
            writer.WriteUTF(GameActionId);
        }

        public override void Deserialize(IDataReader reader)
        {
            ReturnType = reader.ReadSByte();
            GameActionId = reader.ReadUTF();
        }
    }
}