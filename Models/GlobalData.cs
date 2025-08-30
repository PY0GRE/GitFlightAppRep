using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto1.Models
{
    public class GlobalData
    {
        private static ObservableCollection<Flight> flights = [
            new Flight()
            {
                FlightNumber = "LH123",
                Price = 900,
                DepartureDate = DateTime.Now,
            },
            new()
            {
                FlightNumber = "LH456",
                 Price = 670,
                DepartureDate = DateTime.Now,
            },
            new ()
            {
                FlightNumber = "LH676",
                 Price = 400,
                DepartureDate = DateTime.Now,
            }
            ];
        private static ObservableCollection<FlightConnection> flightConnections = [
            new()
            {
                Airline = "Iberia",
                DepartureCity = "Chicago",
                ConnectionId = "A14",
                ArrivalCity = "New York",
                Flights = []

            }
            ];
        public static ObservableCollection<Flight> Flights { get => flights; set => flights = value; }
        public static ObservableCollection<FlightConnection> FlightConnections { get => flightConnections; set => flightConnections = value; }
    }
}
