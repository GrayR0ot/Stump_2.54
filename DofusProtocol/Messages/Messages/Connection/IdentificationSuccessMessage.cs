using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class IdentificationSuccessMessage : Message
    {
        public const uint Id = 22;

        public IdentificationSuccessMessage(bool hasRights, bool wasAlreadyConnected, string login, string nickname,
            int accountId, sbyte communityId, string secretQuestion, double accountCreation,
            double subscriptionElapsedDuration, double subscriptionEndDate, byte havenbagAvailableRoom)
        {
            HasRights = hasRights;
            WasAlreadyConnected = wasAlreadyConnected;
            Login = login;
            Nickname = nickname;
            AccountId = accountId;
            CommunityId = communityId;
            SecretQuestion = secretQuestion;
            AccountCreation = accountCreation;
            SubscriptionElapsedDuration = subscriptionElapsedDuration;
            SubscriptionEndDate = subscriptionEndDate;
            HavenbagAvailableRoom = havenbagAvailableRoom;
        }

        public IdentificationSuccessMessage()
        {
        }

        public override uint MessageId => Id;

        public bool HasRights { get; set; }
        public bool WasAlreadyConnected { get; set; }
        public string Login { get; set; }
        public string Nickname { get; set; }
        public int AccountId { get; set; }
        public sbyte CommunityId { get; set; }
        public string SecretQuestion { get; set; }
        public double AccountCreation { get; set; }
        public double SubscriptionElapsedDuration { get; set; }
        public double SubscriptionEndDate { get; set; }
        public byte HavenbagAvailableRoom { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            var flag = new byte();
            flag = BooleanByteWrapper.SetFlag(flag, 0, HasRights);
            flag = BooleanByteWrapper.SetFlag(flag, 1, WasAlreadyConnected);
            writer.WriteByte(flag);
            writer.WriteUTF(Login);
            writer.WriteUTF(Nickname);
            writer.WriteInt(AccountId);
            writer.WriteSByte(CommunityId);
            writer.WriteUTF(SecretQuestion);
            writer.WriteDouble(AccountCreation);
            writer.WriteDouble(SubscriptionElapsedDuration);
            writer.WriteDouble(SubscriptionEndDate);
            writer.WriteByte(HavenbagAvailableRoom);
        }

        public override void Deserialize(IDataReader reader)
        {
            var flag = reader.ReadByte();
            HasRights = BooleanByteWrapper.GetFlag(flag, 0);
            WasAlreadyConnected = BooleanByteWrapper.GetFlag(flag, 1);
            Login = reader.ReadUTF();
            Nickname = reader.ReadUTF();
            AccountId = reader.ReadInt();
            CommunityId = reader.ReadSByte();
            SecretQuestion = reader.ReadUTF();
            AccountCreation = reader.ReadDouble();
            SubscriptionElapsedDuration = reader.ReadDouble();
            SubscriptionEndDate = reader.ReadDouble();
            HavenbagAvailableRoom = reader.ReadByte();
        }
    }
}