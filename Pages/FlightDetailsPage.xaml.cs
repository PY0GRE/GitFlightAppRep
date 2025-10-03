using Proyecto1.ViewModels;

namespace Proyecto1.Pages;

public partial class FlightDetailsPage : ContentPage
{
	public FlightDetailsPage(FlightViewModel flightViewModel)
	{
		InitializeComponent();
        BindingContext = flightViewModel;
    }
}