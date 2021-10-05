using Stump.ORM;
using Stump.ORM.SubSonic.SQLGeneration.Schema;
using Stump.Server.WorldServer.Database.Characters;

namespace Stump.Server.WorldServer.Database.Shortcuts
{
    public abstract class Shortcut : ISaveIntercepter
    {
        private int m_id;

        private int m_ownerId;

        private int m_slot;

        protected Shortcut()
        {
        }

        protected Shortcut(CharacterRecord owner, int slot)
        {
            OwnerId = owner.Id;
            Slot = slot;
            IsNew = true;
        }

        public int Id
        {
            get => m_id;
            set
            {
                m_id = value;
                IsDirty = true;
            }
        }

        [Index]
        public int OwnerId
        {
            get => m_ownerId;
            set
            {
                m_ownerId = value;
                IsDirty = true;
            }
        }

        public int Slot
        {
            get => m_slot;
            set
            {
                m_slot = value;
                IsDirty = true;
            }
        }

        [Ignore] public bool IsDirty { get; set; }

        [Ignore] public bool IsNew { get; set; }

        public void BeforeSave(bool insert)
        {
            IsDirty = false;
        }

        public abstract DofusProtocol.Types.Shortcut GetNetworkShortcut();
    }
}