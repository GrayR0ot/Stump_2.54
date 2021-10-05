using Stump.Server.BaseServer.Database;
using Stump.Server.WorldServer.Game.Actors.RolePlay.Characters;
using Stump.Server.WorldServer.Game.Actors.RolePlay.Npcs;

namespace Stump.Server.WorldServer.Database.Npcs.Replies
{
    [Discriminator("GiveTitle", typeof(NpcReply), typeof(NpcReplyRecord))]
    public class GiveTitleReply : NpcReply
    {
        public GiveTitleReply(NpcReplyRecord record)
            : base(record)
        {
        }

        public short titleid
        {
            get => Record.GetParameter<short>(0u);
            set => Record.SetParameter(0u, value);
        }

        public override bool Execute(Npc npc, Character character)
        {
            bool result;
            if (!base.Execute(npc, character))
            {
                result = false;
            }
            else
            {
                character.AddTitle(titleid);
                result = true;
            }

            return result;
        }
    }
}