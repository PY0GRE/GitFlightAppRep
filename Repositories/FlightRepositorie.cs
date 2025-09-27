using Microsoft.EntityFrameworkCore;
using Proyecto1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            dataContext.Flights.Update(flight);
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
    }
}
