using System;
using EquipMe.Models;

namespace EquipMe.Services.Date
{
    public interface IDateService
    {
        WeekModel GetWeek(DateTime date);

        List<DayModel> GetDayList(DateTime firstDayInWeek, DateTime lastDayInWeek);
    }
}

