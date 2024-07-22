using System;
using EquipMe.Services.Settings;

namespace EquipMe.Services.Location
{
    public class GeoLocation : IGeoLocation
	{
        ISettingsService _settingsService;


        public GeoLocation(ISettingsService settingsService)
		{
            _settingsService = settingsService;
		}

        public async Task GetGpsLocation()
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
               

            }
        }
    }
}

