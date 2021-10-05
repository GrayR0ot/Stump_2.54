using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class AbstractGameActionFightTargetedAbilityMessage : AbstractGameActionMessage
    {
        public new const uint Id = 6118;

        public AbstractGameActionFightTargetedAbilityMessage(ushort actionId, double sourceId, bool silentCast,
            bool verboseCast, double targetId, short destinationCellId, sbyte critical)
        {
            ActionId = actionId;
            SourceId = sourceId;
            SilentCast = silentCast;
            VerboseCast = verboseCast;
            TargetId = targetId;
            DestinationCellId = destinationCellId;
            Critical = critical;
        }

        public AbstractGameActionFightTargetedAbilityMessage()
        {
        }

        public override uint MessageId => Id;

        public bool SilentCast { get; set; }
        public bool VerboseCast { get; set; }
        public double TargetId { get; set; }
        public short DestinationCellId { get; set; }
        public sbyte Critical { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            var flag = new byte();
            flag = BooleanByteWrapper.SetFlag(flag, 0, SilentCast);
            flag = BooleanByteWrapper.SetFlag(flag, 1, VerboseCast);
            writer.WriteByte(flag);
            writer.WriteDouble(TargetId);
            writer.WriteShort(DestinationCellId);
            writer.WriteSByte(Critical);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            var flag = reader.ReadByte();
            SilentCast = BooleanByteWrapper.GetFlag(flag, 0);
            VerboseCast = BooleanByteWrapper.GetFlag(flag, 1);
            TargetId = reader.ReadDouble();
            DestinationCellId = reader.ReadShort();
            Critical = reader.ReadSByte();
        }
    }
}