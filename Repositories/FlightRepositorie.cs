using Microsoft.EntityFrameworkCore;
using Proyecto1.Models;
using Proyecto1.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Separa logica de control de datos con el de negocio, aqui se maneja todo lo relacionado con la base de datos
namespace Proyecto1.Repositories
{
    public class FlightRepositorie(DataContext dataContext)
    {
        /// <summary>
        /// Get all the flights in the database
        /// </summary>
        /// <returns>List of the Flights</returns>
        public async Task<List<Flight>> GetAllFlightsAsync()
        {
            return await dataContext.Flights.AsNoTracking().ToListAsync();
        }

        /// <summary>
        /// Get a flight by its id (flight number)
        /// </summary>
        /// <param name="flightNumber"></param>
        /// <returns></returns>
        public async Task<Flight?> GetFlightByIdAsync(string flightNumber)
        {
            return await dataContext.Flights
                .AsNoTracking()
                .FirstOrDefaultAsync(f => f.FlightNumber.Equals(flightNumber));
        }

        /// <summary>
        /// Add a new flight to the database
        /// </summary>
        /// <param name="flight"></param>
        /// <returns></returns>
        public async Task AddFlightAsync(Flight flight)
        {
            await dataContext.Flights.AddAsync(flight); // De igual manera, mas compleja, muchos datos recomendable async
            await dataContext.SaveChangesAsync();
        }

        /// <summary>
        /// Update an existing flight in the database
        /// </summary>
        /// <param name="flight"></param>
        /// <returns></returns>
        public async Task UpdateFlightAsync(Flight flight)
        {
            // Modificando para despues guardarlo
            var existingFlight = await dataContext.Flights.FindAsync(flight.FlightNumber);
            if ( existingFlight == null )
            {
                throw new InvalidOperationException($"Flight with number {flight.FlightNumber} does not exist.");
            }
            existingFlight.FlightNumber = flight.FlightNumber;
            existingFlight.DepartureDate = flight.DepartureDate;
            existingFlight.Price = flight.Price;

            dataContext.Flights.Update(existingFlight);
            await dataContext.SaveChangesAsync();
        }

        /// <summary>
        /// Delete a flight from the database by its id (flight number)
        /// </summary>
        /// <param name="flightNumber"></param>
        /// <returns></returns>
        public async Task DeleteFlightAsync(string flightNumber)
        {
            var flight = await dataContext.Flights.FindAsync(flightNumber);
            if ( flight != null )
            {
                dataContext.Flights.Remove(flight);
                await dataContext.SaveChangesAsync();
            }
            //dataContext.Flights.Remove(flight);
            //await dataContext.SaveChangesAsync();
        }

        public async Task<List<FlightOutputDTO>> ExportFlightInfoAsync()
        {
            return await dataContext.Flights
            .AsNoTracking()
            .Select(f => new FlightOutputDTO
            {
                FlightNumber = f.FlightNumber,
                DepartureDate = f.DepartureDate,
                Price = f.Price
             })
            .ToListAsync();
        }
    }
}
