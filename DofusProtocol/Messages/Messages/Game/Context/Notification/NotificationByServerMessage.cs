using System;
using System.Linq;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class NotificationByServerMessage : Message
    {
        public const uint Id = 6103;

        public NotificationByServerMessage(ushort objectId, string[] parameters, bool forceOpen)
        {
            ObjectId = objectId;
            Parameters = parameters;
            ForceOpen = forceOpen;
        }

        public NotificationByServerMessage()
        {
        }

        public override uint MessageId => Id;

        public ushort ObjectId { get; set; }
        public string[] Parameters { get; set; }
        public bool ForceOpen { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUShort(ObjectId);
            writer.WriteShort((short) Parameters.Count());
            for (var parametersIndex = 0; parametersIndex < Parameters.Count(); parametersIndex++)
                writer.WriteUTF(Parameters[parametersIndex]);
            writer.WriteBoolean(ForceOpen);
        }

        public override void Deserialize(IDataReader reader)
        {
            ObjectId = reader.ReadVarUShort();
            var parametersCount = reader.ReadUShort();
            Parameters = new string[parametersCount];
            for (var parametersIndex = 0; parametersIndex < parametersCount; parametersIndex++)
                Parameters[parametersIndex] = reader.ReadUTF();
            ForceOpen = reader.ReadBoolean();
        }
    }
}