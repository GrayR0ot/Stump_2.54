using Stump.DofusProtocol.Enums;
using Stump.DofusProtocol.Messages;
using Stump.Server.WorldServer.Commands.Trigger;
using Stump.Server.WorldServer.Database.Items;
using Stump.Server.WorldServer.Database.World;
using Stump.Server.WorldServer.Game.Accounts;
using Stump.Server.WorldServer.Game.Actors.RolePlay.Characters;
using Stump.Server.WorldServer.Game.Dialogs.Interactives;
using Stump.Server.WorldServer.Game.Effects.Instances;
using Stump.Server.WorldServer.Game.Maps;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Stump.Server.WorldServer.Game.Items.Player.Custom
{
    [ItemId(ItemIdEnum.POTION_PANEL_TP)]
    public class PotionPanelTp : BasePlayerItem
    {
        public PotionPanelTp(Character owner, PlayerItemRecord record)
            : base(owner, record)
        {
        }

        public override uint UseItem(int amount = 0, Cell targetCell = null, Character target = null)
        {

            Dictionary<Map, int> destinations = new Dictionary<Map, int>();
            destinations.Add(World.Instance.GetMap(191105026), 273);  // ZAAP ASTRUB
            destinations.Add(World.Instance.GetMap(186384904), 460); // zone bethel
            destinations.Add(World.Instance.GetMap(179307526), 399);//nimotopia
            destinations.Add(World.Instance.GetMap(153090), 455);//koko
            destinations.Add(World.Instance.GetMap(159744), 184);//zone krala
            destinations.Add(World.Instance.GetMap(173670914), 189);//saharach2
            destinations.Add(World.Instance.GetMap(174854144), 316);//saharach3
            destinations.Add(World.Instance.GetMap(186646528), 316);//merkantil
            destinations.Add(World.Instance.GetMap(63177216), 173);//morkitu
            destinations.Add(World.Instance.GetMap(38933763), 144);//dragoeuf
            destinations.Add(World.Instance.GetMap(195297286), 403);//zone shop
            destinations.Add(World.Instance.GetMap(64489222), 369);//zone koalka
            destinations.Add(World.Instance.GetMap(117706760), 329);//salle merka
            destinations.Add(World.Instance.GetMap(117704211), 369);//salle merka 2
            destinations.Add(World.Instance.GetMap(54165815), 300);//lac gelé
            destinations.Add(World.Instance.GetMap(33554950), 238);//sanctuaire
            destinations.Add(World.Instance.GetMap(196345858), 286);//ile kao






            DungsDialog s = new DungsDialog(Owner, destinations);
            s.Open();

            return 0;
        }
    }
}
