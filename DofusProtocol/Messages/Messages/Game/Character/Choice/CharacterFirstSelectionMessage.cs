using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class CharacterFirstSelectionMessage : CharacterSelectionMessage
    {
        public new const uint Id = 6084;

        public CharacterFirstSelectionMessage(ulong objectId, bool doTutorial)
        {
            ObjectId = objectId;
            DoTutorial = doTutorial;
        }

        public CharacterFirstSelectionMessage()
        {
        }

        public override uint MessageId => Id;

        public bool DoTutorial { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteBoolean(DoTutorial);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            DoTutorial = reader.ReadBoolean();
        }
    }
}