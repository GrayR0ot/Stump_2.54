using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stump.Server.WorldServer.Game.Items.Player.Custom
{
    public class DungeonKey
    {

        int dungeon;
        int key;

        public DungeonKey(int dungeon, int key)
        {
            this.dungeon = dungeon;
            this.key = key;
        }

        public int getDungeon()
        {
            return this.dungeon;
        }

        public int getKey()
        {
            return this.key;
        }

        public static List<DungeonKey> generateKeyset()
        {
            List<DungeonKey> keyset = new List<DungeonKey>();
            keyset.Add(new DungeonKey(152829952, 8545)); //kardo
            keyset.Add(new DungeonKey(121373185, 1568)); //bouftou
            keyset.Add(new DungeonKey(190449664, 8143)); //champs
            keyset.Add(new DungeonKey(193725440, 8437)); //emsablé
            keyset.Add(new DungeonKey(146675712, 15991)); //kankreblath
            keyset.Add(new DungeonKey(163578368, 11799)); //maison hanté
            keyset.Add(new DungeonKey(87033344, 1570)); //squelette
            keyset.Add(new DungeonKey(94110720, 8139)); //scara
            keyset.Add(new DungeonKey(96338946, 7918)); //batofu
            keyset.Add(new DungeonKey(181665792, 19041)); //magik riktus
            keyset.Add(new DungeonKey(155713536, 8156)); //meulou
            keyset.Add(new DungeonKey(187432960, 19515)); //bethel
            keyset.Add(new DungeonKey(55050240, 11174)); //royalmouth
            keyset.Add(new DungeonKey(17564931, 7310)); //bulbe
            keyset.Add(new DungeonKey(184690945, 19216)); //ilyzaelle
            keyset.Add(new DungeonKey(87295489, 1569)); //forgeron
            keyset.Add(new DungeonKey(104595969, 8135)); //bwork
            keyset.Add(new DungeonKey(64749568, 12017)); //kwakwa
            keyset.Add(new DungeonKey(106954752, 7927)); //craqueleur
            keyset.Add(new DungeonKey(56098816, 11175)); //mansot
            keyset.Add(new DungeonKey(40108544, 8438)); //rat brak
            keyset.Add(new DungeonKey(56360960, 11176)); //ben
            keyset.Add(new DungeonKey(169345024, 18068)); //koutoulou
            keyset.Add(new DungeonKey(22282240, 8971)); //arche oto
            keyset.Add(new DungeonKey(176947200, 12073)); //nelwenn
            keyset.Add(new DungeonKey(157286400, 17112)); //moon
            keyset.Add(new DungeonKey(159125512, 7926)); //corbac
            keyset.Add(new DungeonKey(176160768, 18544)); //talkasha
            keyset.Add(new DungeonKey(109576705, 14046)); //nileza
            keyset.Add(new DungeonKey(110362624, 14045)); //klime
            keyset.Add(new DungeonKey(98566657, 996)); //gelées
            keyset.Add(new DungeonKey(166986752, 9248)); //blop
            keyset.Add(new DungeonKey(72351744, 8320)); //dc
            keyset.Add(new DungeonKey(118226944, 14560)); //dramak
            keyset.Add(new DungeonKey(149684224, 7557)); //Aancestral
            keyset.Add(new DungeonKey(149423104, 8436)); //chene mou
            keyset.Add(new DungeonKey(79430145, 12735)); //daigoro
            keyset.Add(new DungeonKey(22808576, 8972)); //rasboul
            keyset.Add(new DungeonKey(27787264, 8343)); //croca
            keyset.Add(new DungeonKey(125831681, 15093)); //kanigroula
            keyset.Add(new DungeonKey(96338948, 8142)); //tofu royal
            keyset.Add(new DungeonKey(89391104, 8975)); //tynril
            keyset.Add(new DungeonKey(57148161, 11177)); //obsi
            keyset.Add(new DungeonKey(157548544, 11798)); //kaniboul
            keyset.Add(new DungeonKey(116392448, 14464)); //wa wabit
            keyset.Add(new DungeonKey(34473474, 7924)); //minotoror
            keyset.Add(new DungeonKey(34472450, 8307)); //minotot
            keyset.Add(new DungeonKey(96994817, 7423)); //larves
            keyset.Add(new DungeonKey(174064128, 18422)); //elpiko
            keyset.Add(new DungeonKey(132907008, 15162)); //truche
            keyset.Add(new DungeonKey(149160960, 16179)); //reine nyée
            keyset.Add(new DungeonKey(157024256, 17113)); //chouque
            keyset.Add(new DungeonKey(174326272, 18421)); //mastdonte
            keyset.Add(new DungeonKey(21495808, 8977)); //kimbo
            keyset.Add(new DungeonKey(116654593, 14465)); //wa wobot
            keyset.Add(new DungeonKey(27000832, 8439)); //rat bonta
            keyset.Add(new DungeonKey(5243139, 8917)); //hesk
            keyset.Add(new DungeonKey(26738688, 31232)); //kralamour geant
            keyset.Add(new DungeonKey(130286592, 15278)); //mallefisk
            keyset.Add(new DungeonKey(143138823, 15806)); //fraktal
            keyset.Add(new DungeonKey(161743872, 17563)); //pounicheur
            keyset.Add(new DungeonKey(107216896, 7908)); //koulosse
            keyset.Add(new DungeonKey(137102336, 15475)); //rdv
            keyset.Add(new DungeonKey(136578048, 15477)); //ekarlate
            keyset.Add(new DungeonKey(136840192, 15476)); //toxo
            keyset.Add(new DungeonKey(130548736, 15279)); //phossile
            keyset.Add(new DungeonKey(129500160, 15280)); //nidas
            keyset.Add(new DungeonKey(143917569, 15807)); //xlii
            keyset.Add(new DungeonKey(143393281, 15808)); //vortex
            keyset.Add(new DungeonKey(162004992, 17564)); //ush
            keyset.Add(new DungeonKey(160564224, 17565)); //chaloeil
            keyset.Add(new DungeonKey(140771328, 15690)); //baleine
            keyset.Add(new DungeonKey(119277057, 14870)); //merkator
            keyset.Add(new DungeonKey(110100480, 14044)); //sylargh
            //keyset.Add(new DungeonKey(173934082, ),285); croco
            keyset.Add(new DungeonKey(187957506, 19514)); //solar
            keyset.Add(new DungeonKey(182714368, 19049)); //4patte
            keyset.Add(new DungeonKey(107481088, 8073)); //skeunk
            keyset.Add(new DungeonKey(195035136, 19963)); //dazak
            keyset.Add(new DungeonKey(112201217, 14047)); //conte harebourg
            keyset.Add(new DungeonKey(169869312, 18066)); //meno
            keyset.Add(new DungeonKey(18088960, 7311)); //kitsoun
            keyset.Add(new DungeonKey(17302528, 7309)); //pandikaze
            keyset.Add(new DungeonKey(59511808, 11178)); //givrefoux
            keyset.Add(new DungeonKey(16516867, 7312)); //firefoux
            keyset.Add(new DungeonKey(62915584, 11179)); //korri
            keyset.Add(new DungeonKey(61865984, 11180)); //kolosso
            keyset.Add(new DungeonKey(62130696, 11181)); //glours
            keyset.Add(new DungeonKey(109838849, 14043)); //frizz
            keyset.Add(new DungeonKey(57934593, 8329)); //grolum
            keyset.Add(new DungeonKey(102760961, 12351)); //sphincter
            keyset.Add(new DungeonKey(179568640, 18736)); //razoff
            keyset.Add(new DungeonKey(104333825, 6884)); //bworker
            keyset.Add(new DungeonKey(182327297, 9247)); //ougah
            keyset.Add(new DungeonKey(101188608, 13333)); // halloween
            keyset.Add(new DungeonKey(169607168, 18067)); //dentinea
            keyset.Add(new DungeonKey(123207680, 14935)); // ombre
            keyset.Add(new DungeonKey(176030208, 18552)); // pervert
            keyset.Add(new DungeonKey(74973185, 31019)); // grozilla
            
            return keyset;
        }
    }
}