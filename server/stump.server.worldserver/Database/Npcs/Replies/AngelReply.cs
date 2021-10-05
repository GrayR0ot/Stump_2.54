using Stump.DofusProtocol.Enums;
using Stump.Server.BaseServer.Database;
using Stump.Server.WorldServer.Game.Actors.RolePlay.Characters;
using Stump.Server.WorldServer.Game.Actors.RolePlay.Npcs;

namespace Stump.Server.WorldServer.Database.Npcs.Replies
{
    [Discriminator("Angel", typeof(NpcReply), typeof(NpcReplyRecord))]
    public class AngelReply : NpcReply
    {
        public AngelReply(NpcReplyRecord record) : base(record)
        {
        }

        public override bool Execute(Npc npc, Character character)
        {
            character.ChangeAlignementSide(AlignmentSideEnum.ALIGNMENT_ANGEL);
            return true;
        }
    }
}