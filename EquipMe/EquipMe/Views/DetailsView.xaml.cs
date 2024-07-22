using EquipMe.ViewModels;

namespace EquipMe.Views;

public  partial class DetailsView : ContentPageBase
{
	public DetailsView(DetailsViewModel viewModel)
	{
        BindingContext = viewModel;
		InitializeComponent();
	}
}

