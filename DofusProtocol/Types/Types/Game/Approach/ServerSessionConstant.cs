using System;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Types
{
    [Serializable]
    public class ServerSessionConstant
    {
        public const short Id = 430;

        public ServerSessionConstant(ushort objectId)
        {
            ObjectId = objectId;
        }

        public ServerSessionConstant()
        {
        }

        public virtual short TypeId => Id;

        public uint ObjectId { get; set; }

        public virtual void Serialize(IDataWriter writer)
        {
            writer.WriteVarUInt(ObjectId);
        }

        public virtual void Deserialize(IDataReader reader)
        {
            ObjectId = reader.ReadVarUInt();
        }
    }
}