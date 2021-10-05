using System;
using System.Collections.Generic;
using System.Linq;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class TextInformationMessage : Message
    {
        public const uint Id = 780;

        public TextInformationMessage(sbyte msgType, short msgId, IEnumerable<string> parameters)
        {
            MsgType = msgType;
            MsgId = (ushort) msgId;
            Parameters = (string[]) parameters;
        }

        public TextInformationMessage()
        {
        }

        public override uint MessageId => Id;

        public sbyte MsgType { get; set; }
        public ushort MsgId { get; set; }
        public string[] Parameters { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteSByte(MsgType);
            writer.WriteVarUShort(MsgId);
            writer.WriteShort((short) Parameters.Count());
            for (var parametersIndex = 0; parametersIndex < Parameters.Count(); parametersIndex++)
                writer.WriteUTF(Parameters[parametersIndex]);
        }

        public override void Deserialize(IDataReader reader)
        {
            MsgType = reader.ReadSByte();
            MsgId = reader.ReadVarUShort();
            var parametersCount = reader.ReadUShort();
            Parameters = new string[parametersCount];
            for (var parametersIndex = 0; parametersIndex < parametersCount; parametersIndex++)
                Parameters[parametersIndex] = reader.ReadUTF();
        }
    }
}