﻿using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class GameRolePlayPlayerLifeStatusMessage : Message
    {
        public const uint Id = 5996;

        public GameRolePlayPlayerLifeStatusMessage(sbyte state, double phenixMapId)
        {
            State = state;
            PhenixMapId = phenixMapId;
        }

        public GameRolePlayPlayerLifeStatusMessage()
        {
        }

        public override uint MessageId => Id;

        public sbyte State { get; set; }
        public double PhenixMapId { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteSByte(State);
            writer.WriteDouble(PhenixMapId);
        }

        public override void Deserialize(IDataReader reader)
        {
            State = reader.ReadSByte();
            PhenixMapId = reader.ReadDouble();
        }
    }
}