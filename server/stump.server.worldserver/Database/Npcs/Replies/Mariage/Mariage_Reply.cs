//using Database.Mariages;
//using Stump.DofusProtocol.Enums;
//using Stump.DofusProtocol.Messages;
//using Stump.Server.BaseServer.Database;
//using Stump.Server.WorldServer;
//using Stump.Server.WorldServer.Database.Npcs;
//using Stump.Server.WorldServer.Database.Npcs.Replies;
//using Stump.Server.WorldServer.Game;
//using Stump.Server.WorldServer.Game.Actors.RolePlay.Characters;
//using Stump.Server.WorldServer.Game.Actors.RolePlay.Npcs;
//using Stump.Server.WorldServer.Handlers.Context;
//using System;
//using System.Collections.Generic;
//using System.Drawing;

//namespace Database.Npcs.Replies.Mariage
//{
//    [Discriminator("Mariage", typeof(NpcReply), new Type[] { typeof(NpcReplyRecord) })]
//    class Mariage_Reply : NpcReply
//    {
//        //private static System.Timers.Timer aTimer = new System.Timers.Timer(9000);
//        public Mariage_Reply(NpcReplyRecord record) : base(record)
//        {
//        }

//        public List<SpouseRecord> SpouseRecord;
//        bool update = false;

//        public override bool Execute(Npc npc, Character character)
//        {
//            bool flag = true;
//            if (character.Record.CurrentSpouse != 0)
//                character.SendServerMessage("Vous ne pouvez pas vous marier car vous êtes déjà marié.", Color.Red);
//            else
//            {
//                Character Spouse = null;
//                if (character.Cell.Id == 358 || character.Cell.Id == 329)
//                {
//                    int SpouseCount = 0;
//                    foreach (var SpouseInCell in character.Map.GetAllCharacters())
//                    {
//                        if (!SpouseInCell.IsFighting() && SpouseInCell != character && (SpouseInCell.Cell.Id == 329 || SpouseInCell.Cell.Id == 358))
//                        {
//                            SpouseCount++;

//                            if (SpouseInCell.Cell.Id == character.Cell.Id)
//                            {
//                                character.SendServerMessage("Il y a une personne dans la même cellule que vous.", Color.Red);
//                                flag = false;
//                                break;
//                            }

//                            if (SpouseCount > 1)
//                            {
//                                character.SendServerMessage("Il y a deux personnes dans la seconde cellule.", Color.Red);
//                                flag = false;
//                                break;
//                            }

//                            Spouse = SpouseInCell;
//                        }
//                    }
//                }
//                else
//                {
//                    character.SendServerMessage("Vous devez vous placer sur la cellule correspondante à votre sexe", Color.Red);
//                    flag = false;
//                }

//                if (flag)
//                    if (Spouse != null)
//                        if (Spouse.Record.CurrentSpouse == 0)
//                            Marier(character, Spouse);
//                        else
//                            character.SendServerMessage("Vous ne pouvez pas vous marier avec cette personne parce que elle est déjà mariée !", Color.Red);
//                    else
//                        character.SendServerMessage("Il n'y a personne dans la seconde cellule. Trouvez-vous quelqu'un !", Color.Red);
//            }

//            return flag;
//        }

//        public void Marier(Character character, Character Spouse)
//        {
//            //int attendre = 0;

//            if (character.Cell.Id == 358)
//            {
//                character.Direction = DirectionsEnum.DIRECTION_NORTH_WEST;
//                ContextHandler.SendGameMapChangeOrientationMessage(character.Client.Character.CharacterContainer.Clients, character);
//                Spouse.Direction = DirectionsEnum.DIRECTION_SOUTH_EAST;
//                ContextHandler.SendGameMapChangeOrientationMessage(Spouse.Client.Character.CharacterContainer.Clients, Spouse);
//            }
//            else
//            {
//                character.Direction = DirectionsEnum.DIRECTION_SOUTH_EAST;
//                ContextHandler.SendGameMapChangeOrientationMessage(character.Client.Character.CharacterContainer.Clients, character);
//                Spouse.Direction = DirectionsEnum.DIRECTION_NORTH_WEST;
//                ContextHandler.SendGameMapChangeOrientationMessage(Spouse.Client.Character.CharacterContainer.Clients, Spouse);
//            }

//            character.Say(Spouse.Name + " veux tu m'épouser ?");
//            Spouse.Say("Oui je le veux !");

//            character.Record.CurrentSpouse = Spouse.Id;
//            Spouse.Record.CurrentSpouse = character.Id;

//            WorldServer.Instance.DBAccessor.Database.Update(character.Record);
//            WorldServer.Instance.DBAccessor.Database.Update(Spouse.Record);
//            //aTimer.Dispose();

//            #region Addspouse            
//            SpouseRecord spousef = new SpouseRecord
//            {
//                OwnerName = character.Name,
//                OwnerId = character.Id,
//                SpouseId = Spouse.Id,
//                SpouseAccountId = Spouse.Account.Id,
//                name = Spouse.Name,
//                level = Spouse.Level,
//                breed = (sbyte)Spouse.BreedId,
//                sex = (sbyte)Spouse.Sex,
//                look = Spouse.Record.DefaultLookString,
//                alignement = (sbyte)Spouse.AlignmentSide,
//                guilldName = Spouse.Guild != null ? Spouse.Guild.Name : "Aucune",
//                Map = Spouse.Map.Id,
//                SubArea = Spouse.SubArea.Id,
//                PvPEnabled = Spouse.PvPEnabled,
//                IsFighting = Spouse.IsFighting(),
//                IsNew = true,
//            };

//            WorldServer.Instance.DBAccessor.Database.Insert(spousef);

//            SpouseRecord spouseh = new SpouseRecord
//            {
//                OwnerName = Spouse.Name,
//                OwnerId = Spouse.Id,
//                SpouseId = character.Id,
//                SpouseAccountId = character.Account.Id,
//                name = character.Name,
//                level = character.Level,
//                breed = (sbyte)character.BreedId,
//                sex = (sbyte)character.Sex,
//                look = character.Record.DefaultLookString,
//                alignement = (sbyte)character.AlignmentSide,
//                guilldName = character.Guild != null ? character.Guild.Name : "Aucune",
//                Map = character.Map.Id,
//                SubArea = character.SubArea.Id,
//                PvPEnabled = character.PvPEnabled,
//                IsFighting = character.IsFighting(),
//                IsNew = true,
//            };

//            WorldServer.Instance.DBAccessor.Database.Insert(spouseh);
//            #endregion

//            //attendre = 0; while (attendre < 99999999) attendre++;
//            character.PlayEmote(EmotesEnum.EMOTE_FAIRE_UN_BISOU, true);
//            Spouse.PlayEmote(EmotesEnum.EMOTE_FAIRE_UN_BISOU, true);

//            //character.Spouse.SendSpouseStatueInfromation();
//            //Spouse.Spouse.SendSpouseStatueInfromation();

//            character.Client.Send(new SpouseStatusMessage(true));
//            Spouse.Client.Send(new SpouseStatusMessage(true));

//            character.Client.Send(new CinematicMessage(14));
//            Spouse.Client.Send(new CinematicMessage(14));

//            foreach (var AllCharacterInMap in World.Instance.GetCharacters(x => x.Map == character.Map && x.Id != character.Id && x.Id != Spouse.Id))
//            {
//                AllCharacterInMap.Direction = DirectionsEnum.DIRECTION_NORTH_EAST;
//                ContextHandler.SendGameMapChangeOrientationMessage(AllCharacterInMap.Client.Character.CharacterContainer.Clients, AllCharacterInMap);

//                AllCharacterInMap.Say("Hourra et vive les mariés !");
//                AllCharacterInMap.PlayEmote(EmotesEnum.EMOTE_APPLAUDIR, true);
//            }
//            //attendre = 0; while (attendre < 999999999) attendre++;
//            //aTimer.Dispose();

//            foreach (var AllCharacterInMap in World.Instance.GetCharacters(x => x.Map == character.Map && x.Id != character.Id && x.Id != Spouse.Id))
//                AllCharacterInMap.PlayEmote(EmotesEnum.EMOTE_FLEURS, true);

//            character.Client.Send(new PopupWarningMessage(2, "Information", "Vous êtes a présent marié avec " + Spouse.Name + " !"));
//            Spouse.Client.Send(new PopupWarningMessage(2, "Information", "Vous êtes a présent marié avec " + character.Name + " !"));

//            World.Instance.SendAnnounce("Félicitations à " + character.Name + " et " + Spouse.Name + ", ils sont maintenant mariés.", Color.Red);
//        }
//    }
//}

