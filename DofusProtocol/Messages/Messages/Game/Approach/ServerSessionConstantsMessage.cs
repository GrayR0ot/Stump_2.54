using System;
using System.Linq;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class ServerSessionConstantsMessage : Message
    {
        public const uint Id = 6434;

        public ServerSessionConstantsMessage(ServerSessionConstant[] variables)
        {
            Variables = variables;
        }

        public ServerSessionConstantsMessage()
        {
        }

        public override uint MessageId => Id;

        public ServerSessionConstant[] Variables { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort((short) Variables.Count());
            for (var variablesIndex = 0; variablesIndex < Variables.Count(); variablesIndex++)
            {
                var objectToSend = Variables[variablesIndex];
                writer.WriteShort(objectToSend.TypeId);
                objectToSend.Serialize(writer);
            }
        }

        public override void Deserialize(IDataReader reader)
        {
            var variablesCount = reader.ReadUShort();
            Variables = new ServerSessionConstant[variablesCount];
            for (var variablesIndex = 0; variablesIndex < variablesCount; variablesIndex++)
            {
                var objectToAdd = ProtocolTypeManager.GetInstance<ServerSessionConstant>(reader.ReadShort());
                objectToAdd.Deserialize(reader);
                Variables[variablesIndex] = objectToAdd;
            }
        }
    }
}