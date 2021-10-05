using Stump.Server.BaseServer.Database;
using Stump.Server.WorldServer.Game.Actors.RolePlay.Characters;
using Stump.Server.WorldServer.Game.Actors.RolePlay.Npcs;

namespace Stump.Server.WorldServer.Database.Npcs.Replies
{
    [Discriminator("DeleteKamas", typeof(NpcReply), typeof(NpcReplyRecord))]
    public class DeleteKamas : NpcReply
    {
        public DeleteKamas(NpcReplyRecord record)
            : base(record)
        {
        }


        public ulong KamasQuantitie
        {
            get => Record.GetParameter<ulong>(0U);
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
                character.Inventory.SubKamas(KamasQuantitie);

                flag = true;
            }

            character.OpenPopup($"Tu viens de perdre {KamasQuantitie} kamas.");
            return flag;
        }
    }
}