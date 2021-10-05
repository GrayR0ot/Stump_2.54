using System;
using System.Linq;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class JobCrafterDirectoryEntryMessage : Message
    {
        public const uint Id = 6044;

        public JobCrafterDirectoryEntryMessage(JobCrafterDirectoryEntryPlayerInfo playerInfo,
            JobCrafterDirectoryEntryJobInfo[] jobInfoList, EntityLook playerLook)
        {
            PlayerInfo = playerInfo;
            JobInfoList = jobInfoList;
            PlayerLook = playerLook;
        }

        public JobCrafterDirectoryEntryMessage()
        {
        }

        public override uint MessageId => Id;

        public JobCrafterDirectoryEntryPlayerInfo PlayerInfo { get; set; }
        public JobCrafterDirectoryEntryJobInfo[] JobInfoList { get; set; }
        public EntityLook PlayerLook { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            PlayerInfo.Serialize(writer);
            writer.WriteShort((short) JobInfoList.Count());
            for (var jobInfoListIndex = 0; jobInfoListIndex < JobInfoList.Count(); jobInfoListIndex++)
            {
                var objectToSend = JobInfoList[jobInfoListIndex];
                objectToSend.Serialize(writer);
            }

            PlayerLook.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            PlayerInfo = new JobCrafterDirectoryEntryPlayerInfo();
            PlayerInfo.Deserialize(reader);
            var jobInfoListCount = reader.ReadUShort();
            JobInfoList = new JobCrafterDirectoryEntryJobInfo[jobInfoListCount];
            for (var jobInfoListIndex = 0; jobInfoListIndex < jobInfoListCount; jobInfoListIndex++)
            {
                var objectToAdd = new JobCrafterDirectoryEntryJobInfo();
                objectToAdd.Deserialize(reader);
                JobInfoList[jobInfoListIndex] = objectToAdd;
            }

            PlayerLook = new EntityLook();
            PlayerLook.Deserialize(reader);
        }
    }
}