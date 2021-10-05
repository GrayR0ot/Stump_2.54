using System;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    [Serializable]
    public class ArenaFighterLeaveMessage : Message
    {
        public const uint Id = 6700;

        public ArenaFighterLeaveMessage(CharacterBasicMinimalInformations leaver)
        {
            Leaver = leaver;
        }

        public ArenaFighterLeaveMessage()
        {
        }

        public override uint MessageId => Id;

        public CharacterBasicMinimalInformations Leaver { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            Leaver.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            Leaver = new CharacterBasicMinimalInformations();
            Leaver.Deserialize(reader);
        }
    }
}