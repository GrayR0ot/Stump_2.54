using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace AmaknaProxy.API.Protocol.Types
{
    public class GameFightEntityInformation : GameFightFighterInformations
    {
        public const short Id = 551;

        public override short TypeId
        {
            get { return Id; }
        }

        public sbyte EntityModelId;
        public uint Level;
        public double MasterId;


        public GameFightEntityInformation()
        {
        }

        public GameFightEntityInformation(double contextualId, EntityDispositionInformations disposition,
            EntityLook look, GameContextBasicSpawnInformation spawnInfo, sbyte wave, GameFightMinimalStats stats,
            uint[] previousPositions, sbyte entityModelId, uint level, double masterId)
            : base(contextualId, disposition, look, spawnInfo, wave, stats, previousPositions)
        {
            this.EntityModelId = entityModelId;
            this.Level = level;
            this.MasterId = masterId;
        }


        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteSByte(EntityModelId);
            writer.WriteVarShort((short) Level);
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