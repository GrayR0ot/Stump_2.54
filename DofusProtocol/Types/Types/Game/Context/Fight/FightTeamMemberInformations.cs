using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Types
{
    [Serializable]
    public class FightTeamMemberInformations
    {
        public const short Id = 44;

        public FightTeamMemberInformations(double objectId)
        {
            ObjectId = objectId;
        }

        public FightTeamMemberInformations()
        {
        }

        public virtual short TypeId => Id;

        public double ObjectId { get; set; }

        public virtual void Serialize(IDataWriter writer)
        {
            writer.WriteDouble(ObjectId);
        }

        public virtual void Deserialize(IDataReader reader)
        {
            ObjectId = reader.ReadDouble();
        }
    }
}