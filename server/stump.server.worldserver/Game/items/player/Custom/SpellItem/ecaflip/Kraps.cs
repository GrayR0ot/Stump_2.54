using Stump.DofusProtocol.Enums;
using Stump.Server.WorldServer.Database.Items;
using Stump.Server.WorldServer.Game.Actors.Look;
using Stump.Server.WorldServer.Game.Actors.RolePlay.Characters;

namespace Stump.Server.WorldServer.Game.Items.Player.Custom
{
    [ItemId(ItemIdEnum.RAVAGEUR_AIR_12686)] // ID ITEM - NOM 
    public class Kraps : BasePlayerItem
    {
        public Kraps(Character owner, PlayerItemRecord record)
            : base(owner, record)
        {
        }

        public override bool OnEquipItem(bool unequip)
        {
            var spellid = 9342; //ID SORT
            string name = "Kraps";//NOM SORT
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