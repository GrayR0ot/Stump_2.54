using Stump.DofusProtocol.Enums;
using Stump.DofusProtocol.Types;
using Stump.Server.WorldServer.Game.Actors.RolePlay.Characters;
using Stump.Server.WorldServer.Game.Actors.RolePlay.Npcs;
using Stump.Server.WorldServer.Game.Conditions;
using Stump.Server.WorldServer.Game.Songes;

namespace Stump.Server.WorldServer.Database.Npcs.Replies
{
    public abstract class NpcReply
    {
        protected NpcReply()
        {
            Record = new NpcReplyRecord();
        }

        protected NpcReply(NpcReplyRecord record)
        {
            Record = record;
        }

        public int Id
        {
            get => Record.Id;
            set => Record.Id = value;
        }


        public int ReplyId
        {
            get => Record.ReplyId;
            set => Record.ReplyId = value;
        }

        public int MessageId
        {
            get => Record.MessageId;
            set => Record.MessageId = value;
        }

        public ConditionExpression CriteriaExpression
        {
            get => Record.CriteriaExpression;
            set => Record.CriteriaExpression = value;
        }

        public NpcMessage Message
        {
            get => Record.Message;
            set => Record.Message = value;
        }

        public NpcReplyRecord Record { get; }

        public virtual bool CanShow(Npc npc, Character character)
        {
            return true;
        }

        public virtual bool CanExecute(Npc npc, Character character)
        {
            return Record.CriteriaExpression == null || Record.CriteriaExpression.Eval(character);
        }

        public virtual bool Execute(Npc npc, Character character)
        {
            if (CanExecute(npc, character))
                if (npc.TemplateId == 2978)
                {
                    if (character.Client.Account.UserGroupId == 5)
                    {
                        if (ReplyId == 26029)
                        {
                            character.breachStep = 1;
                            character.breachBoosts = new ObjectEffectInteger[] { };
                            character.breachBranches = BreachBranches.generateSongeBranches(character);
                            character.breachBudget = 0;
                            character.breachBuyables = new BreachReward[] { };
                            return true;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }

            return true;

            character.SendInformationMessage(TextInformationTypeEnum.TEXT_INFORMATION_ERROR, 34);
            return false;
        }
    }
}