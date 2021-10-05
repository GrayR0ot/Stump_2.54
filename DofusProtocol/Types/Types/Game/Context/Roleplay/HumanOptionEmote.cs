using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Types
{
    [Serializable]
    public class HumanOptionEmote : HumanOption
    {
        public new const short Id = 407;

        public HumanOptionEmote(byte emoteId, double emoteStartTime)
        {
            EmoteId = emoteId;
            EmoteStartTime = emoteStartTime;
        }

        public HumanOptionEmote()
        {
        }

        public override short TypeId => Id;

        public byte EmoteId { get; set; }
        public double EmoteStartTime { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteByte(EmoteId);
            writer.WriteDouble(EmoteStartTime);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            EmoteId = reader.ReadByte();
            EmoteStartTime = reader.ReadDouble();
        }
    }
}