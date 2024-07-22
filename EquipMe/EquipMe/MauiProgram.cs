using CommunityToolkit.Maui;
using EquipMe.Services.Data;
using EquipMe.Services.Date;
using EquipMe.Services.Dialog;
using EquipMe.Services.Location;
using EquipMe.Services.Navigation;
using EquipMe.Services.OpenUrl;
using EquipMe.Services.RequestProvider;
using EquipMe.Services.Settings;
using EquipMe.ViewModels;
using EquipMe.Views;
using Microsoft.Extensions.Logging;
using Microsoft.Maui.Controls.Hosting;


namespace EquipMe
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                    fonts.AddFont("Mulish-Black.ttf", "Mulish_Black");
                    fonts.AddFont("Mulish-Bold.ttf", "Mulish_Bold");
                    fonts.AddFont("Mulish-ExtraBold.ttf", "Mulish_ExtraBold");
                    fonts.AddFont("Mulish-ExtraLight.ttf", "Mulish_ExtraLight");
                    fonts.AddFont("Mulish-Light.ttf", "Mulish_Light");
                    fonts.AddFont("Mulish-Medium.ttf", "Mulish_Medium");
                    fonts.AddFont("Mulish-Regular.ttf", "Mulish_Regular");
                    fonts.AddFont("Mulish-SemiBold.ttf", "Mulish_SemiBold");
                    fonts.AddFont("FontAwesome-Regular.ttf", "FontAwesome_Regular");
                    fonts.AddFont("FontAwesome-Solid.ttf", "FontAwesome_Solid");

                })
                .ConfigureEssentials()
                //.UseMauiMaps() // Add this line to enable Maui Maps
                .RegisterAppServices()
                .RegisterViewModels()
                .RegisterViews();


            return builder.Build();
        }
        public static MauiAppBuilder RegisterAppServices(this MauiAppBuilder mauiAppBuilder)
        {
            mauiAppBuilder.Services.AddSingleton<ILoggerFactory, LoggerFactory>();
            mauiAppBuilder.Services.AddSingleton<INavigationService, NavigationService>();
            mauiAppBuilder.Services.AddSingleton<IDataService, MockDataService>();
            mauiAppBuilder.Services.AddSingleton<ISettingsService, SettingsService>();
            mauiAppBuilder.Services.AddSingleton<IDialogService, DialogService>();
            mauiAppBuilder.Services.AddSingleton<IOpenUrlService, OpenUrlService>();
            mauiAppBuilder.Services.AddSingleton<IRequestProviderService, RequestProviderService>();
            mauiAppBuilder.Services.AddSingleton<IDateService, DateService>();
            mauiAppBuilder.Services.AddSingleton<IGeoLocation, GeoLocation>();

            return mauiAppBuilder;
        }
        public static MauiAppBuilder RegisterViewModels(this MauiAppBuilder mauiAppBuilder)
        {
            mauiAppBuilder.Services.AddTransient<LoginViewModel>();
            mauiAppBuilder.Services.AddTransient<HomeViewModel>();
            mauiAppBuilder.Services.AddTransient<DetailsViewModel>();
            mauiAppBuilder.Services.AddTransient<RoundsViewModel>();
            mauiAppBuilder.Services.AddTransient<RoundDetailsViewModel>();

            return mauiAppBuilder;
        }
        public static MauiAppBuilder RegisterViews(this MauiAppBuilder mauiAppBuilder)
        {
            mauiAppBuilder.Services.AddTransient<LoginView>();
            mauiAppBuilder.Services.AddTransient<HomeView>();
            mauiAppBuilder.Services.AddTransient<DetailsView>();
            mauiAppBuilder.Services.AddTransient<RoundsView>();
            mauiAppBuilder.Services.AddTransient<RoundDetailsView>();
            return mauiAppBuilder;
        }
    }
}
