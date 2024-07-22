using EquipMe.ViewModels;

namespace EquipMe.Views;

public partial class RoundsView : ContentPageBase
{
	public RoundsView(RoundsViewModel viewModel)
	{
		BindingContext = viewModel;
		InitializeComponent();
	}
}
