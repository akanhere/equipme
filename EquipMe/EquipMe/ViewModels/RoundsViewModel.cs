using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using EquipMe.Models;
using EquipMe.Services.Data;
using EquipMe.Services.Date;
using EquipMe.Services.Location;
using EquipMe.Services.Navigation;
using EquipMe.Services.Settings;
using EquipMe.ViewModels.Base;

namespace EquipMe.ViewModels
{
    public class RoundsViewModel:ViewModelBase
    {
        INavigationService _navigationService;
        IDateService _dateService;
        IGeoLocation _geoLocation;
        ISettingsService _settingsService;

        private ObservableCollection<Round> _rounds;
        private Round _selectedRound;
        private IDataService _dataService;
        private DayModel _selectedDay;


        public ObservableCollection<DayModel> DaysList { get; set; }
        public WeekModel Week { get; set; } 

        public Round SelectedRound
        {
            get
            {
                return _selectedRound;
            }
            set
            {
                if (_selectedRound != value)
                {
                    _selectedRound = value;
                    UpdateOnRoundSelection();
                }
            }
        }

        public RoundsViewModel(INavigationService navigationService, IDataService dataService, IDateService dateService, IGeoLocation geoLocation, ISettingsService settingsService)
            :base(navigationService)
        {
            _navigationService = navigationService;
            _dataService = dataService;
            _dateService = dateService;
            _geoLocation = geoLocation;
            _settingsService = settingsService;



            Week = _dateService.GetWeek(DateTime.Now);
            DaysList = new ObservableCollection<DayModel>(_dateService.GetDayList(Week.StartDay, Week.LastDay));
            _selectedDay = new DayModel() { Date = DateTime.Today };
        }

        private async void UpdateOnRoundSelection()
        {
            if (_selectedRound != null)
            {
                await _geoLocation.GetGpsLocation();
                Debug.WriteLine($"{_settingsService.Latitude} | {_settingsService.Longitude}");
                await _navigationService.NavigateToAsync("RoundDetails", new Dictionary<string, object> { { nameof(Round.Name), _selectedRound.Name } });
            }
        }

        public ObservableCollection<Round> Rounds
        {
            get
            {
                if (_rounds == null)
                {
                   var rounds =  _dataService.GetRoundsAsync();
                    _rounds = new ObservableCollection<Round>(rounds);
                   
                }
                return _rounds;
            }
        }

        public  override  async Task InitializeAsync()
        {
            
        }

        private void SetActiveDay(DayModel day = null)
        {
            ResetActiveDay();
            if (day != null)
            {
                _selectedDay = day;
                day.State = DayStateEnum.Active;
            }
            else
            {
                var selectedDate = DaysList.FirstOrDefault(d => d.Date == _selectedDay.Date);
                if (selectedDate != null)
                {
                    selectedDate.State = DayStateEnum.Active;
                }
            }
        }

        private void ResetActiveDay()
        {
            var selectedDay = DaysList?.FirstOrDefault(d => d.State.Equals(DayStateEnum.Active));
            if (selectedDay != null)
            {
                selectedDay.State = selectedDay.Date < DateTime.Now.Date ? DayStateEnum.Past : DayStateEnum.Normal;
            }
        }

    }
}

