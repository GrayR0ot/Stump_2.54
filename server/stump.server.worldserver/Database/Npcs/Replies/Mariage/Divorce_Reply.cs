//using Stump.Server.BaseServer.Database;
//using Stump.Server.WorldServer.Database.Npcs;
//using Stump.Server.WorldServer.Database.Npcs.Replies;
//using System;
//using Stump.Server.WorldServer.Game.Actors.RolePlay.Characters;
//using Stump.Server.WorldServer.Game.Actors.RolePlay.Npcs;
//using System.Drawing;
//using Stump.Server.WorldServer.Game;

//namespace Database.Npcs.Replies.Mariage
//{
//    [Discriminator("Divorce", typeof(NpcReply), new Type[] { typeof(NpcReplyRecord) })]
//    class Divorce_Reply : NpcReply
//    {
//        public Divorce_Reply(NpcReplyRecord record) : base(record)
//        {
//        }
//        public override bool Execute(Npc npc, Character character)
//        {
//            if (character.Record.CurrentSpouse != 0)
//            {
//                Character spouse = World.Instance.GetCharacter(character.Record.CurrentSpouse);
//                character.Spouse.StopFollowSpouse(spouse);
//                character.Spouse.DeleteSpouse(character.Record.CurrentSpouse);
//                character.SendServerMessage("Vous venez de divorcer !", Color.Red);
//            }
//            else
//                character.SendServerMessage("Vous ne pouvez pas divorcer, vous n'êtes pas marié !", Color.Red);
//            return true;
//        }
//    }
//}

