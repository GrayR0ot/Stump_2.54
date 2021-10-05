using Stump.DofusProtocol.Enums;
using Stump.Server.WorldServer.Database.Items;
using Stump.Server.WorldServer.Game.Actors.Look;
using Stump.Server.WorldServer.Game.Actors.RolePlay.Characters;

namespace Stump.Server.WorldServer.Game.Items.Player.Custom
{
    [ItemId(ItemIdEnum.CUIRASSE_AIR_MINEUR_12649)] // ID ITEM - NOM 
    public class Carnage : BasePlayerItem
    {
        public Carnage(Character owner, PlayerItemRecord record)
            : base(owner, record)
        {
        }

        public override bool OnEquipItem(bool unequip)
        {
            var spellid = 9995; //ID SORT
            string name = "Carnage";//NOM SORT
            if (IsEquiped() && !Owner.Spells.HasSpell(spellid))
            {
                Owner.Spells.LearnSpell(spellid);
                Owner.SendServerMessage("Vous venez d'apprendre le sort "+name+".");

                Owner.RefreshActor();
            }
            else
            {

                if (Owner.Spells.HasSpell(spellid))
                {
                    Owner.SendServerMessage("Vous venez de désapprendre le sort " + name + ".");
                    Owner.Spells.UnLearnSpell(spellid);
                    Owner.RefreshActor();
                }

            }
            return base.OnEquipItem(unequip);


        }
    }
}