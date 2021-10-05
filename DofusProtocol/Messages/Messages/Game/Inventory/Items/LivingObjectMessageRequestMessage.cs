using System;
using System.Linq;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class LivingObjectMessageRequestMessage : Message
    {
        public const uint Id = 6066;

        public LivingObjectMessageRequestMessage(ushort msgId, string[] parameters, uint livingObject)
        {
            MsgId = msgId;
            Parameters = parameters;
            LivingObject = livingObject;
        }

        public LivingObjectMessageRequestMessage()
        {
        }

        public override uint MessageId => Id;

        public ushort MsgId { get; set; }
        public string[] Parameters { get; set; }
        public uint LivingObject { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUShort(MsgId);
            writer.WriteShort((short) Parameters.Count());
            for (var parametersIndex = 0; parametersIndex < Parameters.Count(); parametersIndex++)
                writer.WriteUTF(Parameters[parametersIndex]);
            writer.WriteVarUInt(LivingObject);
        }

        public override void Deserialize(IDataReader reader)
        {
            MsgId = reader.ReadVarUShort();
            var parametersCount = reader.ReadUShort();
            Parameters = new string[parametersCount];
            for (var parametersIndex = 0; parametersIndex < parametersCount; parametersIndex++)
                Parameters[parametersIndex] = reader.ReadUTF();
            LivingObject = reader.ReadVarUInt();
        }
    }
}