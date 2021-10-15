using Stump.DofusProtocol.Messages;
using Stump.DofusProtocol.Types;
using Stump.ORM.SubSonic.Extensions;
using Stump.Server.WorldServer.Game.Actors.RolePlay.Characters;

namespace Stump.Server.WorldServer.Game.Songes
{
    public class SongesBranchesGUI
    {
        private readonly Character character;

        public SongesBranchesGUI(Character character)
        {
            this.character = character;
        }

        public void Open()
        {
            openBranches();
        }

        public void openBranches()
        {
            if (character.songesBranches == null)
                character.songesBranches = SongeBranches.generateSongeBranches(character);

            character.Client.Send(new BreachBranchesMessage(character.songesBranches));
            if (character.songesBuyables != null && character.songesBuyables.Length >= 1)
            {
                var breachReward = new BreachReward();
                character.songesBuyables[0].CopyTo(breachReward);
                breachReward.Bought = true;
                character.Client.Send(new BreachRewardsMessage(character.songesBuyables,
                    breachReward)); //ASSURANCE DEFAITE
            }
        }
    }
}