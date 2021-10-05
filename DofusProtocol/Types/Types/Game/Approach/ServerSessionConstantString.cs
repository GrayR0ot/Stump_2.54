using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Types
{
    [Serializable]
    public class ServerSessionConstantString : ServerSessionConstant
    {
        public new const short Id = 436;

        public ServerSessionConstantString(ushort objectId, string value)
        {
            ObjectId = objectId;
            Value = value;
        }

        public ServerSessionConstantString()
        {
        }

        public override short TypeId => Id;

        public string Value { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteUTF(Value);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            Value = reader.ReadUTF();
        }
    }
}