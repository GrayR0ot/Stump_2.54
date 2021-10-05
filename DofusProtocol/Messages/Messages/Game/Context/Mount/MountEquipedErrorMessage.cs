using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class MountEquipedErrorMessage : Message
    {
        public const uint Id = 5963;

        public MountEquipedErrorMessage(sbyte errorType)
        {
            ErrorType = errorType;
        }

        public MountEquipedErrorMessage()
        {
        }

        public override uint MessageId => Id;

        public sbyte ErrorType { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteSByte(ErrorType);
        }

        public override void Deserialize(IDataReader reader)
        {
            ErrorType = reader.ReadSByte();
        }
    }
}