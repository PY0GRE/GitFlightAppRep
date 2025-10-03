using Proyecto1.ViewModels;
using System.Threading.Tasks;

namespace Proyecto1.Pages;

public partial class FlightsPage : ContentPage
{
    private readonly FlightViewModel flightViewModel;

    public FlightsPage(FlightViewModel flightViewModel)
	{
		InitializeComponent();
        BindingContext = flightViewModel;
        this.flightViewModel = flightViewModel;
    }

    protected async override void OnAppearing()
    {
        base.OnAppearing();
        await flightViewModel.LoadFlightsAsync();
    }

    private async void OnAddNewFlight(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync($"/{nameof(AddNewFlight)}");
    }

    private async void OnFlightSelected(object sender, SelectionChangedEventArgs e)
    {
        if (this.flightViewModel.SelectedFlight != null )
        {
            await Shell.Current.GoToAsync($"/{nameof(FlightDetailsPage)}");
        }
    }
}