using EquipMe.Services.Navigation;
using EquipMe.Views;

namespace EquipMe
{
    public partial class AppShell : Shell
    {
        INavigationService _navigationService;
        public AppShell(INavigationService navigationService)
        {
            _navigationService = navigationService;
            AppShell.InitializeRouting();
            InitializeComponent();
        }

        protected override async void OnHandlerChanged()
        {
            base.OnHandlerChanged();

            if (Handler is not null)
            {
                await _navigationService.InitializeAsync();
            }
        }

        private static void InitializeRouting()
        {
            //Routing.RegisterRoute("//Home", typeof(HomeView));
            Routing.RegisterRoute("Details", typeof(DetailsView));
            Routing.RegisterRoute("Rounds", typeof(RoundsView));
            Routing.RegisterRoute("RoundDetails", typeof(RoundDetailsView));

        }
    }
}

