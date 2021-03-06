using System.Drawing;
using Stump.DofusProtocol.Enums;
using Stump.Server.BaseServer.Database;
using Stump.Server.WorldServer.Game.Actors.RolePlay.Characters;
using Stump.Server.WorldServer.Game.Actors.RolePlay.Npcs;
using Stump.Server.WorldServer.Game.Dialogs.Npcs;

namespace Stump.Server.WorldServer.Database.Npcs.Actions
{
    [Discriminator("Talk", typeof(NpcActionDatabase), typeof(NpcActionRecord))]
    public class NpcTalkAction : NpcActionDatabase
    {
        private NpcMessage m_message;

        public NpcTalkAction(NpcActionRecord record)
            : base(record)
        {
        }

        public override NpcActionTypeEnum[] ActionType
        {
            get { return new[] {NpcActionTypeEnum.ACTION_TALK}; }
        }

        /// <summary>
        ///     Parameter 0
        /// </summary>
        public int MessageId
        {
            get => Record.GetParameter<int>(0);
            set => Record.SetParameter(0, value);
        }

        public NpcMessage Message
        {
            get => m_message ?? (m_message = NpcManager.Instance.GetNpcMessage(MessageId));
            set
            {
                m_message = value;
                MessageId = value.Id;
            }
        }

        public override void Execute(Npc npc, Character character)
        {
            var dialog = new NpcDialog(character, npc);
            if (npc.TemplateId == 3318)
            {
                if (!character.Achievement.AchievementIsCompleted(5003) &&
                    !character.Achievement.AchievementIsCompleted(5004))
                {
                    character.SendServerMessage(
                        "Vous devez terminer tous les succès précédents pour continuer la quête Dofus Turquoise",
                        Color.Red);
                    dialog.Close();
                }
                else
                {
                    dialog.Open();
                }

                dialog.ChangeMessage(Message);
            }
            else
            {
                dialog.Open();
            }

            dialog.ChangeMessage(Message);
        }
    }
}