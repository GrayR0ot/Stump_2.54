using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Types
{
    [Serializable]
    public class ObjectEffectDuration : ObjectEffect
    {
        public new const short Id = 75;

        public ObjectEffectDuration(ushort actionId, ushort days, sbyte hours, sbyte minutes)
        {
            ActionId = actionId;
            Days = days;
            Hours = hours;
            Minutes = minutes;
        }

        public ObjectEffectDuration()
        {
        }

        public override short TypeId => Id;

        public ushort Days { get; set; }
        public sbyte Hours { get; set; }
        public sbyte Minutes { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarUShort(Days);
            writer.WriteSByte(Hours);
            writer.WriteSByte(Minutes);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            Days = reader.ReadVarUShort();
            Hours = reader.ReadSByte();
            Minutes = reader.ReadSByte();
        }
    }
}