using Proyecto1.ViewModels;
using System.Threading.Tasks;

namespace Proyecto1.Pages;

public partial class PlanesPage : ContentPage
{
    private readonly PlaneViewModel planeViewModel;

    public PlanesPage(PlaneViewModel planeViewModel)
	{
		InitializeComponent();
        BindingContext = planeViewModel;
        this.planeViewModel = planeViewModel;
    }
    protected async override void OnAppearing()
    {
        base.OnAppearing();
        await planeViewModel.LoadPlanesAsync();
    }


    private async void OnAddNewPlane(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync($"/{nameof(AddNewPlanePage)}");
    }
    //private void OnUserSelected(object sender, SelectionChangedEventArgs e)
    //{

    //}
}