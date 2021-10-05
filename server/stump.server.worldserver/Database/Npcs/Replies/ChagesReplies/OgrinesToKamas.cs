using System.Drawing;
using Stump.DofusProtocol.Enums;
using Stump.Server.BaseServer.Database;
using Stump.Server.WorldServer.Game.Actors.RolePlay.Characters;
using Stump.Server.WorldServer.Game.Actors.RolePlay.Npcs;

namespace Stump.Server.WorldServer.Database.Npcs.Replies
{
    [Discriminator("OgrinesToKamas", typeof(NpcReply), typeof(NpcReplyRecord))]
    public class OgrinesToKamas : NpcReply
    {
        public OgrinesToKamas(NpcReplyRecord record)
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
                var ogri = character.Inventory.TryGetItem(ItemIdEnum.PIECE_DE_KAMA_GEANTE_12124);

                if (ogri == null)
                {
                    character.SendInformationMessage(TextInformationTypeEnum.TEXT_INFORMATION_ERROR, 4);
                    flag = false;
                }

                else if (ogri.Stack < AmountOgrines)
                {
                    character.SendInformationMessage(TextInformationTypeEnum.TEXT_INFORMATION_ERROR, 252);
                    flag = false;
                }
                else
                {
                    character.Inventory.RemoveItem(ogri, (int) AmountOgrines, false);
                    character.Inventory.AddKamas(AmountKamas);
                    character.SendServerMessage("Félicitations, vous avez reçu " + AmountKamas + " kamas.",
                        Color.DarkOrange);
                    flag = true;
                }
            }

            return flag;
        }
    }
}