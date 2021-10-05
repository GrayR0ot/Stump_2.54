using Stump.Core.IO;

namespace Stump.DofusProtocol.Types
{
    public class SpawnInformation
    {
        public const short Id = 575;

        public virtual short TypeId
        {
            get { return Id; }
        }


        public SpawnInformation()
        {
        }


        public virtual void Serialize(IDataWriter writer)
        {
        }

        public virtual void Deserialize(IDataReader reader)
        {
        }
    }
}