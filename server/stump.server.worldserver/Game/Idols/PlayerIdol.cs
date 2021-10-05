using System.Collections.Generic;
using Stump.DofusProtocol.Types;
using Stump.Server.WorldServer.Database.Idols;
using Stump.Server.WorldServer.Game.Actors.RolePlay.Characters;

namespace Stump.Server.WorldServer.Game.Idols
{
    public class PlayerIdol
    {
        public PlayerIdol(Character owner, IdolTemplate idolTemplate)
        {
            Owner = owner;
            Template = idolTemplate;
        }

        public Character Owner { get; }

        public IdolTemplate Template { get; }

        public int Id => Template.Id;

        public int ExperienceBonus => Template.ExperienceBonus;

        public int DropBonus => Template.DropBonus;

        public int Score => Template.Score;

        public double GetSynergy(List<PlayerIdol> idols)
        {
            var coeff = 1d;

            for (var i = 0; i < idols.Count; i++)
            for (var j = 0; j < Template.SynergyIdolsIds.Count; j++)
                if (Template.SynergyIdolsIds[j] == idols[i].Id)
                    coeff *= Template.SynergyIdolsCoef[j];

            return coeff;
        }

        #region Network

        public Idol GetNetworkIdol()
        {
            return new Idol((ushort) Id, (ushort) ExperienceBonus, (ushort) DropBonus);
        }

        public Idol GetNetworkPartyIdol()
        {
            return new PartyIdol((ushort) Id, (ushort) ExperienceBonus, (ushort) DropBonus, new[] {(ulong) Owner.Id});
        }

        #endregion Network
    }
}