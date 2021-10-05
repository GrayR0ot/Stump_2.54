using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class IgnoredDeleteResultMessage : Message
    {
        public const uint Id = 5677;

        public IgnoredDeleteResultMessage(bool success, bool session, string name)
        {
            Success = success;
            Session = session;
            Name = name;
        }

        public IgnoredDeleteResultMessage()
        {
        }

        public override uint MessageId => Id;

        public bool Success { get; set; }
        public bool Session { get; set; }
        public string Name { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            var flag = new byte();
            flag = BooleanByteWrapper.SetFlag(flag, 0, Success);
            flag = BooleanByteWrapper.SetFlag(flag, 1, Session);
            writer.WriteByte(flag);
            writer.WriteUTF(Name);
        }

        public override void Deserialize(IDataReader reader)
        {
            var flag = reader.ReadByte();
            Success = BooleanByteWrapper.GetFlag(flag, 0);
            Session = BooleanByteWrapper.GetFlag(flag, 1);
            Name = reader.ReadUTF();
        }
    }
}