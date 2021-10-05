using System.Linq;
using Stump.DofusProtocol.Types;
using Stump.Server.WorldServer.Database.Characters;
using Stump.Server.WorldServer.Database.Startup;

namespace Stump.Server.WorldServer.Game.Accounts.Startup
{
    public class StartupAction
    {
        public StartupAction(StartupActionRecord record)
        {
            Record = record;
            Items = record.Items.Select(entry => new StartupActionItem(entry)).ToArray();
        }

        public StartupActionRecord Record { get; }

        public int Id
        {
            get => Record.Id;
            set => Record.Id = value;
        }

        public string Title
        {
            get => Record.Title;
            set => Record.Title = value;
        }

        public string Text
        {
            get => Record.Text;
            set => Record.Text = value;
        }

        public string DescUrl
        {
            get => Record.DescUrl;
            set => Record.DescUrl = value;
        }

        public string PictureUrl
        {
            get => Record.PictureUrl;
            set => Record.PictureUrl = value;
        }

        public StartupActionItem[] Items { get; }

        public void GiveGiftTo(CharacterRecord character)
        {
            foreach (var item in Items) item.GiveTo(character);
        }

        public StartupActionAddObject GetStartupActionAddObject()
        {
            return new StartupActionAddObject(Id, Title, Text, DescUrl, PictureUrl,
                Items.Select(entry => entry.GetObjectItemInformationWithQuantity()).ToArray());
        }
    }
}