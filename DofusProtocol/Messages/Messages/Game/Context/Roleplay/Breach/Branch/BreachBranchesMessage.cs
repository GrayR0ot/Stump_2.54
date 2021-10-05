using System;
using System.Linq;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class BreachBranchesMessage : Message
    {
        public const uint Id = 6812;

        public BreachBranchesMessage(ExtendedBreachBranch[] branches)
        {
            Branches = branches;
        }

        public BreachBranchesMessage()
        {
        }

        public override uint MessageId => Id;

        public ExtendedBreachBranch[] Branches { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort((short) Branches.Count());
            for (var branchesIndex = 0; branchesIndex < Branches.Count(); branchesIndex++)
            {
                var objectToSend = Branches[branchesIndex];
                objectToSend.Serialize(writer);
            }
        }

        public override void Deserialize(IDataReader reader)
        {
            var branchesCount = reader.ReadUShort();
            Branches = new ExtendedBreachBranch[branchesCount];
            for (var branchesIndex = 0; branchesIndex < branchesCount; branchesIndex++)
            {
                var objectToAdd = new ExtendedBreachBranch();
                objectToAdd.Deserialize(reader);
                Branches[branchesIndex] = objectToAdd;
            }
        }
    }
}