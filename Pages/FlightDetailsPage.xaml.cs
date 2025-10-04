using Proyecto1.ViewModels;

namespace Proyecto1.Pages;

public partial class FlightDetailsPage : ContentPage
{
    private readonly FlightViewModel flightViewModel;

    public FlightDetailsPage(FlightViewModel flightViewModel)
	{
		InitializeComponent();
        BindingContext = flightViewModel;
		this.flightViewModel = flightViewModel;
    }

    protected override bool OnBackButtonPressed()
    {
        flightViewModel.IsEnabled = false;
        mainOptions.IsVisible = true;
        editOptions.IsVisible = false;

        flightViewModel.SelectedFlight = null;

        return base.OnBackButtonPressed();
    }

    private void onEditClicked(object sender, EventArgs e)
    {
        flightViewModel.IsEnabled = true;
        mainOptions.IsVisible = false;
        editOptions.IsVisible = true;
    }

    private void onCancelClicked(object sender, EventArgs e)
    {
        editOptions.IsVisible = false;
        mainOptions.IsVisible = true;
        flightViewModel.IsEnabled = false;
    }
}