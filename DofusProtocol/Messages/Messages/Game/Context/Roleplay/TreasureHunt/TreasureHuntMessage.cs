using System;
using System.Linq;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class TreasureHuntMessage : Message
    {
        public const uint Id = 6486;

        public TreasureHuntMessage(sbyte questType, double startMapId, TreasureHuntStep[] knownStepsList,
            sbyte totalStepCount, uint checkPointCurrent, uint checkPointTotal, int availableRetryCount,
            TreasureHuntFlag[] flags)
        {
            QuestType = questType;
            StartMapId = startMapId;
            KnownStepsList = knownStepsList;
            TotalStepCount = totalStepCount;
            CheckPointCurrent = checkPointCurrent;
            CheckPointTotal = checkPointTotal;
            AvailableRetryCount = availableRetryCount;
            Flags = flags;
        }

        public TreasureHuntMessage()
        {
        }

        public override uint MessageId => Id;

        public sbyte QuestType { get; set; }
        public double StartMapId { get; set; }
        public TreasureHuntStep[] KnownStepsList { get; set; }
        public sbyte TotalStepCount { get; set; }
        public uint CheckPointCurrent { get; set; }
        public uint CheckPointTotal { get; set; }
        public int AvailableRetryCount { get; set; }
        public TreasureHuntFlag[] Flags { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteSByte(QuestType);
            writer.WriteDouble(StartMapId);
            writer.WriteShort((short) KnownStepsList.Count());
            for (var knownStepsListIndex = 0; knownStepsListIndex < KnownStepsList.Count(); knownStepsListIndex++)
            {
                var objectToSend = KnownStepsList[knownStepsListIndex];
                writer.WriteShort(objectToSend.TypeId);
                objectToSend.Serialize(writer);
            }

            writer.WriteSByte(TotalStepCount);
            writer.WriteVarUInt(CheckPointCurrent);
            writer.WriteVarUInt(CheckPointTotal);
            writer.WriteInt(AvailableRetryCount);
            writer.WriteShort((short) Flags.Count());
            for (var flagsIndex = 0; flagsIndex < Flags.Count(); flagsIndex++)
            {
                var objectToSend = Flags[flagsIndex];
                objectToSend.Serialize(writer);
            }
        }

        public override void Deserialize(IDataReader reader)
        {
            QuestType = reader.ReadSByte();
            StartMapId = reader.ReadDouble();
            var knownStepsListCount = reader.ReadUShort();
            KnownStepsList = new TreasureHuntStep[knownStepsListCount];
            for (var knownStepsListIndex = 0; knownStepsListIndex < knownStepsListCount; knownStepsListIndex++)
            {
                var objectToAdd = ProtocolTypeManager.GetInstance<TreasureHuntStep>(reader.ReadShort());
                objectToAdd.Deserialize(reader);
                KnownStepsList[knownStepsListIndex] = objectToAdd;
            }

            TotalStepCount = reader.ReadSByte();
            CheckPointCurrent = reader.ReadVarUInt();
            CheckPointTotal = reader.ReadVarUInt();
            AvailableRetryCount = reader.ReadInt();
            var flagsCount = reader.ReadUShort();
            Flags = new TreasureHuntFlag[flagsCount];
            for (var flagsIndex = 0; flagsIndex < flagsCount; flagsIndex++)
            {
                var objectToAdd = new TreasureHuntFlag();
                objectToAdd.Deserialize(reader);
                Flags[flagsIndex] = objectToAdd;
            }
        }
    }
}