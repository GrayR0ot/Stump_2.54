using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Stump.Core.Reflection;
using Stump.DofusProtocol.Messages;
using Stump.DofusProtocol.Types;
using Stump.Server.BaseServer.Database;
using Stump.Server.WorldServer.Database.Interactives;
using Stump.Server.WorldServer.Database.Monsters;
using Stump.Server.WorldServer.Game.Actors.Fight;
using Stump.Server.WorldServer.Game.Actors.RolePlay.Characters;
using Stump.Server.WorldServer.Game.Actors.RolePlay.Monsters;
using Stump.Server.WorldServer.Game.Fights;
using Stump.Server.WorldServer.Game.Maps;
using Stump.Server.WorldServer.Game.Maps.Cells;
using Stump.Server.WorldServer.Game.Songes;
using Stump.Server.WorldServer.Handlers.Context;

namespace Stump.Server.WorldServer.Game.Interactives.Skills
{
    [Discriminator("EliocalypseAstrubBreach", typeof(Skill), typeof(int), typeof(InteractiveCustomSkillRecord),
        typeof(InteractiveObject))]
    public class EliocalypseAstrubBreach : CustomSkill
    {
        public EliocalypseAstrubBreach(int id, InteractiveCustomSkillRecord skillTemplate,
            InteractiveObject interactiveObject) : base(id, skillTemplate, interactiveObject)
        {
        }

        public override int StartExecute(Character character)
        {
            character.SendServerMessage("Faille pour aller aux zones eliocalypse!");

            return base.StartExecute(character);
        }
    }
}