using System.Drawing;
using Stump.DofusProtocol.Enums;
using Stump.Server.BaseServer.Database;
using Stump.Server.WorldServer.Game.Actors.RolePlay.Characters;
using Stump.Server.WorldServer.Game.Actors.RolePlay.Npcs;
using Stump.Server.WorldServer.Game.Items;

namespace Stump.Server.WorldServer.Database.Npcs.Replies
{
    [Discriminator("KamasToOgrines", typeof(NpcReply), typeof(NpcReplyRecord))]
    public class KamasToOgrines : NpcReply
    {
        public KamasToOgrines(NpcReplyRecord record)
            : base(record)
        {
        }

        public ulong AmountKamas
        {
            get => Record.GetParameter<ulong>(0U);
            set => Record.SetParameter(0U, value);
        }

        public uint AmountOgrines
        {
            get => Record.GetParameter<uint>(1U);
            set => Record.SetParameter(1U, value);
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
                if (character.Inventory.Kamas < AmountKamas)
                {
                    character.SendInformationMessage(TextInformationTypeEnum.TEXT_INFORMATION_ERROR, 82);
                    flag = false;
                }

                else
                {
                    var item = ItemManager.Instance.CreatePlayerItem(character,
                        (int) ItemIdEnum.PIECE_DE_KAMA_GEANTE_12124, (int) AmountOgrines);
                    character.Inventory.AddItem(item);
                    character.Inventory.SubKamas(AmountKamas);
                    character.SendServerMessage("Félicitations, vous avez reçu " + AmountOgrines + " Erosinos.",
                        Color.DarkOrange);
                    flag = true;
                }
            }

            return flag;
        }
    }
}