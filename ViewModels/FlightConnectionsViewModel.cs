using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Proyecto1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto1.ViewModels
{
    public partial class FlightConnectionsViewModel : ObservableObject
    {
        [ObservableProperty]
        private string _connectionId = string.Empty;

        [ObservableProperty]
        private string _airline = string.Empty;

        [ObservableProperty]
        private string _departureCity = string.Empty;

        [ObservableProperty]
        private string _arrivalCity = string.Empty;

        [ObservableProperty]
        private List<Flight> _flights = new();

        [RelayCommand]
        public async Task AddNewConnectionFlight()
        {
            if (string.IsNullOrWhiteSpace(ConnectionId) || string.IsNullOrWhiteSpace(Airline) || string.IsNullOrWhiteSpace(DepartureCity) || string.IsNullOrWhiteSpace(ArrivalCity) )
            {
                await Shell.Current.DisplayAlert("Error", "The connection info is not complete", "Ok");
                return;
            }

            if ( GlobalData.FlightConnections.FirstOrDefault(c => c.ConnectionId.Equals(ConnectionId)) != null )
            {
                await Shell.Current.DisplayAlert("Error", $"Connection ID {ConnectionId} alreaddy exists", "Ok");
                return;
            }

            if (DepartureCity == ArrivalCity)
            {
                await Shell.Current.DisplayAlert("Error", "The departure city cannot be the same as the arrival city", "Ok");
                return;
            }

            FlightConnection conFlight = new()
            {
                ConnectionId = ConnectionId.Trim(),
                Airline = Airline.Trim(),
                DepartureCity = DepartureCity.Trim(),
                ArrivalCity = ArrivalCity.Trim()
            };

            GlobalData.FlightConnections.Add(conFlight);
            await Shell.Current.DisplayAlert("Success", $"New flight connection added successfully", "Ok");
            await Shell.Current.GoToAsync("..");
        }
    }
}
