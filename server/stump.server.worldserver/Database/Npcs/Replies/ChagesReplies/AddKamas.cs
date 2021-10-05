using System.Drawing;
using Stump.Server.BaseServer.Database;
using Stump.Server.WorldServer.Game.Actors.RolePlay.Characters;
using Stump.Server.WorldServer.Game.Actors.RolePlay.Npcs;

namespace Stump.Server.WorldServer.Database.Npcs.Replies
{
    [Discriminator("AddKamas", typeof(NpcReply), typeof(NpcReplyRecord))]
    public class AddKamas : NpcReply
    {
        public AddKamas(NpcReplyRecord record)
            : base(record)
        {
        }

        public int Amount
        {
            get => Record.GetParameter<int>(0U);
            set => Record.SetParameter(0U, value);
        }

        public ulong MinAmount
        {
            get => Record.GetParameter<ulong>(1U);
            set => Record.SetParameter(1U, value);
        }


        public override bool Execute(Npc npc, Character character)
        {
            bool flag;
            if (!base.Execute(npc, character))
            {
                flag = false;
            }
            else if (character.Inventory.Kamas > MinAmount || character.Bank.Kamas > MinAmount)
            {
                character.SendServerMessage("Vous avez déjà assez de kamas !", Color.DarkOrange);
                flag = false;
            }
            else
            {
                character.Inventory.AddKamas((ulong) Amount);
                character.SendServerMessage("Vous avez reçu " + Amount + " kamas.", Color.DarkOrange);
                flag = true;
            }

            return flag;
        }
    }
}