using System;
using System.Linq;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class AccountHouseMessage : Message
    {
        public const uint Id = 6315;

        public AccountHouseMessage(AccountHouseInformations[] houses)
        {
            Houses = houses;
        }

        public AccountHouseMessage()
        {
        }

        public override uint MessageId => Id;

        public AccountHouseInformations[] Houses { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort((short) Houses.Count());
            for (var housesIndex = 0; housesIndex < Houses.Count(); housesIndex++)
            {
                var objectToSend = Houses[housesIndex];
                objectToSend.Serialize(writer);
            }
        }

        public override void Deserialize(IDataReader reader)
        {
            var housesCount = reader.ReadUShort();
            Houses = new AccountHouseInformations[housesCount];
            for (var housesIndex = 0; housesIndex < housesCount; housesIndex++)
            {
                var objectToAdd = new AccountHouseInformations();
                objectToAdd.Deserialize(reader);
                Houses[housesIndex] = objectToAdd;
            }
        }
    }
}