using Proyecto1.ViewModels;

namespace Proyecto1.Pages;

public partial class FlightsPage : ContentPage
{
	public FlightsPage(FlightViewModel flightViewModel)
	{
		InitializeComponent();
        BindingContext = flightViewModel;
    }

    private async void OnAddNewFlight(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync($"/{nameof(AddNewFlight)}");
    }
}