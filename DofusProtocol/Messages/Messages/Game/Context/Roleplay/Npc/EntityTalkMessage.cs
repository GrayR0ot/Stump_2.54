using System;
using System.Linq;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class EntityTalkMessage : Message
    {
        public const uint Id = 6110;

        public EntityTalkMessage(double entityId, ushort textId, string[] parameters)
        {
            EntityId = entityId;
            TextId = textId;
            Parameters = parameters;
        }

        public EntityTalkMessage()
        {
        }

        public override uint MessageId => Id;

        public double EntityId { get; set; }
        public ushort TextId { get; set; }
        public string[] Parameters { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteDouble(EntityId);
            writer.WriteVarUShort(TextId);
            writer.WriteShort((short) Parameters.Count());
            for (var parametersIndex = 0; parametersIndex < Parameters.Count(); parametersIndex++)
                writer.WriteUTF(Parameters[parametersIndex]);
        }

        public override void Deserialize(IDataReader reader)
        {
            EntityId = reader.ReadDouble();
            TextId = reader.ReadVarUShort();
            var parametersCount = reader.ReadUShort();
            Parameters = new string[parametersCount];
            for (var parametersIndex = 0; parametersIndex < parametersCount; parametersIndex++)
                Parameters[parametersIndex] = reader.ReadUTF();
        }
    }
}