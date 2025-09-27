using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Proyecto1.Models;
using Proyecto1.Repositories;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Proyecto1.ViewModels
{
    //public class FlightViewModel : INotifyPropertyChanged
    //{
    //    public event PropertyChangedEventHandler? PropertyChanged;

    //    private string _flightNumber = string.Empty;
    //    private string _price = string.Empty;
    //    private DateTime _departureDate = DateTime.Now;

    //    public string FlightNumber { get => _flightNumber; 
    //        set
    //        {
    //            if ( _flightNumber != value )
    //            {
    //                _flightNumber = value;
    //                OnPropertyChanged(nameof(FlightNumber));
    //            }
    //        }
    //    }

    //    public string Price { get => _price;
    //            set
    //            {
    //            if ( _price != value )
    //            {
    //                _price = value;
    //                OnPropertyChanged(nameof(Price));
    //            }
    //        }
    //    }

    //    public DateTime DepartureDate { get => _departureDate;
    //        set
    //        {
    //            if ( _departureDate != value )
    //            {
    //                _departureDate = value;
    //                OnPropertyChanged(nameof(DepartureDate));
    //            }
    //        }
    //    }

    //    public ICommand AddNewFlightCommand { get; }

    //    /// <summary>
    //    /// View Model Constructor
    //    /// </summary>
    //    public FlightViewModel()
    //    {
    //        AddNewFlightCommand = new Command(OnAddNewFlight);
    //    }

    //    /// <summary>
    //    /// Commando to Add new Flight to the Global list
    //    /// </summary>
    //    /// <param name="obj"></param>
    //    private async void OnAddNewFlight(object obj)
    //    {
    //        if ( string.IsNullOrWhiteSpace(FlightNumber) || string.IsNullOrEmpty(Price) )
    //        {
    //            await Shell.Current.DisplayAlert("Error", "The flight info is not complete", "Ok");
    //            return;
    //        }

    //        if ( GlobalData.Flights.FirstOrDefault(f => f.FlightNumber.Equals(FlightNumber)) != null )
    //        {
    //            await Shell.Current.DisplayAlert("Error", $"Flight Number {FlightNumber} alreaddy exists", "Ok");
    //            return;
    //        }

    //        Flight flight = new()
    //        {
    //            FlightNumber = FlightNumber.Trim(),
    //            DepartureDate = DepartureDate.Date,
    //            Price = decimal.Parse(Price)
    //        };

    //        GlobalData.Flights.Add(flight);
    //        await Shell.Current.DisplayAlert("Success", $"New flight added successfully", "Ok");
    //        await Shell.Current.GoToAsync("..");
    //    }

    //    /// <summary>
    //    /// Method that triggers the PropertyChanged event
    //    /// </summary>
    //    /// <param name="propertyName">Property which its value was changed</param>
    //    protected void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));


    //}

    public partial class FlightViewModel : ObservableObject
    {
        private readonly FlightRepositorie flightRepositorie;

        // Ctrl - k - u to uncomment
        [ObservableProperty]
        private string _flightNumber = string.Empty;

        [ObservableProperty]
        private string _price = string.Empty;

        [ObservableProperty]
        private DateTime _departureDate = DateTime.Now;

        public FlightViewModel(FlightRepositorie flightRepositorie)
        {
            this.flightRepositorie = flightRepositorie;
        }

        public ObservableCollection<Flight> flights { get; set; } = [];

        [RelayCommand]
        public async Task AddNewFlight()
        {
            if ( string.IsNullOrWhiteSpace(FlightNumber) || string.IsNullOrEmpty(Price) )
            {
                await Shell.Current.DisplayAlert("Error", "The flight info is not complete", "Ok");
                return;
            }

            if ( GlobalData.Flights.FirstOrDefault(f => f.FlightNumber.Equals(FlightNumber)) != null )
            {
                await Shell.Current.DisplayAlert("Error", $"Flight Number {FlightNumber} alreaddy exists", "Ok");
                return;
            }

            Flight flight = new()
            {
                FlightNumber = FlightNumber.Trim(),
                DepartureDate = DepartureDate.Date,
                Price = decimal.Parse(Price)
            };

            GlobalData.Flights.Add(flight);
            await Shell.Current.DisplayAlert("Success", $"New flight added successfully", "Ok");
            await Shell.Current.GoToAsync("..");
        } 
    }
}
