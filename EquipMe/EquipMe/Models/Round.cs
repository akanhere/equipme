using System;
using System.Collections.ObjectModel;

namespace EquipMe.Models
{
    public class Round
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public ObservableCollection<Equipment> Equipments { get; set; }
    }
}

