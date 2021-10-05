using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class GameContextCreateMessage : Message
    {
        public const uint Id = 200;

        public GameContextCreateMessage(sbyte context)
        {
            Context = context;
        }

        public GameContextCreateMessage()
        {
        }

        public override uint MessageId => Id;

        public sbyte Context { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteSByte(Context);
        }

        public override void Deserialize(IDataReader reader)
        {
            Context = reader.ReadSByte();
        }
    }
}