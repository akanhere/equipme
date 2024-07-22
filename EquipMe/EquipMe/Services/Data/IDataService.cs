using System;
using EquipMe.Models;

namespace EquipMe.Services.Data
{
	public interface IDataService
	{
        IEnumerable<Round> GetRoundsAsync();
        Round GetRoundByName(string name);
    }
}

