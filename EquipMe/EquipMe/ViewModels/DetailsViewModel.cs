using System;
using CommunityToolkit.Mvvm.Input;
using EquipMe.Services.Dialog;
using EquipMe.Services.Navigation;
using EquipMe.Services.Settings;
using EquipMe.ViewModels.Base;

namespace EquipMe.ViewModels
{
	public partial class DetailsViewModel:ViewModelBase
	{
		IDialogService _dialogService;
		public DetailsViewModel(INavigationService navigationService, ISettingsService settingsService, IDialogService dialogService):base(navigationService)
		{
			_dialogService = dialogService;
		}

		[RelayCommand]
		public async Task ShowDialogAsync()
		{
			await _dialogService.ShowAlertAsync("Hello Manasvi", "Greetings", "OK");
		}
	}
}


