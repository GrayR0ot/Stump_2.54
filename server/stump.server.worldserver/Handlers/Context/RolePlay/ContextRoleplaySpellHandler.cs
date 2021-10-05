using System.Linq;
using Stump.DofusProtocol.Enums;
using Stump.DofusProtocol.Messages;
using Stump.Server.WorldServer.Core.Network;
using Stump.Server.WorldServer.Game.Spells;

namespace Stump.Server.WorldServer.Handlers.Context.RolePlay
{
    public partial class ContextRoleplayHandler : WorldHandlerContainer
    {
        [WorldHandler(SpellVariantActivationRequestMessage.Id)]
        public static void HandleSpellVariantActivationMessage(WorldClient client,
            SpellVariantActivationRequestMessage message)
        {
            if (!client.Character.IsFighting())
            {
                var breedSpell = SpellManager.GetSpellVariant(message.spellId);

                if (breedSpell == null)
                    return;

                if (client.Character.Breed.Id == breedSpell.BreedId)
                {
                    var variant = breedSpell.VariantId == message.spellId;
                    var required = variant ? breedSpell.Spell : breedSpell.VariantId;

                    if (client.Character.Spells.GetSpell(required) == null)
                    {
                        client.Send(new SpellVariantActivationMessage(message.spellId, false));
                        return;
                    }

                    if (client.Character.Level < (variant ? breedSpell.VariantLevel : breedSpell.ObtainLevel))
                    {
                        client.Send(new SpellVariantActivationMessage(message.spellId, false));
                        return;
                    }

                    client.Character.Shortcuts.SwapSpellShortcuts((short) required, (short) message.spellId);
                    client.Character.Spells.GetSpell(required).Record.Active = false;
                    client.Character.Spells.GetSpell(message.spellId).Record.Active = true;
                    client.Send(new ShortcutBarContentMessage((sbyte) ShortcutBarEnum.SPELL_SHORTCUT_BAR,
                        client.Character.Shortcuts.GetShortcuts(ShortcutBarEnum.SPELL_SHORTCUT_BAR)
                            .Select(entry => entry.GetNetworkShortcut())));
                    client.Send(new SpellVariantActivationMessage(message.spellId, true));
                }
                else
                {
                    client.Send(new SpellVariantActivationMessage(message.spellId, false));
                }
            }
        }
    }
}