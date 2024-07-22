using EquipMe.ViewModels;

namespace EquipMe.Views;

public partial class HomeView : ContentPageBase
{
	public HomeView(HomeViewModel viewModel)
	{
		BindingContext = viewModel;
		InitializeComponent();
	}
}
