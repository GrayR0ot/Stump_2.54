using System;
using System.Linq;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class FinishMoveListMessage : Message
    {
        public const uint Id = 6704;

        public FinishMoveListMessage(FinishMoveInformations[] finishMoves)
        {
            FinishMoves = finishMoves;
        }

        public FinishMoveListMessage()
        {
        }

        public override uint MessageId => Id;

        public FinishMoveInformations[] FinishMoves { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort((short) FinishMoves.Count());
            for (var finishMovesIndex = 0; finishMovesIndex < FinishMoves.Count(); finishMovesIndex++)
            {
                var objectToSend = FinishMoves[finishMovesIndex];
                objectToSend.Serialize(writer);
            }
        }

        public override void Deserialize(IDataReader reader)
        {
            var finishMovesCount = reader.ReadUShort();
            FinishMoves = new FinishMoveInformations[finishMovesCount];
            for (var finishMovesIndex = 0; finishMovesIndex < finishMovesCount; finishMovesIndex++)
            {
                var objectToAdd = new FinishMoveInformations();
                objectToAdd.Deserialize(reader);
                FinishMoves[finishMovesIndex] = objectToAdd;
            }
        }
    }
}