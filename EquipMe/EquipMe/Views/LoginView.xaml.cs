using EquipMe.ViewModels;

namespace EquipMe.Views;

public partial class LoginView : ContentPage
{
	public LoginView(LoginViewModel viewModel)
	{
		BindingContext = viewModel;
		InitializeComponent();
	}
}
