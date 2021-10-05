using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Types
{
    [Serializable]
    public class GameContextActorInformations : GameContextActorPositionInformations
    {
        public const short Id = 150;

        public override short TypeId
        {
            get { return Id; }
        }

        public Types.EntityLook Look;


        public GameContextActorInformations()
        {
        }

        public GameContextActorInformations(double contextualId, Types.EntityDispositionInformations disposition,
            Types.EntityLook look)
            : base(contextualId, disposition)
        {
            this.Look = look;
        }


        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            Look.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            Look = new Types.EntityLook();
            Look.Deserialize(reader);
        }
    }
}