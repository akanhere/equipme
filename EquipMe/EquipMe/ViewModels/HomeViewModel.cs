using CommunityToolkit.Mvvm.Input;
using EquipMe.Services.Navigation;
using EquipMe.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace EquipMe.ViewModels
{
    public partial class HomeViewModel : ViewModelBase
    {


        INavigationService _navigationService;
        public HomeViewModel(INavigationService navigationService):base(navigationService)
        {
            _navigationService = navigationService;
        }

        [RelayCommand]
        private async Task MoveAsync()
        {
            await NavigationService.NavigateToAsync("Rounds");
        }
    }
}

