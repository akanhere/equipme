using EquipMe.Services.Navigation;
using EquipMe.Services.Settings;
using System.Diagnostics;
using System.Globalization;
using System.Reflection;

namespace EquipMe
{
    public partial class App : Application
    {
        INavigationService _navigationService;
        ISettingsService _settingsService;
        public App(INavigationService navigationService, ISettingsService settingsService)
        {
            _navigationService = navigationService;
            _settingsService = settingsService;

            InitializeComponent();

            MainPage = new AppShell(_navigationService);
        }

        protected override async void OnStart()
        {
            base.OnStart();

            if (_settingsService.AllowGpsLocation && !_settingsService.UseFakeLocation)
            {
                await GetGpsLocation();
            }
            if (!_settingsService.UseMocks && !string.IsNullOrEmpty(_settingsService.AuthAccessToken))
            {
                await SendCurrentLocation();
            }

            OnResume();
        }

        private async Task GetGpsLocation()
        {
            try
            {
                var request = new GeolocationRequest(GeolocationAccuracy.High);
                var location = await Geolocation.GetLocationAsync(request, CancellationToken.None).ConfigureAwait(false);

                if (location != null)
                {
                    _settingsService.Latitude = location.Latitude.ToString();
                    _settingsService.Longitude = location.Longitude.ToString();
                }
            }
            catch (Exception ex)
            {
                if (ex is FeatureNotEnabledException || ex is FeatureNotEnabledException || ex is PermissionException)
                {
                    _settingsService.AllowGpsLocation = false;
                }

                // Unable to get location
                Debug.WriteLine(ex);
            }
        }

        private async Task SendCurrentLocation()
        {
            //var location = new Models.Location.Location
            //{
            //    Latitude = double.Parse(_settingsService.Latitude, CultureInfo.InvariantCulture),
            //    Longitude = double.Parse(_settingsService.Longitude, CultureInfo.InvariantCulture)
            //};

            //await _locationService.UpdateUserLocation(location, _settingsService.AuthAccessToken);
        }
    }
}

