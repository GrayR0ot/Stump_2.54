using Stump.DofusProtocol.Messages;
using Stump.Server.BaseServer.Database;
using Stump.Server.WorldServer.Game.Actors.RolePlay.Characters;
using Stump.Server.WorldServer.Game.Actors.RolePlay.Npcs;

namespace Stump.Server.WorldServer.Database.Npcs.Replies.StartQuest
{
    [Discriminator("Cinematic", typeof(NpcReply), typeof(NpcReplyRecord))]
    public class CinematicReply : NpcReply
    {
        public CinematicReply(NpcReplyRecord record)
            : base(record)
        {
        }

        public short CinematicId
        {
            get => Record.GetParameter<short>(0U);
            set => Record.SetParameter(0U, value);
        }

        public override bool Execute(Npc npc, Character character)
        {
            bool flag;
            if (!base.Execute(npc, character))
            {
                flag = false;
            }
            else
            {
                character.Client.Send(new CinematicMessage((ushort) CinematicId));
                flag = true;
            }

            return flag;
        }
    }
}