
using System;
using System.ComponentModel;
using System.Windows.Input;
using EquipMe.Services.Navigation;
using EquipMe.ViewModels.Base;
using EquipMe.Views;

namespace EquipMe.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        private string _username;
        private string _password;

        public string Username
        {
            get { return _username; }
            set
            {
                _username = value;
                OnPropertyChanged(nameof(Username));
            }
        }

        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        public ICommand LoginCommand { get; }
        public ICommand ForgotPasswordCommand { get; }
        public ICommand GoogleLoginCommand { get; }
        public ICommand MicrosoftLoginCommand { get; }

        public LoginViewModel(INavigationService navigationService)
            :base(navigationService)
        {
            LoginCommand = new Command(OnLoginClicked);
            ForgotPasswordCommand = new Command(OnForgotPasswordClicked);
            GoogleLoginCommand = new Command(OnGoogleLoginClicked);
            MicrosoftLoginCommand = new Command(OnMicrosoftLoginClicked);
        }

        private void OnLoginClicked()
        {
            // Handle login logic here
            NavigationService.NavigateToAsync("Rounds");
        }

        private void OnForgotPasswordClicked()
        {
            // Handle forgot password logic here
        }

        private void OnGoogleLoginClicked()
        {
            // Handle Google login logic here
        }

        private void OnMicrosoftLoginClicked()
        {
            // Handle Microsoft login logic here
        }

        
    }
}

