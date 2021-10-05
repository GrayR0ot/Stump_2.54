using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Types
{
    [Serializable]
    public class GameFightEntityInformation : GameFightFighterInformations
    {
        public new const short Id = 551;

        public GameFightEntityInformation(double contextualId, EntityLook look,
            EntityDispositionInformations disposition, sbyte teamId, sbyte wave, bool alive,
            GameFightMinimalStats stats, ushort[] previousPositions, sbyte entityModelId, ushort level, double masterId)
        {
            ContextualId = contextualId;
            Look = look;
            Disposition = disposition;
            TeamId = teamId;
            Wave = wave;
            Alive = alive;
            Stats = stats;
            PreviousPositions = previousPositions;
            EntityModelId = entityModelId;
            Level = level;
            MasterId = masterId;
        }

        public GameFightEntityInformation()
        {
        }

        public override short TypeId => Id;

        public sbyte EntityModelId { get; set; }
        public ushort Level { get; set; }
        public double MasterId { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteSByte(EntityModelId);
            writer.WriteVarUShort(Level);
            writer.WriteDouble(MasterId);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            EntityModelId = reader.ReadSByte();
            Level = reader.ReadVarUShort();
            MasterId = reader.ReadDouble();
        }
    }
}