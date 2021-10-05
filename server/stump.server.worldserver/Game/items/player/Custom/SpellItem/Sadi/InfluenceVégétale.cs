using Stump.DofusProtocol.Enums;
using Stump.Server.WorldServer.Database.Items;
using Stump.Server.WorldServer.Game.Actors.Look;
using Stump.Server.WorldServer.Game.Actors.RolePlay.Characters;

namespace Stump.Server.WorldServer.Game.Items.Player.Custom
{
    [ItemId(ItemIdEnum.CARAPACE_EAU_MAJEUR_16326)] // ID ITEM - NOM 
    public class InfluenceVégétale : BasePlayerItem
    {
        public InfluenceVégétale(Character owner, PlayerItemRecord record)
            : base(owner, record)
        {
        }

        public override bool OnEquipItem(bool unequip)
        {
            var spellid = 9755; //ID SORT
            string name = "Influence Végétale";//NOM SORT
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