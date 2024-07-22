using System;
using System.Collections.ObjectModel;

namespace EquipMe.Models
{
    public class Equipment
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public ObservableCollection<Parameter> Parameters { get; set; }
    }
}

