using Stump.Server.BaseServer.Database;
using Stump.Server.WorldServer.Game.Actors.RolePlay.Characters;
using Stump.Server.WorldServer.Game.Actors.RolePlay.Npcs;
using Stump.Server.WorldServer.Game.Dialogs.Npcs;

namespace Stump.Server.WorldServer.Database.Npcs.Replies
{
    [Discriminator("Dialog", typeof(NpcReply), typeof(NpcReplyRecord))]
    public class ContinueDialogReply : NpcReply
    {
        private NpcMessage m_message;

        public ContinueDialogReply(NpcReplyRecord record)
            : base(record)
        {
        }

        /// <summary>
        ///     Parameter 0
        /// </summary>
        public int NextMessageId
        {
            get => Record.GetParameter<int>(0);
            set => Record.SetParameter(0, value);
        }

        public NpcMessage NextMessage
        {
            get => m_message ?? (m_message = NpcManager.Instance.GetNpcMessage(NextMessageId));
            set
            {
                m_message = value;
                NextMessageId = value.Id;
            }
        }

        public override bool CanExecute(Npc npc, Character character)
        {
            return base.CanExecute(npc, character) && character.IsTalkingWithNpc();
        }

        public override bool Execute(Npc npc, Character character)
        {
            if (!base.Execute(npc, character))
                return false;

            ((NpcDialog) character.Dialog).ChangeMessage(NextMessage);

            return true;
        }
    }
}