using System;
namespace EquipMe.Models
{
    public class Parameter
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public object Value { get; set; }
        public object SelectedValues { get; set; }
    }
}

