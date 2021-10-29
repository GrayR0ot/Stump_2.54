using System.Collections;
using Stump.DofusProtocol.D2oClasses;

namespace ItemTemplateEffectGenerator
{
    public class CustomItems
    {
        private string name;
        private Item item;
        
        public static readonly CustomItems ITEM1 = new CustomItems("Test", new Item());

        public static IEnumerable Values
        {
            get
            {
                yield return ITEM1;
            }
        }

        public CustomItems(string name, Item item)
        {
            this.name = name;
            this.item = item;
        }

        public string Name
        {
            get => name;
            set => name = value;
        }

        public Item Item
        {
            get => item;
            set => item = value;
        }
    }
}