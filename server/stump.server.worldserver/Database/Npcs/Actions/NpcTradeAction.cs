using Stump.DofusProtocol.Enums;
using Stump.Server.BaseServer.Database;
using Stump.Server.WorldServer.Game.Actors.RolePlay.Characters;
using Stump.Server.WorldServer.Game.Actors.RolePlay.Npcs;
using Stump.Server.WorldServer.Game.Exchanges;

namespace Stump.Server.WorldServer.Database.Npcs.Actions
{
    [Discriminator(Discriminator, typeof(NpcActionDatabase), typeof(NpcActionRecord))]
    public class NpcTradeAction : NpcActionDatabase
    {
        public const string Discriminator = "Trade";

        public NpcTradeAction(NpcActionRecord record)
            : base(record)
        {
        }

        public override NpcActionTypeEnum[] ActionType => new[] {NpcActionTypeEnum.ACTION_EXCHANGE};

        public int Kamas
        {
            get => Record.GetParameter<int>(0u);
            set => Record.SetParameter(0u, value);
        }

        public int ItemIdToGive
        {
            get => Record.GetParameter<int>(1u);
            set => Record.SetParameter(1u, value);
        }

        public override void Execute(Npc npc, Character character)
        {
            var npcDialog = new NpcTradese(character, npc, Kamas, ItemIdToGive);
            npcDialog.Open();

            if (ItemIdToGive == 30000)
                character.OpenPopup(
                    "En echangeant vos Poignées de kamas contre des kamas, faites attention à ne pas être déjà à la limite de 10mm, si c'est le cas rendez vous en banque pour y déposer des kamas ( peut comporter 10mm elle aussi ! )");
        }
    }
}