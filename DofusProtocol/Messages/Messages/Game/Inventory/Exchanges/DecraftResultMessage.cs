using System;
using System.Linq;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class DecraftResultMessage : Message
    {
        public const uint Id = 6569;

        public DecraftResultMessage(DecraftedItemStackInfo[] results)
        {
            Results = results;
        }

        public DecraftResultMessage()
        {
        }

        public override uint MessageId => Id;

        public DecraftedItemStackInfo[] Results { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort((short) Results.Count());
            for (var resultsIndex = 0; resultsIndex < Results.Count(); resultsIndex++)
            {
                var objectToSend = Results[resultsIndex];
                objectToSend.Serialize(writer);
            }
        }

        public override void Deserialize(IDataReader reader)
        {
            var resultsCount = reader.ReadUShort();
            Results = new DecraftedItemStackInfo[resultsCount];
            for (var resultsIndex = 0; resultsIndex < resultsCount; resultsIndex++)
            {
                var objectToAdd = new DecraftedItemStackInfo();
                objectToAdd.Deserialize(reader);
                Results[resultsIndex] = objectToAdd;
            }
        }
    }
}