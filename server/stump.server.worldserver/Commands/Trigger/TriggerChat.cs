using System.Drawing;
using Stump.Core.Attributes;
using Stump.Core.IO;
using Stump.Server.BaseServer.Commands;
using Stump.Server.BaseServer.Network;
using Stump.Server.WorldServer.Game.Actors.RolePlay.Characters;
using Stump.Server.WorldServer.Handlers.Chat;
using XColor = System.Drawing.Color;

namespace Stump.Server.WorldServer.Commands.Trigger
{
    public class TriggerChat : GameTrigger
    {
        private static string m_htmlErrorColor = ColorTranslator.ToHtml(XColor.Red);
        private static Color m_errorColor = XColor.Red;

        public TriggerChat(StringStream args, Character character)
            : base(args, character)
        {
        }

        public TriggerChat(string args, Character character)
            : base(args, character)
        {
        }

        [Variable(true)]
        public static string HtmlErrorColor
        {
            get => m_htmlErrorColor;
            set
            {
                m_htmlErrorColor = value;
                m_errorColor = ColorTranslator.FromHtml(value);
            }
        }

        public static Color ErrorColor
        {
            get => m_errorColor;
            set
            {
                m_htmlErrorColor = ColorTranslator.ToHtml(value);
                m_errorColor = value;
            }
        }

        public override ICommandsUser User => Character;

        public override void Reply(string text)
        {
            ChatHandler.SendChatServerMessage(Character.Client, text);
        }

        public override void ReplyError(string message)
        {
            Reply(Color(message, ErrorColor));
        }

        public override BaseClient GetSource()
        {
            return Character != null ? Character.Client : null;
        }
    }
}