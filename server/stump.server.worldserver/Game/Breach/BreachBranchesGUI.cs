using Stump.DofusProtocol.Messages;
using Stump.DofusProtocol.Types;
using Stump.ORM.SubSonic.Extensions;
using Stump.Server.WorldServer.Game.Actors.RolePlay.Characters;

namespace Stump.Server.WorldServer.Game.Songes
{
    public class BreachBranchesGUI
    {
        private readonly Character character;

        public BreachBranchesGUI(Character character)
        {
            this.character = character;
        }

        public void Open()
        {
            openBranches();
        }

        public void openBranches()
        {
            if (character.breachBranches == null)
                character.breachBranches = BreachBranches.generateSongeBranches(character);

            character.Client.Send(new BreachBranchesMessage(character.breachBranches));
            if (character.breachBuyables != null && character.breachBuyables.Length >= 1)
            {
                var breachReward = new BreachReward();
                character.breachBuyables[0].CopyTo(breachReward);
                breachReward.Bought = true;
                character.Client.Send(new BreachRewardsMessage(character.breachBuyables,
                    breachReward)); //ASSURANCE DEFAITE
            }
        }
    }
}