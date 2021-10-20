using System;
using Stump.DofusProtocol.Enums;
using Stump.Server.WorldServer.Core.Network;
using Stump.Server.WorldServer.Game.Exchanges.Trades;
using Stump.Server.WorldServer.Game.Interactives;
using Stump.Server.WorldServer.Game.Interactives.Skills;
using Stump.Server.WorldServer.Game.Items.Player;
using Stump.Server.WorldServer.Game.Jobs;
using Stump.Server.WorldServer.Handlers.Inventory;

namespace Stump.Server.WorldServer.Game.Exchanges.Craft
{
    public abstract class BaseCraftDialog : ITrade
    {
        protected BaseCraftDialog(InteractiveObject interactive, Skill skill, Job job)
        {
            Interactive = interactive;
            Skill = skill;
            Job = job;
        }

        public InteractiveObject Interactive { get; }

        public Skill Skill { get; }

        public Job Job { get; }

        public Crafter Crafter { get; protected set; }

        public CraftingActor Receiver { get; protected set; }

        public WorldClientCollection Clients { get; protected set; }

        public int Amount { get; protected set; }

        public DialogTypeEnum DialogType => DialogTypeEnum.DIALOG_EXCHANGE;
        public ExchangeTypeEnum ExchangeType => ExchangeTypeEnum.CRAFT;
        public abstract void Close();

        public abstract Trader FirstTrader { get; }

        public abstract Trader SecondTrader { get; }

        public bool ChangeAmount(int amount)
        {

            if (amount < 0 && amount != -1 || amount > 100 && Job.Id != 1)
                return false;

            Amount = amount;
            InventoryHandler.SendExchangeCraftCountModifiedMessage(Clients, amount);
            return true;
        }

        public virtual bool CanMoveItem(BasePlayerItem item)
        {
            return true;
        }
    }
}