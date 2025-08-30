using Proyecto1.Models;

namespace Proyecto1.Pages;

[QueryProperty("SelectedConnection", "SelectedConnection")]
public partial class FlightsConnectionDetailsPage : ContentPage
{
	private FlightConnection _selectedConnection;

    public FlightConnection SelectedConnection { get => _selectedConnection; set
		{
            _selectedConnection = value;
            if ( _selectedConnection != null )
            {
                connectionsCollectionView.ItemsSource = _selectedConnection.Flights;
            }
        }
	}

    public FlightsConnectionDetailsPage()
	{
		InitializeComponent();
	}
}