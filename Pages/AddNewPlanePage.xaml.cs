using Proyecto1.ViewModels;

namespace Proyecto1.Pages;

public partial class AddNewPlanePage : ContentPage
{
	public AddNewPlanePage(PlaneViewModel planeViewModel)
	{
		InitializeComponent();
        BindingContext = planeViewModel;
    }
}