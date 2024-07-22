using EquipMe.ViewModels;

namespace EquipMe.Views;

public partial class RoundDetailsView : ContentPageBase
{
	public RoundDetailsView(RoundDetailsViewModel viewModel)
	{
		BindingContext = viewModel;
		InitializeComponent();
	}
}
