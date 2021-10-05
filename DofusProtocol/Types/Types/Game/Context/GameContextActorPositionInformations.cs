
using Stump.Core.IO;

namespace Stump.DofusProtocol.Types
{

    public class GameContextActorPositionInformations
    {

        public const short Id = 566;
        public virtual short TypeId
        {
            get { return Id; }
        }

        public double ContextualId;
        public Types.EntityDispositionInformations Disposition;
        

        public GameContextActorPositionInformations()
        {
        }

        public GameContextActorPositionInformations(double contextualId, Types.EntityDispositionInformations disposition)
        {
            this.ContextualId = contextualId;
            this.Disposition = disposition;
        }
        

        public virtual void Serialize(IDataWriter writer)
        {

            writer.WriteDouble(ContextualId);
            writer.WriteShort(Disposition.TypeId);
            Disposition.Serialize(writer);
            

        }

        public virtual void Deserialize(IDataReader reader)
        {

            ContextualId = reader.ReadDouble();
            Disposition = ProtocolTypeManager.GetInstance<Types.EntityDispositionInformations>(reader.ReadShort());
            Disposition.Deserialize(reader);
            

        }


    }


}