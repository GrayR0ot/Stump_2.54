using System;
using System.Globalization;
using System.Linq;
using MongoDB.Bson;
using Stump.Core.Reflection;
using Stump.DofusProtocol.Enums;
using Stump.Server.BaseServer.Logging;
using Stump.Server.WorldServer.Game.Actors.RolePlay.Characters;
using Stump.Server.WorldServer.Game.Actors.RolePlay.Npcs;
using Stump.Server.WorldServer.Game.Exchanges.Trades;
using Stump.Server.WorldServer.Game.Exchanges.Trades.Npcs;
using Stump.Server.WorldServer.Game.Exchanges.Trades.Players;
using Stump.Server.WorldServer.Game.Items;
using Stump.Server.WorldServer.Handlers.Inventory;

namespace Stump.Server.WorldServer.Game.Exchanges
{
    public class NpcTradese : Trade<PlayerTrader, NpcTrader>
    {
        public NpcTradese(Character character, Npc npc, int kamas, int itemToGive /*, int itemToReceive, int rateItem*/)
        {
            Kamas = kamas;
            ItemIdToGive = itemToGive;
            FirstTrader = new PlayerTrader(character, this);
            SecondTrader = new NpcTrader(npc, this);
        }

        public int Kamas { get; set; }

        public int ItemIdToReceive { get; set; }

        public int ItemIdToGive { get; set; }

        public int RateItem { get; set; }

        public override ExchangeTypeEnum ExchangeType => ExchangeTypeEnum.NPC_TRADE;

        public override void Open()
        {
            base.Open();
            FirstTrader.Character.SetDialoger(FirstTrader);
            InventoryHandler.SendExchangeStartOkNpcTradeMessage(FirstTrader.Character.Client, this);
        }

        public override void Close()
        {
            base.Close();
            InventoryHandler.SendExchangeLeaveMessage(FirstTrader.Character.Client, DialogTypeEnum.DIALOG_EXCHANGE,
                FirstTrader.ReadyToApply);
            FirstTrader.Character.CloseDialog(this);
        }

        protected override void Apply()
        {
            if (FirstTrader.Items.All(delegate(TradeItem x)
            {
                var basePlayerItem = FirstTrader.Character.Inventory.TryGetItem(x.Guid);
                return basePlayerItem != null && basePlayerItem.Stack >= x.Stack;
            }))
            {
                FirstTrader.Character.Inventory.SetKamas(FirstTrader.Character.Inventory.Kamas +
                                                         (SecondTrader.Kamas - FirstTrader.Kamas));
                foreach (var current in FirstTrader.Items.Where(x => x.Template.Id == ItemIdToGive))
                {
                    var item = FirstTrader.Character.Inventory.TryGetItem(current.Guid);
                    FirstTrader.Character.Inventory.RemoveItem(item, (int) current.Stack);
                }

                foreach (var current in SecondTrader.Items)
                    FirstTrader.Character.Inventory.AddItem(current.Template, (int) current.Stack);
                InventoryHandler.SendInventoryWeightMessage(FirstTrader.Character.Client);
                var document = new BsonDocument
                {
                    {
                        "NpcId",
                        SecondTrader.Npc.TemplateId
                    },

                    {
                        "PlayerId",
                        FirstTrader.Id
                    },

                    {
                        "NpcKamas",
                        (long) SecondTrader.Kamas
                    },

                    {
                        "PlayerItems",
                        FirstTrader.ItemsString
                    },

                    {
                        "NpcItems",
                        SecondTrader.ItemsString
                    },

                    {
                        "Date",
                        DateTime.Now.ToString(CultureInfo.InvariantCulture)
                    }
                };
                Singleton<MongoLogger>.Instance.Insert("NpcTrade", document);
            }
        }

        protected override void OnTraderReadyStatusChanged(Trader trader, bool status)
        {
            base.OnTraderReadyStatusChanged(trader, status);
            InventoryHandler.SendExchangeIsReadyMessage(FirstTrader.Character.Client, trader, status);
            if (trader is PlayerTrader && status) SecondTrader.ToggleReady(true);
        }

        protected override void OnTraderItemMoved(Trader trader, TradeItem item, bool modified, int difference)
        {
            if (item.Template.Id != ItemIdToGive)
                return;

            base.OnTraderItemMoved(trader, item, modified, difference);
            if (item.Stack == 0u)
            {
                if (trader is PlayerTrader && ItemIdToReceive != 0 && RateItem != 0 && item.Template.Id == ItemIdToGive)
                    foreach (var @object in SecondTrader.Items)
                        SecondTrader.RemoveItem(@object.Template, @object.Stack);
                if (trader is PlayerTrader) SecondTrader.SetKamas(0);
                InventoryHandler.SendExchangeObjectRemovedMessage(FirstTrader.Character.Client, trader != FirstTrader,
                    item.Guid);
            }
            else
            {
                if (modified)
                    InventoryHandler.SendExchangeObjectModifiedMessage(FirstTrader.Character.Client,
                        trader != FirstTrader, item);
                else
                    InventoryHandler.SendExchangeObjectAddedMessage(FirstTrader.Character.Client, trader != FirstTrader,
                        item);

                if (trader is PlayerTrader && ItemIdToReceive != 0 && RateItem != 0 && item.Template.Id == ItemIdToGive)
                {
                    foreach (var @object in SecondTrader.Items)
                        SecondTrader.RemoveItem(@object.Template, @object.Stack);
                    SecondTrader.AddItem(ItemManager.Instance.TryGetTemplate(ItemIdToReceive),
                        (uint) (item.Stack / RateItem));
                }

                if (trader is PlayerTrader)
                {
                    var items = FirstTrader.Items.FirstOrDefault(x => x.Template.Id == ItemIdToGive);
                    if (items != null)
                        SecondTrader.SetKamas((int) (Kamas * items.Stack));
                    else
                        SecondTrader.SetKamas(0);
                }
            }
        }

        protected override void OnTraderKamasChanged(Trader trader, ulong amount)
        {
            base.OnTraderKamasChanged(trader, amount);
            InventoryHandler.SendExchangeKamaModifiedMessage(FirstTrader.Character.Client, trader != FirstTrader,
                amount);
        }
    }
}