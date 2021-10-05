using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class IdentificationSuccessWithLoginTokenMessage : IdentificationSuccessMessage
    {
        public new const uint Id = 6209;

        public IdentificationSuccessWithLoginTokenMessage(bool hasRights, bool wasAlreadyConnected, string login,
            string nickname, int accountId, sbyte communityId, string secretQuestion, double accountCreation,
            double subscriptionElapsedDuration, double subscriptionEndDate, byte havenbagAvailableRoom,
            string loginToken)
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
            LoginToken = loginToken;
        }

        public IdentificationSuccessWithLoginTokenMessage()
        {
        }

        public override uint MessageId => Id;

        public string LoginToken { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteUTF(LoginToken);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            LoginToken = reader.ReadUTF();
        }
    }
}