﻿using System;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class GameFightRefreshFighterMessage : Message
    {
        public const uint Id = 6309;

        public GameFightRefreshFighterMessage(GameContextActorInformations informations)
        {
            Informations = informations;
        }

        public GameFightRefreshFighterMessage()
        {
        }

        public override uint MessageId => Id;

        public GameContextActorInformations Informations { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort(Informations.TypeId);
            Informations.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            Informations = ProtocolTypeManager.GetInstance<GameContextActorInformations>(reader.ReadShort());
            Informations.Deserialize(reader);
        }
    }
}