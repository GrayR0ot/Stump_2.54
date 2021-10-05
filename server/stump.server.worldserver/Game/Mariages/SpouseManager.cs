//using Database.Mariages;
//using Stump.DofusProtocol.Enums;
//using Stump.DofusProtocol.Messages;
//using Stump.DofusProtocol.Types;
//using Stump.Server.WorldServer;
//using Stump.Server.WorldServer.Game;
//using Stump.Server.WorldServer.Game.Actors.Look;
//using Stump.Server.WorldServer.Game.Actors.RolePlay.Characters;
//using Stump.Server.WorldServer.Game.Maps;
//using System.Collections.Generic;
//using System.Drawing;

//namespace Game.Mariages
//{
//    public class SpouseManager
//    {
//        public List<SpouseRecord> SpouseRecord;
//        public Character m_character;
//        public bool Follow = false;
//        public SpouseManager(Character character)
//        {
//            m_character = character;
//            SpouseRecord = WorldServer.Instance.DBAccessor.Database.Fetch<SpouseRecord>(string.Format(SpouseRelator.FetchByOwner, character.Id), new object[0]);
//        }

//        public void SendSpouseInformation(bool IsDisconnected = false)
//        {
//            if (m_character != null)
//            {
//                var spouse = World.Instance.GetCharacter(m_character.Record.CurrentSpouse);
//                if (spouse != null && !spouse.Isdisconnected && IsDisconnected == false)
//                {
//                    if (spouse.Record.CurrentSpouse == 0 || spouse.Record.CurrentSpouse != m_character.Id)
//                        DeleteSpouse();
//                    else
//                    {
//                        try
//                        {
//                            int id = spouse.Id;
//                            byte level = (byte)spouse.Level;
//                            sbyte sex = (sbyte)spouse.Sex;
//                            string name = spouse.Name;
//                            sbyte breed = (sbyte)spouse.Breed.Id;
//                            sbyte alignement = (sbyte)spouse.AlignmentSide;
//                            EntityLook look = spouse.DefaultLook.GetEntityLook();
//                            int map = spouse.Map.Id;
//                            string GuilldeName = spouse.Guild != null ? spouse.Guild.Name : "Aucune";
//                            short subarea = (short)spouse.SubArea.Id;
//                            bool pvpEnabled = spouse.PvPEnabled;
//                            bool infight = spouse.IsFighting();

//                            m_character.Client.Send(
//                                new SpouseInformationsMessage(
//                                    new FriendSpouseOnlineInformations(1, (ulong)id, name, (ushort)level, breed, sex, look,
//                                    new BasicGuildInformations(1, GuilldeName, 1), alignement, infight, false, pvpEnabled, map, subarea)));

//                            AddSpouse(spouse, true);
//                        }
//                        catch
//                        {
//                            SendSpouseInformation(true);
//                        }
//                    }
//                }
//                else
//                {
//                    foreach (var record in SpouseRecord)
//                    {
//                        int id = record.SpouseId;
//                        int accountid = record.SpouseAccountId;
//                        long level = record.level;
//                        sbyte sex = record.sex;
//                        string name = record.name;
//                        sbyte breed = record.breed;
//                        sbyte alignement = record.alignement;
//                        EntityLook look = ActorLook.Parse(record.look).GetEntityLook();
//                        string GuilldeName = record.guilldName != string.Empty ? record.guilldName : "Aucune";
//                        m_character.Client.Send(
//                            new SpouseInformationsMessage(
//                                new FriendSpouseInformations(accountid, (ulong)id, name, (ushort)level, breed, sex, look,
//                                new BasicGuildInformations(1, GuilldeName, 1), alignement)));
//                        break;
//                    }
//                }
//            }
//        }

//        public void SendSpouseStatueInfromation()
//        {
//            m_character.Client.Send(new SpouseStatusMessage(true));
//            //SendSpouseInformation();
//        }

//        public void DeleteSpouse(int SpouseId = 0)
//        {
//            Character spouse = World.Instance.GetCharacter(SpouseId);

//            if (spouse != null)
//            {
//                spouse.Spouse.DeleteSpouse();
//                spouse.SendServerMessage(string.Format("Vous venez de vous faire larguer par {0} !", m_character.Name), Color.Red);
//            }

//            m_character.Record.CurrentSpouse = 0;
//            m_character.Client.Send(new SpouseStatusMessage(false));

//            foreach (var deleteSpouse in SpouseRecord)
//            {
//                deleteSpouse.OwnerName = m_character.Name;
//                deleteSpouse.SpouseId = 0;
//                deleteSpouse.SpouseAccountId = 0;
//                deleteSpouse.name = string.Empty;
//                deleteSpouse.level = 0;
//                deleteSpouse.breed = 0;
//                deleteSpouse.sex = 0;
//                deleteSpouse.look = string.Empty;
//                deleteSpouse.alignement = 0;
//                deleteSpouse.guilldName = "Aucune";
//            }

//            Save();
//        }

//        public void AddSpouse(Character Spouse, bool update = false)
//        {
//            if (SpouseRecord.Count == 0 && update == false)
//                SpouseRecord.Add(new SpouseRecord()
//                {
//                    OwnerName = m_character.Name,
//                    OwnerId = m_character.Id,
//                    SpouseId = Spouse.Id,
//                    SpouseAccountId = Spouse.Account.Id,
//                    name = Spouse.Name,
//                    level = Spouse.Level,
//                    breed = (sbyte)Spouse.BreedId,
//                    sex = (sbyte)Spouse.Sex,
//                    look = Spouse.Record.DefaultLookString,
//                    alignement = (sbyte)Spouse.AlignmentSide,
//                    guilldName = Spouse.Guild != null ? Spouse.Guild.Name : "Aucune",
//                    IsNew = true,
//                });
//            else
//            {
//                foreach (var newSpouse in SpouseRecord)
//                {
//                    newSpouse.OwnerName = m_character.Name;
//                    newSpouse.SpouseId = Spouse.Id;
//                    newSpouse.SpouseAccountId = Spouse.Account.Id;
//                    newSpouse.name = Spouse.Name;
//                    newSpouse.level = Spouse.Level;
//                    newSpouse.breed = (sbyte)Spouse.BreedId;
//                    newSpouse.sex = (sbyte)Spouse.Sex;
//                    newSpouse.look = Spouse.Record.DefaultLookString;
//                    newSpouse.alignement = (sbyte)Spouse.AlignmentSide;
//                    newSpouse.guilldName = Spouse.Guild != null ? Spouse.Guild.Name : "Aucune";
//                }
//            }

//            Save();
//        }

//        public void FollowSpouse(Character Spouse)
//        {
//            Follow = true;
//            m_character.Client.Send(new CompassUpdatePartyMemberMessage((sbyte)CompassTypeEnum.COMPASS_TYPE_SPOUSE,
//                new MapCoordinates((short)Spouse.Map.Position.X, (short)Spouse.Map.Position.Y), (ulong)Spouse.Id, true));
//            m_character.Client.Send(new TextInformationMessage((sbyte)TextInformationTypeEnum.TEXT_INFORMATION_MESSAGE, 368, new string[]
//            {
//                       Spouse.Name
//            }));
//            Spouse.Client.Send(new TextInformationMessage((sbyte)TextInformationTypeEnum.TEXT_INFORMATION_MESSAGE, 52, new string[]
//            {
//                       m_character.Name
//            }));
//        }

//        public void StopFollowSpouse(Character spouse = null)
//        {
//            Follow = false;
//            if (spouse != null)
//                spouse.Client.Send(new TextInformationMessage((sbyte)TextInformationTypeEnum.TEXT_INFORMATION_MESSAGE, 53, new List<string>
//                    {
//                        m_character.Name
//                    }));

//            m_character.Client.Send(new CompassResetMessage((sbyte)CompassTypeEnum.COMPASS_TYPE_SPOUSE));
//        }

//        public void UpdateFollowSpouse(Map map, int SpouseID)
//        {
//            Character spouse = World.Instance.GetCharacter(SpouseID);
//            if (spouse != null && spouse.Spouse.Follow)
//                spouse.Client.Send(new CompassUpdatePartyMemberMessage((sbyte)CompassTypeEnum.COMPASS_TYPE_SPOUSE,
//                    new MapCoordinates((short)map.Position.X, (short)map.Position.Y), (ulong)m_character.Id, true));
//            else if (spouse != null)
//            {
//                spouse.Client.Send(new CompassResetMessage((sbyte)CompassTypeEnum.COMPASS_TYPE_SPOUSE));
//                spouse.Spouse.Follow = false;
//            }
//        }

//        public void Save()
//        {
//            foreach (var SaveSpouse in SpouseRecord)
//            {
//                if (SaveSpouse.IsNew)
//                {
//                    WorldServer.Instance.DBAccessor.Database.Insert(SaveSpouse);
//                    SaveSpouse.IsNew = false;
//                }
//                else
//                    WorldServer.Instance.DBAccessor.Database.Update(SaveSpouse);
//            }
//        }

//        public bool TpToSpouse(Character Spouse)
//        {
//            bool flag = true;
//            switch (Spouse.Map.Id)
//            {
//                // dj blop
//                case 18876416:
//                case 18879488:
//                case 18874370:
//                case 18875396:
//                case 18877442:
//                // Royal Mouth
//                case 55050240:
//                case 55050242:
//                case 55052290:
//                case 55053312:
//                // Mansot
//                case 56098816:
//                case 56099840:
//                case 56100864:
//                case 56101888:
//                case 56102912:
//                // Ben 
//                case 56360960:
//                case 56361984:
//                case 56363008:
//                case 56364032:
//                case 56365056:
//                // Sakai
//                case 57934593:
//                case 57935617:
//                case 57936641:
//                case 57937665:
//                case 57938689:
//                // Korriandre
//                case 62915584:
//                case 62916608:
//                case 62917632:
//                case 62918656:
//                case 62919680:
//                // Glour
//                case 62131720:
//                case 62132744:
//                case 62133768:
//                case 62134792:
//                case 62135816:
//                // Kolosso
//                case 61998084:
//                case 61998082:
//                case 61998338:
//                case 61998340:
//                case 61868036:
//                // Obsidiantre
//                case 57149697:
//                case 57151233:
//                case 57152769:
//                case 57154305:
//                case 57155841:
//                    flag = false;
//                    break;
//            }

//            return flag;
//        }
//    }
//}

