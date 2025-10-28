using Proyecto1.ViewModels;

namespace Proyecto1.Pages;

public partial class AddNewUserPage : ContentPage
{
	public AddNewUserPage(UserViewModel userViewModel)
	{
		InitializeComponent();
        BindingContext = userViewModel;
    }
}