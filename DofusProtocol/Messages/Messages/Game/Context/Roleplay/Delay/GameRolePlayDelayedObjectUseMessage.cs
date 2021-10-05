using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class GameRolePlayDelayedObjectUseMessage : GameRolePlayDelayedActionMessage
    {
        public new const uint Id = 6425;

        public GameRolePlayDelayedObjectUseMessage(double delayedCharacterId, sbyte delayTypeId, double delayEndTime,
            ushort objectGID)
        {
            DelayedCharacterId = delayedCharacterId;
            DelayTypeId = delayTypeId;
            DelayEndTime = delayEndTime;
            ObjectGID = objectGID;
        }

        public GameRolePlayDelayedObjectUseMessage()
        {
        }

        public override uint MessageId => Id;

        public ushort ObjectGID { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarUShort(ObjectGID);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            ObjectGID = reader.ReadVarUShort();
        }
    }
}