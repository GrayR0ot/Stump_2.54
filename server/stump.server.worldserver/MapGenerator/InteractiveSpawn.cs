namespace MapGenerator
{
    public class InteractiveSpawn
    {
        private int id;
        private int templateId;
        private int mapId;
        private int cellId;
        private int elementId;
        private short animated;
        private string template;

        public InteractiveSpawn(int id, int templateId, int mapId, int cellId, int elementId, short animated, string template)
        {
            this.id = id;
            this.templateId = templateId;
            this.mapId = mapId;
            this.cellId = cellId;
            this.elementId = elementId;
            this.animated = animated;
            this.template = template;
        }

        public int Id
        {
            get => id;
            set => id = value;
        }

        public int TemplateId
        {
            get => templateId;
            set => templateId = value;
        }

        public int MapId
        {
            get => mapId;
            set => mapId = value;
        }

        public int CellId
        {
            get => cellId;
            set => cellId = value;
        }

        public int ElementId
        {
            get => elementId;
            set => elementId = value;
        }

        public short Animated
        {
            get => animated;
            set => animated = value;
        }

        public string Template
        {
            get => template;
            set => template = value;
        }
    }
}