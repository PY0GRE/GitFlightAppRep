namespace Proyecto1.Pages;

public partial class FlightsPage : ContentPage
{
	public FlightsPage()
	{
		InitializeComponent();
	}

    private async void OnAddNewFlight(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync($"/{nameof(AddNewFlight)}");
    }
}