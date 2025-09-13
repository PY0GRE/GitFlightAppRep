using Proyecto1.ViewModels;

namespace Proyecto1.Pages;

public partial class AddNewFlightConnection : ContentPage
{
	public AddNewFlightConnection()
	{
		InitializeComponent();
		BindingContext = new FlightConnectionsViewModel();
    }
}