using System;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using EquipMe.Models;
using EquipMe.Services.Data;
using EquipMe.Services.Navigation;
using EquipMe.ViewModels.Base;

namespace EquipMe.ViewModels
{
	[QueryProperty(nameof(RoundName), "Name")]
	public partial class RoundDetailsViewModel:ViewModelBase
	{
		IDataService _dataService;

		[ObservableProperty]
		private string _roundName;

		[ObservableProperty]
		private Round _selectedRound;

		[ObservableProperty]
		private ObservableCollection<Equipment> _equipments;

		public RoundDetailsViewModel(INavigationService navigationService, IDataService dataService)
			:base(navigationService)
		{
			_dataService = dataService;
		}

        public override async Task InitializeAsync()
        {
			
			SelectedRound = _dataService.GetRoundByName(RoundName);
			Equipments = SelectedRound.Equipments;
            await base.InitializeAsync();
        }
    }
}

