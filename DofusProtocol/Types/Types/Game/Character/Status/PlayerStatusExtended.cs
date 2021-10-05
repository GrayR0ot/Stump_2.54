using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Types
{
    [Serializable]
    public class PlayerStatusExtended : PlayerStatus
    {
        public new const short Id = 414;

        public PlayerStatusExtended(sbyte statusId, string message)
        {
            StatusId = statusId;
            Message = message;
        }

        public PlayerStatusExtended()
        {
        }

        public override short TypeId => Id;

        public string Message { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteUTF(Message);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            Message = reader.ReadUTF();
        }
    }
}