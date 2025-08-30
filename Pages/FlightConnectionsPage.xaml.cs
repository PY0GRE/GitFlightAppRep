using Proyecto1.Models;

namespace Proyecto1.Pages;

public partial class FlightConnectionsPage : ContentPage
{
	public FlightConnectionsPage()
	{
		InitializeComponent();
	}

    private async void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
		if ( e.CurrentSelection.FirstOrDefault() is not FlightConnection selectedConnection )
			return;

		var navParams = new Dictionary<string, object>()
		{
			{ "SelectedConnection", selectedConnection   }
		};

		await Shell.Current.GoToAsync($"/{nameof(FlightsConnectionDetailsPage)}", navParams);
    }
}