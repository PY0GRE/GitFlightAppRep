using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Proyecto1.Helpers;
using Proyecto1.Models;
using Proyecto1.Repositories;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto1.ViewModels
{
    public partial class UserViewModel : ObservableObject
    {
        //private readonly DataContext dataContext;
        private readonly UserRepository userRepository;
        
        [ObservableProperty]
        private string userName = String.Empty;

        [ObservableProperty]
        private byte[]? profileImage;

        [ObservableProperty]
        private ImageSource? profileImageSource;

        // Properties for Collection View
        [ObservableProperty]
        private User? _selectedUser;

        [ObservableProperty]
        private bool _isEnabled = false;

        public ObservableCollection<User> Users { get; set; } = [];

        public UserViewModel(UserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        // Cambiamos el Constructor para que reciba el Repositorio y no el DataContext
        //public UserViewModel(DataContext dataContext)
        //{
        //    this.dataContext = dataContext;
        //}

        public async Task LoadUsersAsync()
        {
            Users.Clear();
            var usersFromDb = await userRepository.GetAllUsersAsync();

            foreach ( var user in usersFromDb )
            {
                // Si tu modelo tiene byte[] ProfileImage
                if ( user.ProfileImage != null && user.ProfileImage.Length > 0 )
                {
                    user.ProfileImageSource = ImageHelper.ToImageSource(user.ProfileImage);
                }

                Users.Add(user);
            }
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

            //dataContext.Users.Add(user);
            //await dataContext.SaveChangesAsync();
            await userRepository.AddUserAsync(user);

            // Un toast mejor
            //await Shell.Current.DisplayAlert("Success", "User saved successfully!", "OK");
            //CancellationTokenSource cancellationToken = new();
            //var toast = Toast.Make("User saved successfully!", ToastDuration.Short, 14);
            //await toast.Show(cancellationToken.Token);
            await ToastHelper.GetToastAsync("User saved succesfully!", ToastDuration.Short, 14);

            await Shell.Current.GoToAsync("..");
        }

        // Los metodos de update y delete quedan pendientes
    }
}
