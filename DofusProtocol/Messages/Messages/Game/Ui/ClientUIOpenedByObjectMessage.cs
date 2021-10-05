using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class ClientUIOpenedByObjectMessage : ClientUIOpenedMessage
    {
        public new const uint Id = 6463;

        public ClientUIOpenedByObjectMessage(sbyte type, uint uid)
        {
            Type = type;
            Uid = uid;
        }

        public ClientUIOpenedByObjectMessage()
        {
        }

        public override uint MessageId => Id;

        public uint Uid { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarUInt(Uid);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            Uid = reader.ReadVarUInt();
        }
    }
}