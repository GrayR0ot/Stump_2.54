using System;
using System.Linq;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Types
{
    [Serializable]
    public class GameFightFighterInformations : GameContextActorInformations
    {
        public const short Id = 143;

        public override short TypeId
        {
            get { return Id; }
        }

        public Types.GameContextBasicSpawnInformation SpawnInfo;
        public sbyte Wave;
        public Types.GameFightMinimalStats Stats;
        public uint[] PreviousPositions;


        public GameFightFighterInformations()
        {
        }

        public GameFightFighterInformations(double contextualId, Types.EntityDispositionInformations disposition,
            Types.EntityLook look, Types.GameContextBasicSpawnInformation spawnInfo, sbyte wave,
            Types.GameFightMinimalStats stats, uint[] previousPositions)
            : base(contextualId, disposition, look)
        {
            this.SpawnInfo = spawnInfo;
            this.Wave = wave;
            this.Stats = stats;
            this.PreviousPositions = previousPositions;
        }


        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            SpawnInfo.Serialize(writer);
            writer.WriteSByte(Wave);
            writer.WriteShort(Stats.TypeId);
            Stats.Serialize(writer);
            writer.WriteShort((short) PreviousPositions.Length);
            foreach (var entry in PreviousPositions)
            {
                writer.WriteVarShort((short)entry);
            }
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            SpawnInfo = new Types.GameContextBasicSpawnInformation();
            SpawnInfo.Deserialize(reader);
            Wave = reader.ReadSByte();
            Stats = ProtocolTypeManager.GetInstance<Types.GameFightMinimalStats>(reader.ReadShort());
            Stats.Deserialize(reader);
            var limit = (ushort) reader.ReadUShort();
            PreviousPositions = new uint[limit];
            for (int i = 0; i < limit; i++)
            {
                PreviousPositions[i] = reader.ReadVarUShort();
            }
        }
    }
}