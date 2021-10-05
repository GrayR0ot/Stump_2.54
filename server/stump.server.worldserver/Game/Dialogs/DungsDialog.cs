using Stump.DofusProtocol.Enums;
using Stump.DofusProtocol.Messages;
using Stump.DofusProtocol.Types;
using Stump.Server.BaseServer.Network;
using Stump.Server.WorldServer.Database.World;
using Stump.Server.WorldServer.Game.Actors.RolePlay.Characters;
using Stump.Server.WorldServer.Game.Items;
using Stump.Server.WorldServer.Game.Items.Player.Custom;
using Stump.Server.WorldServer.Game.Maps;
using Stump.Server.WorldServer.Handlers.Dialogs;
using System.Collections.Generic;
using System.Linq;

namespace Stump.Server.WorldServer.Game.Dialogs.Interactives
{
    public class DungsDialog : IDialog
    {
        readonly Dictionary<Map, int> m_destinations = new Dictionary<Map, int>();

        public DungsDialog(Character character, Dictionary<Map, int> destinations, bool isDungeon = false)
        {
            Character = character;
            IsDungeon = isDungeon;
            m_destinations = destinations;
        }

        public DialogTypeEnum DialogType => DialogTypeEnum.DIALOG_TELEPORTER;

        public Character Character
        {
            get;
        }

        private bool IsDungeon
        {
            get;
            set;
        }

        public void AddDestination(Map map, int cellId)
        {
            m_destinations.Add(map, cellId);
        }

        public void Open()
        {
            Character.SetDialog(this);
            SendZaapListMessage(Character.Client);
        }

        public void Close()
        {
            Character.CloseDialog(this);
            DialogHandler.SendLeaveDialogMessage(Character.Client, DialogType);
        }

        public void Teleport(Map map)
        {
            if (!m_destinations.ContainsKey(map))
                return;

            Cell cell;

            cell = map.GetCell(m_destinations.Where(x => x.Key == map).FirstOrDefault().Value);

            if (!map.IsCellWalkable(cell))
                cell = map.GetFirstFreeCellNearMiddle();

            Character.Teleport(map, cell);

            if (IsDungeon)
            {
                Dictionary<DungeonKey, int> destinations = new Dictionary<DungeonKey, int>();

                destinations.Add(new DungeonKey(152829952, 8545), 437); //kardo
                destinations.Add(new DungeonKey(121373185, 1568), 464);  //bouftou
                destinations.Add(new DungeonKey(190449664, 8143), 437);  //champs
                destinations.Add(new DungeonKey(193725440, 8437), 520);  //emsablé
                destinations.Add(new DungeonKey(146675712, 15991), 491);  //kankreblath
                destinations.Add(new DungeonKey(163578368, 11799), 456);  //maison hanté
                destinations.Add(new DungeonKey(87033344, 1570), 417);  //squelette
                destinations.Add(new DungeonKey(94110720, 8139), 443);  //scara
                destinations.Add(new DungeonKey(96338946, 7918), 480);  //batofu
                destinations.Add(new DungeonKey(181665792, 19041), 552);  //magik riktus
                destinations.Add(new DungeonKey(155713536, 8156), 505);  //meulou
                destinations.Add(new DungeonKey(187432960, 19515), 258); //bethel
                destinations.Add(new DungeonKey(55050240, 11174), 284);  //royalmouth
                destinations.Add(new DungeonKey(17564931, 7310), 536);  //bulbe
                destinations.Add(new DungeonKey(184690945, 19216), 534);  //ilyzaelle
                destinations.Add(new DungeonKey(87295489, 1569), 422); //forgeron
                destinations.Add(new DungeonKey(104595969, 8135), 472); //bwork
                destinations.Add(new DungeonKey(64749568, 12017), 478); //kwakwa
                destinations.Add(new DungeonKey(106954752, 7927), 464); //craqueleur
                destinations.Add(new DungeonKey(56098816, 11175), 490); //mansot
                destinations.Add(new DungeonKey(40108544, 8438), 476); //rat brak
                destinations.Add(new DungeonKey(56360960, 11176), 228); //ben
                destinations.Add(new DungeonKey(169345024, 18068), 464); //koutoulou
                destinations.Add(new DungeonKey(22282240, 8971), 376); //arche oto
                destinations.Add(new DungeonKey(176947200, 12073), 326); //nelwenn
                destinations.Add(new DungeonKey(157286400, 17112), 375); //moon
                destinations.Add(new DungeonKey(159125512, 7926), 311); //corbac
                destinations.Add(new DungeonKey(176160768, 18544), 449); //talkasha
                destinations.Add(new DungeonKey(109576705, 14046), 256); //nileza
                destinations.Add(new DungeonKey(110362624, 14045), 221); //klime
                destinations.Add(new DungeonKey(98566657, 996), 509); //gelées
                destinations.Add(new DungeonKey(166986752, 9248), 533); //blop
                destinations.Add(new DungeonKey(72351744, 8320), 465); //dc
                destinations.Add(new DungeonKey(118226944, 14560), 508); //dramak
                destinations.Add(new DungeonKey(149684224, 7557), 421); //Aancestral
                destinations.Add(new DungeonKey(149423104, 8436), 422); //chene mou
                destinations.Add(new DungeonKey(79430145, 12735), 254); //daigoro
                destinations.Add(new DungeonKey(22808576, 8972), 456); //rasboul
                destinations.Add(new DungeonKey(27787264, 8343), 379); //croca
                destinations.Add(new DungeonKey(125831681, 15093), 464); //kanigroula
                destinations.Add(new DungeonKey(96338948, 8142), 312); //tofu royal
                destinations.Add(new DungeonKey(89391104, 8975), 246); //tynril
                destinations.Add(new DungeonKey(57148161, 11177), 25); //obsi
                destinations.Add(new DungeonKey(157548544, 11798), 522); //kaniboul
                destinations.Add(new DungeonKey(116392448, 14464), 464); //wa wabit
                destinations.Add(new DungeonKey(34473474, 7924), 464); //minotoror
                destinations.Add(new DungeonKey(34472450, 8307), 408); //minotot
                destinations.Add(new DungeonKey(96994817, 7423), 423); //larves
                destinations.Add(new DungeonKey(174064128, 18422), 521); //elpiko
                destinations.Add(new DungeonKey(132907008, 15162), 533); //truche
                destinations.Add(new DungeonKey(149160960, 16179), 424); //reine nyée
                destinations.Add(new DungeonKey(157024256, 17113), 359); //chouque
                destinations.Add(new DungeonKey(174326272, 18421), 491); //mastdonte
                destinations.Add(new DungeonKey(21495808, 8977), 210); //kimbo
                destinations.Add(new DungeonKey(116654593, 14465), 491); //wa wobot
                destinations.Add(new DungeonKey(27000832, 8439), 535); //rat bonta
                destinations.Add(new DungeonKey(5243139, 8917), 336); //hesk
                destinations.Add(new DungeonKey(26738688, 31232), 505); //kralamour geant
                destinations.Add(new DungeonKey(130286592, 15278), 516); //mallefisk
                destinations.Add(new DungeonKey(143138823, 15806), 515); //fraktal
                destinations.Add(new DungeonKey(161743872, 17563), 504); //pounicheur
                destinations.Add(new DungeonKey(107216896, 7908), 554); //koulosse
                destinations.Add(new DungeonKey(137102336, 15475), 420); //rdv
                destinations.Add(new DungeonKey(136578048, 15477), 256); //ekarlate
                destinations.Add(new DungeonKey(136840192, 15476), 504); //toxo
                destinations.Add(new DungeonKey(130548736, 15279), 266); //phossile
                destinations.Add(new DungeonKey(129500160, 15280), 337); //nidas
                destinations.Add(new DungeonKey(143917569, 15807), 226); //xlii
                destinations.Add(new DungeonKey(143393281, 15808), 479); //vortex
                destinations.Add(new DungeonKey(162004992, 17564), 506); //ush
                destinations.Add(new DungeonKey(160564224, 17565), 206); //chaloeil
                destinations.Add(new DungeonKey(140771328, 15690), 459); //baleine
                destinations.Add(new DungeonKey(119277057, 14870), 240); //merkator
                destinations.Add(new DungeonKey(110100480, 14044), 465); //sylargh
                                                                         //destinations.Add(new DungeonKey(173934082, ),285); croco
                destinations.Add(new DungeonKey(187957506, 19514), 473); //solar
                destinations.Add(new DungeonKey(182714368, 19049), 362); //4patte
                destinations.Add(new DungeonKey(107481088, 8073), 553); //skeunk
                destinations.Add(new DungeonKey(195035136, 19963), 553); //dazak
                destinations.Add(new DungeonKey(112201217, 14047), 329); //conte harebourg
                destinations.Add(new DungeonKey(169869312, 18066), 329); //meno
                destinations.Add(new DungeonKey(18088960, 7311), 329); //kitsoun
                destinations.Add(new DungeonKey(17302528, 7309), 544); //pandikaze
                destinations.Add(new DungeonKey(59511808, 11178), 344); //givrefoux
                destinations.Add(new DungeonKey(16516867, 7312), 300); //firefoux
                destinations.Add(new DungeonKey(62915584, 11179), 328); //korri
                destinations.Add(new DungeonKey(61865984, 11180), 491); //kolosso
                destinations.Add(new DungeonKey(62130696, 11181), 300); //glours
                destinations.Add(new DungeonKey(109838849, 14043), 300);//frizz
                destinations.Add(new DungeonKey(57934593, 8329), 300); //grolum
                destinations.Add(new DungeonKey(102760961, 12351), 300); //sphincter
                destinations.Add(new DungeonKey(179568640, 18736), 300); //razoff
                destinations.Add(new DungeonKey(104333825, 6884), 300); //bworker
                destinations.Add(new DungeonKey(182327297, 9247), 300); //ougah
                destinations.Add(new DungeonKey(101188608, 13333), 300); // halloween
                destinations.Add(new DungeonKey(169607168, 18067), 300); //dentinea
                destinations.Add(new DungeonKey(123207680, 14935), 300);// ombre
                destinations.Add(new DungeonKey(176030208, 18552), 300); // pervert
                destinations.Add(new DungeonKey(74973185, 31019), 300); // grozilla
                destinations.Add(new DungeonKey(175113216, 31254), 465); // repere asylium
                foreach (var item in destinations)
                {
                    if (map.Id == item.Key.getDungeon())
                    {
                        if (Character.Inventory.HasItem(ItemManager.Instance.TryGetTemplate(item.Key.getKey())))
                        {
                            var key = Character.Inventory.TryGetItem(ItemManager.Instance.TryGetTemplate(item.Key.getKey()));
                            if (key.Stack > 1)
                            {
                                key.Stack--;
                                Character.Inventory.RefreshItem(key);
                            }
                            else
                            {
                                Character.Inventory.RemoveItem(key);
                            }
                        }
                    }
                }
            }
            Close();
        }

        public void SendZaapListMessage(IPacketReceiver client)
        {
            client.Send(
                new TeleportDestinationsMessage
                (
                (sbyte)TeleporterTypeEnum.TELEPORTER_ZAAP,
                m_destinations.Select(entry => new TeleportDestination((sbyte)TeleporterTypeEnum.TELEPORTER_ZAAP, entry.Key.Id, (ushort)entry.Key.SubArea.Id, (ushort)entry.Key.SubArea.Record.Level, (ushort)entry.Key.SubArea.Record.Level)).ToArray()
                ));
        }

        public short GetCostTo(Map map)
        {
            return 0;
        }
    }
}
