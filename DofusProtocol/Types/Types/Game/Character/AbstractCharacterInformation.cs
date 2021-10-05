using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Types
{
    [Serializable]
    public class AbstractCharacterInformation
    {
        public const short Id = 400;

        public AbstractCharacterInformation(double objectId)
        {
            ObjectId = objectId;
        }

        public AbstractCharacterInformation()
        {
        }

        public virtual short TypeId => Id;

        public double ObjectId { get; set; }

        public virtual void Serialize(IDataWriter writer)
        {
            writer.WriteVarLong((long)ObjectId);
        }

        public virtual void Deserialize(IDataReader reader)
        {
            ObjectId = reader.ReadVarULong();
        }
    }
}