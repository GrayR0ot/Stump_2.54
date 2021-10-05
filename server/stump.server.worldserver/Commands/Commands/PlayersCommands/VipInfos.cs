using System.Drawing;
using Stump.DofusProtocol.Enums;
using Stump.Server.WorldServer.Commands.Commands.Patterns;
using Stump.Server.WorldServer.Commands.Trigger;

namespace Commands.Commands
{
    public class VipInfos : InGameSubCommand
    {
        public VipInfos()
        {
            Aliases = new[]
            {
                "infos"
            };
            RequiredRole = RoleEnum.Player;
            ParentCommandType = typeof(VipCommand);
            Description = "Cette commande vous permet de savoir ce que contient le pack V.I.P.";
        }

        public override void Execute(GameTrigger trigger)
        {
            trigger.Character.SendServerMessage("Le pack V.I.P permet d'augmenter :\n" +
                                                "- L'expérience x2 et xp craft x2 .\n" +
                                                "- Le drops de ressources x1.5.\n" +
                                                "- Mais aussi obtenir :\n" +
                                                "- Potion de changement de couleur illimité .\n" +
                                                "- Des commandes exclusives.\n" +
                                                "- Potion de Retour en donjon.\n" +
                                                "- Potion de Débugmap.\n" +
                                                "- Un titre et un ornement.\n" +
                                                "La durée du pack est : <b>Illimitée</b>.\n" +
                                                "Prix : <b>1350 ogrines.</b>", Color.Red);

            trigger.Character.SendServerMessage("Le pack V.I.P Flambeur permet d'augmenter :\n" +
                                                "- L'expérience x2 et xp craft x2 .\n" +
                                                "- Le drops de ressources x1.5.\n" +
                                                "- Mais aussi obtenir :\n" +
                                                "- Potion de changement de couleur illimité .\n" +
                                                "- Des commandes exclusives.\n" +
                                                "- Potion de Retour en donjon.\n" +
                                                "- Potion de Débugmap.\n" +
                                                "- trois titres et trois ornements.\n" +
                                                "- Un kit parcho 100.\n" +
                                                "- Un ticket de loterie.\n" +
                                                "La durée du pack est : <b>Illimitée</b>.\n" +
                                                "Prix : <b>2700 ogrines.</b>", Color.Yellow);
        }
    }
}