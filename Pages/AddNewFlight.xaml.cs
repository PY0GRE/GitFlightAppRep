using Proyecto1.Models;
using Proyecto1.ViewModels;
using System.Threading.Tasks;

namespace Proyecto1.Pages;

public partial class AddNewFlight : ContentPage
{
	public AddNewFlight(FlightViewModel flightViewModel)
	{
		InitializeComponent();
        BindingContext = flightViewModel;
    }

    // Ctrl - k - c to comment
    //private async void OnAddNewFlight(object sender, EventArgs e)
    //{
    //    if ( string.IsNullOrWhiteSpace(FlightNumberEntry.Text) || string.IsNullOrEmpty(PriceEntry.Text) )
    //    {
    //        await DisplayAlert("Error", "The flight info is not complete", "Ok");
    //        return;
    //    }

    //    if (GlobalData.Flights.FirstOrDefault(f => f.FlightNumber.Equals(FlightNumberEntry.Text)) != null)
    //    {
    //        await DisplayAlert("Error", $"Flight Number {FlightNumberEntry.Text} alreaddy exists", "Ok");
    //        return;
    //    }

    //    Flight flight = new()
    //    {
    //        FlightNumber = FlightNumberEntry.Text.Trim(),
    //        DepartureDate = DepartureDatePicker.Date,
    //        Price = decimal.Parse(PriceEntry.Text)
    //    };

    //    GlobalData.Flights.Add(flight);
    //    await DisplayAlert("Success", $"New flight added successfully", "Ok");
    //    await Shell.Current.GoToAsync("..");
    //}
}