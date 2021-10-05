using System;
using Stump.DofusProtocol.Types;
using Stump.Server.WorldServer.Database.Interactives;
using Stump.Server.WorldServer.Game.Actors.RolePlay.Characters;

namespace Stump.Server.WorldServer.Game.Interactives.Skills
{
    public abstract class Skill
    {
        protected Skill(int id, InteractiveSkillTemplate skillTemplate, InteractiveObject interactiveObject)
        {
            Id = id;
            SkillTemplate = skillTemplate;
            InteractiveObject = interactiveObject;
        }

        public int Id { get; }

        public InteractiveSkillTemplate SkillTemplate { get; }

        public InteractiveObject InteractiveObject { get; }

        public DateTime SkillEndTime { get; private set; }

        public virtual int GetDuration(Character character, bool forNetwork = false)
        {
            return 0;
        }

        public virtual bool IsEnabled(Character character)
        {
            return !character.IsGhost() && AreConditionsFilled(character);
        }

        public virtual bool CanUse(Character character)
        {
            return IsEnabled(character) && !character.IsBusy();
        }

        public virtual bool AreConditionsFilled(Character character)
        {
            return true;
        }

        public virtual int StartExecute(Character character)
        {
            SkillEndTime = DateTime.Now.AddMilliseconds(GetDuration(character));

            character.LastSkillUsed = this;
            return GetDuration(character);
        }

        public virtual void EndExecute(Character character)
        {
            character.LastSkillUsed = null;
        }

        public InteractiveElementSkill GetInteractiveElementSkill()
        {
            return new InteractiveElementSkill((uint) SkillTemplate.Id, Id);
        }
    }
}