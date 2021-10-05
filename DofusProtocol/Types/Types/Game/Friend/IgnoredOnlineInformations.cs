using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Types
{
    [Serializable]
    public class IgnoredOnlineInformations : IgnoredInformations
    {
        public new const short Id = 105;

        public IgnoredOnlineInformations(int accountId, string accountName, ulong playerId, string playerName,
            sbyte breed, bool sex)
        {
            AccountId = accountId;
            AccountName = accountName;
            PlayerId = playerId;
            PlayerName = playerName;
            Breed = breed;
            Sex = sex;
        }

        public IgnoredOnlineInformations()
        {
        }

        public override short TypeId => Id;

        public ulong PlayerId { get; set; }
        public string PlayerName { get; set; }
        public sbyte Breed { get; set; }
        public bool Sex { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarULong(PlayerId);
            writer.WriteUTF(PlayerName);
            writer.WriteSByte(Breed);
            writer.WriteBoolean(Sex);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            PlayerId = reader.ReadVarULong();
            PlayerName = reader.ReadUTF();
            Breed = reader.ReadSByte();
            Sex = reader.ReadBoolean();
        }
    }
}