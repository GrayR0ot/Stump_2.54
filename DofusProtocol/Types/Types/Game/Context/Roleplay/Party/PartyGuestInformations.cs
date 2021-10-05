using System;
using System.Linq;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Types
{
    [Serializable]
    public class PartyGuestInformations
    {
        public const short Id = 374;

        public PartyGuestInformations(ulong guestId, ulong hostId, string name, EntityLook guestLook, sbyte breed,
            bool sex, PlayerStatus status, PartyEntityBaseInformation[] entities)
        {
            GuestId = guestId;
            HostId = hostId;
            Name = name;
            GuestLook = guestLook;
            Breed = breed;
            Sex = sex;
            Status = status;
            Entities = entities;
        }

        public PartyGuestInformations()
        {
        }

        public virtual short TypeId => Id;

        public ulong GuestId { get; set; }
        public ulong HostId { get; set; }
        public string Name { get; set; }
        public EntityLook GuestLook { get; set; }
        public sbyte Breed { get; set; }
        public bool Sex { get; set; }
        public PlayerStatus Status { get; set; }
        public PartyEntityBaseInformation[] Entities { get; set; }

        public virtual void Serialize(IDataWriter writer)
        {
            writer.WriteVarULong(GuestId);
            writer.WriteVarULong(HostId);
            writer.WriteUTF(Name);
            GuestLook.Serialize(writer);
            writer.WriteSByte(Breed);
            writer.WriteBoolean(Sex);
            writer.WriteShort(Status.TypeId);
            Status.Serialize(writer);
            writer.WriteShort((short) Entities.Count());
            for (var entitiesIndex = 0; entitiesIndex < Entities.Count(); entitiesIndex++)
            {
                var objectToSend = Entities[entitiesIndex];
                objectToSend.Serialize(writer);
            }
        }

        public virtual void Deserialize(IDataReader reader)
        {
            GuestId = reader.ReadVarULong();
            HostId = reader.ReadVarULong();
            Name = reader.ReadUTF();
            GuestLook = new EntityLook();
            GuestLook.Deserialize(reader);
            Breed = reader.ReadSByte();
            Sex = reader.ReadBoolean();
            Status = ProtocolTypeManager.GetInstance<PlayerStatus>(reader.ReadShort());
            Status.Deserialize(reader);
            var entitiesCount = reader.ReadUShort();
            Entities = new PartyEntityBaseInformation[entitiesCount];
            for (var entitiesIndex = 0; entitiesIndex < entitiesCount; entitiesIndex++)
            {
                var objectToAdd = new PartyEntityBaseInformation();
                objectToAdd.Deserialize(reader);
                Entities[entitiesIndex] = objectToAdd;
            }
        }
    }
}