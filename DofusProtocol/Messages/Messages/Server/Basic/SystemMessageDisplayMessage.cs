using System;
using System.Linq;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class SystemMessageDisplayMessage : Message
    {
        public const uint Id = 189;

        public SystemMessageDisplayMessage(bool hangUp, ushort msgId, string[] parameters)
        {
            HangUp = hangUp;
            MsgId = msgId;
            Parameters = parameters;
        }

        public SystemMessageDisplayMessage()
        {
        }

        public override uint MessageId => Id;

        public bool HangUp { get; set; }
        public ushort MsgId { get; set; }
        public string[] Parameters { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteBoolean(HangUp);
            writer.WriteVarUShort(MsgId);
            writer.WriteShort((short) Parameters.Count());
            for (var parametersIndex = 0; parametersIndex < Parameters.Count(); parametersIndex++)
                writer.WriteUTF(Parameters[parametersIndex]);
        }

        public override void Deserialize(IDataReader reader)
        {
            HangUp = reader.ReadBoolean();
            MsgId = reader.ReadVarUShort();
            var parametersCount = reader.ReadUShort();
            Parameters = new string[parametersCount];
            for (var parametersIndex = 0; parametersIndex < parametersCount; parametersIndex++)
                Parameters[parametersIndex] = reader.ReadUTF();
        }
    }
}