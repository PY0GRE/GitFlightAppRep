using Proyecto1.ViewModels;
using System.Threading.Tasks;

namespace Proyecto1.Pages;

public partial class UsersPage : ContentPage
{
    private readonly UserViewModel userViewModel;

    public UsersPage(UserViewModel userViewModel)
	{
		InitializeComponent();
		BindingContext = userViewModel;
		this.userViewModel = userViewModel;
    }

	protected async override void OnAppearing()
	{
		base.OnAppearing();
		await userViewModel.LoadUsersAsync();
    }

    private async void OnAddNewUser(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync($"/{nameof(AddNewUserPage)}");
    }

    //private void OnUserSelected(object sender, SelectionChangedEventArgs e)
    //{
    //    if(this.userViewModel.SelectedUser != null)
    //    {
    //        Shell.Current.GoToAsync($"/{nameof(UserDetailsPage)}");
    //    }
    //}
}