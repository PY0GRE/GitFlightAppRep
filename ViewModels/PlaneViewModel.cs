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
    public partial class PlaneViewModel : ObservableObject
    {
        [ObservableProperty]
        private string model = string.Empty;
        [ObservableProperty]
        private string manufacturer = string.Empty;
        [ObservableProperty]
        private string? imagePath;
        private readonly DataContext dataContext;

        public PlaneViewModel(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        [RelayCommand]
        public async Task SelectImageAsync()
        {
            var fileResult = await MediaPicker.PickPhotoAsync();

            if ( fileResult == null )
                return;

            string? localPath = await ImageHelper.SaveImageLocaclyAsync(fileResult);

            if ( localPath == null )
                return;

            ImagePath = localPath;
        }

        [RelayCommand]
        public async Task SavePlaneAsync()
        {
            if ( string.IsNullOrWhiteSpace(Model) )
            {
                await Shell.Current.DisplayAlert("Validation Error", "Plane model is required.", "OK");
                return;
            }
            if ( string.IsNullOrWhiteSpace(Manufacturer) )
            {
                await Shell.Current.DisplayAlert("Validation Error", "Plane manufacturer is required.", "OK");
                return;
            }

            var plane = new Plane
            {
                Model = this.Model,
                Manufacturer = this.Manufacturer,
                ImagePath = this.ImagePath
            };

            await dataContext.Planes.AddAsync(plane);
            await dataContext.SaveChangesAsync();

            CancellationTokenSource cancellationToken = new();
            var toast = Toast.Make("Plane saved successfully!", ToastDuration.Short, 14);
            await toast.Show(cancellationToken.Token);
        }
    }
}
