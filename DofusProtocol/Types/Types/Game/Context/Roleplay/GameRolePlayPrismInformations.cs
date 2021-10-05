﻿using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Types
{
    [Serializable]
    public class GameRolePlayPrismInformations : GameRolePlayActorInformations
    {
        public new const short Id = 161;

        public GameRolePlayPrismInformations(double contextualId, EntityLook look,
            EntityDispositionInformations disposition, PrismInformation prism)
        {
            ContextualId = contextualId;
            Look = look;
            Disposition = disposition;
            Prism = prism;
        }

        public GameRolePlayPrismInformations()
        {
        }

        public override short TypeId => Id;

        public PrismInformation Prism { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteShort(Prism.TypeId);
            Prism.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            Prism = ProtocolTypeManager.GetInstance<PrismInformation>(reader.ReadShort());
            Prism.Deserialize(reader);
        }
    }
}