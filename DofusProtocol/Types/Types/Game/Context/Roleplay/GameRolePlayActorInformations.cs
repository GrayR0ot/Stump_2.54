﻿using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Types
{
    [Serializable]
    public class GameRolePlayActorInformations : GameContextActorInformations
    {
        public new const short Id = 141;

        public GameRolePlayActorInformations(double contextualId, EntityLook look,
            EntityDispositionInformations disposition)
        {
            ContextualId = contextualId;
            Look = look;
            Disposition = disposition;
        }

        public GameRolePlayActorInformations()
        {
        }

        public override short TypeId => Id;

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
        }
    }
}