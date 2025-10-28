using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Proyecto1.Helpers;
using Proyecto1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto1.ViewModels
{
    public partial class UserViewModel : ObservableObject
    {
        private readonly DataContext dataContext;
        [ObservableProperty]
        private string userName = String.Empty;
        [ObservableProperty]
        private byte[]? profileImage;
        [ObservableProperty]
        private ImageSource? profileImageSource;

        public UserViewModel(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        [RelayCommand]
        public async Task TakePhoto()
        {
            try
            {
                var profileImage = await ImageHelper.CapturePhotoAsync();
                if ( profileImage != null )
                {
                    ProfileImage = profileImage;
                    ProfileImageSource = ImageHelper.ToImageSource(ProfileImage);

                    CancellationTokenSource cancellationToken = new();

                    var toast = Toast.Make("Photo uploaded successfully!", ToastDuration.Short, 14);

                    await toast.Show(cancellationToken.Token);
                }
            }
            catch ( Exception ex )
            {
                await Shell.Current.DisplayAlert("Error", $"Error capturing photo: {ex.Message}", "OK");
            }
        }

        [RelayCommand]
        public async Task SaveUser()
        {
            if ( string.IsNullOrWhiteSpace(UserName) )
            {
                await Shell.Current.DisplayAlert("Validation Error", "User name is required.", "OK");
                return;
            }
            var user = new User
            {
                UserName = this.UserName,
                ProfileImage = this.ProfileImage
            };
            dataContext.Users.Add(user);
            await dataContext.SaveChangesAsync();
            // Un toast mejor
            //await Shell.Current.DisplayAlert("Success", "User saved successfully!", "OK");
            CancellationTokenSource cancellationToken = new();
            var toast = Toast.Make("User saved successfully!", ToastDuration.Short, 14);
            await toast.Show(cancellationToken.Token);
        }
    }
}
