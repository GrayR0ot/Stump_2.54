using System;
using Stump.DofusProtocol.D2oClasses.Tools.D2o;

namespace Stump.DofusProtocol.D2oClasses
{
    [D2OClass("Subhint", "com.ankamagames.dofus.datacenter.misc")]
    [Serializable]
    public class Subhint : IDataObject, IIndexedData
    {
        public const string MODULE = "Subhints";
        public int hint_anchor;
        public string hint_anchored_element;
        public double hint_creation_date;
        public int hint_height;
        public string hint_highlighted_element;
        public int hint_id;
        public int hint_order;
        public string hint_parent_uid;
        public int hint_position_x;
        public int hint_position_y;
        public int hint_tooltip_offset_x;
        public int hint_tooltip_offset_y;
        public int hint_tooltip_position_enum;

        [I18NField] public uint hint_tooltip_text;

        public string hint_tooltip_url;
        public int hint_tooltip_width;
        public int hint_width;

        [D2OIgnore]
        public int Hint_id
        {
            get => hint_id;
            set => hint_id = value;
        }

        [D2OIgnore]
        public string Hint_parent_uid
        {
            get => hint_parent_uid;
            set => hint_parent_uid = value;
        }

        [D2OIgnore]
        public string Hint_anchored_element
        {
            get => hint_anchored_element;
            set => hint_anchored_element = value;
        }

        [D2OIgnore]
        public int Hint_anchor
        {
            get => hint_anchor;
            set => hint_anchor = value;
        }

        [D2OIgnore]
        public int Hint_position_x
        {
            get => hint_position_x;
            set => hint_position_x = value;
        }

        [D2OIgnore]
        public int Hint_position_y
        {
            get => hint_position_y;
            set => hint_position_y = value;
        }

        [D2OIgnore]
        public int Hint_width
        {
            get => hint_width;
            set => hint_width = value;
        }

        [D2OIgnore]
        public int Hint_height
        {
            get => hint_height;
            set => hint_height = value;
        }

        [D2OIgnore]
        public string Hint_highlighted_element
        {
            get => hint_highlighted_element;
            set => hint_highlighted_element = value;
        }

        [D2OIgnore]
        public int Hint_order
        {
            get => hint_order;
            set => hint_order = value;
        }

        [D2OIgnore]
        public uint Hint_tooltip_text
        {
            get => hint_tooltip_text;
            set => hint_tooltip_text = value;
        }

        [D2OIgnore]
        public int Hint_tooltip_position_enum
        {
            get => hint_tooltip_position_enum;
            set => hint_tooltip_position_enum = value;
        }

        [D2OIgnore]
        public string Hint_tooltip_url
        {
            get => hint_tooltip_url;
            set => hint_tooltip_url = value;
        }

        [D2OIgnore]
        public int Hint_tooltip_offset_x
        {
            get => hint_tooltip_offset_x;
            set => hint_tooltip_offset_x = value;
        }

        [D2OIgnore]
        public int Hint_tooltip_offset_y
        {
            get => hint_tooltip_offset_y;
            set => hint_tooltip_offset_y = value;
        }

        [D2OIgnore]
        public int Hint_tooltip_width
        {
            get => hint_tooltip_width;
            set => hint_tooltip_width = value;
        }

        [D2OIgnore]
        public double Hint_creation_date
        {
            get => hint_creation_date;
            set => hint_creation_date = value;
        }

        int IIndexedData.Id => hint_id;
    }
}