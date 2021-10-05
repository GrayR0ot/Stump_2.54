using System;
using System.Linq;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class StartupActionsListMessage : Message
    {
        public const uint Id = 1301;

        public StartupActionsListMessage(StartupActionAddObject[] actions)
        {
            Actions = actions;
        }

        public StartupActionsListMessage()
        {
        }

        public override uint MessageId => Id;

        public StartupActionAddObject[] Actions { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort((short) Actions.Count());
            for (var actionsIndex = 0; actionsIndex < Actions.Count(); actionsIndex++)
            {
                var objectToSend = Actions[actionsIndex];
                objectToSend.Serialize(writer);
            }
        }

        public override void Deserialize(IDataReader reader)
        {
            var actionsCount = reader.ReadUShort();
            Actions = new StartupActionAddObject[actionsCount];
            for (var actionsIndex = 0; actionsIndex < actionsCount; actionsIndex++)
            {
                var objectToAdd = new StartupActionAddObject();
                objectToAdd.Deserialize(reader);
                Actions[actionsIndex] = objectToAdd;
            }
        }
    }
}