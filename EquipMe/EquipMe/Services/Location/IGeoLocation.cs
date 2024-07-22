using System;
using EquipMe.Services.Settings;

namespace EquipMe.Services.Location
{
	public interface IGeoLocation
	{
        Task GetGpsLocation();
    }
}

