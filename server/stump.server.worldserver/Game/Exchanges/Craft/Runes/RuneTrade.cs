using System;
using System.Collections.Generic;
using System.Linq;
using Stump.DofusProtocol.Enums;
using Stump.DofusProtocol.Types;
using Stump.Server.WorldServer.Game.Actors.RolePlay.Characters;
using Stump.Server.WorldServer.Game.Effects.Instances;
using Stump.Server.WorldServer.Game.Exchanges.Trades;
using Stump.Server.WorldServer.Game.Exchanges.Trades.Players;
using Stump.Server.WorldServer.Handlers.Inventory;

namespace Stump.Server.WorldServer.Game.Exchanges.Craft.Runes
{
    public class RuneTrade : ITrade
    {
        private bool m_decrafting;

        public RuneTrade(Character character)
        {
            Trader = new RuneTrader(character, this);
        }

        public Character Character => Trader.Character;

        public RuneTrader Trader { get; }

        public DialogTypeEnum DialogType => DialogTypeEnum.DIALOG_EXCHANGE;
        public ExchangeTypeEnum ExchangeType => ExchangeTypeEnum.RUNES_TRADE;


        public void Close()
        {
            Character.ResetDialog();
            InventoryHandler.SendExchangeLeaveMessage(Character.Client, DialogType, false);
        }

        public Trader FirstTrader => Trader;

        public Trader SecondTrader => Trader;

        public void Open()
        {
            InventoryHandler.SendExchangeStartOkRunesTradeMessage(Trader.Character.Client);
            Trader.Character.SetDialoger(Trader);

            Trader.ReadyStatusChanged += OnReadyStatusChanged;
            Trader.ItemMoved += OnItemMoved;
        }

        private void OnItemMoved(Trader trader, TradeItem item, bool modified, int difference)
        {
            if (m_decrafting)
                return;

            if (!modified && item.Stack > 0)
                InventoryHandler.SendExchangeObjectAddedMessage(Character.Client, false, item);

            else if (item.Stack <= 0)
                InventoryHandler.SendExchangeObjectRemovedMessage(Character.Client, false, item.Guid);

            else
                InventoryHandler.SendExchangeObjectModifiedMessage(Character.Client, false, item);
        }

        private void OnReadyStatusChanged(Trader trader, bool isready)
        {
            if (isready)
            {
                Decraft();

                trader.ToggleReady(false);
            }
        }

        public void Decraft()
        {
            m_decrafting = true;
            var results = new Dictionary<PlayerTradeItem, DecraftResult>();

            foreach (var item in Trader.Items.OfType<PlayerTradeItem>())
            {
                var result = new DecraftResult(item, 0);
                results.Add(item, result);
                for (var i = 0; i < item.Stack; i++)
                {
                    RuneManager.Instance.RegisterDecraft(item.Template);
                    var coeff = RuneManager.Instance.GetDecraftCoefficient(item.Template);
                    result.coeff = (int) coeff;

                    foreach (var effect in item.Effects.OfType<EffectInteger>())
                    {
                        var runes = RuneManager.Instance.GetEffectRunes(effect.EffectId);

                        var lowPowerBoost = 1;
                        if (runes.Length <= 0)
                            continue;
                        switch (effect.Id)
                        {
                            case 125:
                                lowPowerBoost = 5;
                                break;
                            case 158:
                            case 174:
                                lowPowerBoost = 10;
                                break;
                        }

                        var prop = coeff * (effect.Value * lowPowerBoost) * item.Template.Level / 20;

                        //var random = new CryptoRandom();
                        //prop *= random.NextDouble() * 3;

                        var amount = (int) Math.Ceiling(prop);
                        /*if (random.NextDouble() < prop - Math.Floor(prop))
                            amount++;*/

                        var rune = runes.OrderBy(x => x.Amount).First();

                        var runeAmount = rune.Amount == 0 ? 1 : (int) Math.Floor((double) amount / rune.Amount);

                        if (result.Runes.ContainsKey(rune.Item))
                            result.Runes[rune.Item] += runeAmount;
                        else
                            result.Runes.Add(rune.Item, runeAmount);
                    }

                    Trader.Character.OnDecraftItem(item.Template, result.Runes.Sum(x => x.Value));
                }
            }

            InventoryHandler.SendDecraftResultMessage(Character.Client,
                results.Select(x => new DecraftedItemStackInfo((uint) x.Key.Guid, x.Value.coeff, x.Value.coeff,
                    x.Value.Runes.Select(y => (ushort) y.Key.Id).ToArray(),
                    x.Value.Runes.Select(y => (uint) y.Value).ToArray())));

            foreach (var item in results.Keys)
            {
                Character.Inventory.RemoveItem(item.PlayerItem, (int) item.Stack);
                Trader.MoveItem((uint) item.Guid, 0);
            }

            foreach (var group in results.Values.SelectMany(x => x.Runes).GroupBy(x => x.Key))
            {
                var rune = group.Key;
                var amount = group.Sum(x => x.Value);

                if (amount < 0)
                    amount = 1;

                Character.Inventory.AddItem(rune, amount);
            }

            m_decrafting = false;
        }
    }
}