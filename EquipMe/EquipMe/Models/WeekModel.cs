﻿using System;
namespace EquipMe.Models
{
    public class WeekModel : BaseModel
    {
        public DateTime LastDay { get; set; }
        public DateTime StartDay { get; set; }
        public string WeekString { get; set; }
    }
}

