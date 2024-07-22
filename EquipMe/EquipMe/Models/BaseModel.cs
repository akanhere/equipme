using System;
using System.ComponentModel;

namespace EquipMe.Models
{
    public class BaseModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
    }
}

