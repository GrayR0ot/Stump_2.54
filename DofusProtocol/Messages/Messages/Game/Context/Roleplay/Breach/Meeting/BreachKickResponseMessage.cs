using System;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class BreachKickResponseMessage : Message
    {
        public const uint Id = 6789;

        public BreachKickResponseMessage(CharacterMinimalInformations target, bool kicked)
        {
            Target = target;
            Kicked = kicked;
        }

        public BreachKickResponseMessage()
        {
        }

        public override uint MessageId => Id;

        public CharacterMinimalInformations Target { get; set; }
        public bool Kicked { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            Target.Serialize(writer);
            writer.WriteBoolean(Kicked);
        }

        public override void Deserialize(IDataReader reader)
        {
            Target = new CharacterMinimalInformations();
            Target.Deserialize(reader);
            Kicked = reader.ReadBoolean();
        }
    }
}