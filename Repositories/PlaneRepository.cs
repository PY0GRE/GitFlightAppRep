using Microsoft.EntityFrameworkCore;
using Proyecto1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto1.Repositories
{
    public class PlaneRepository(DataContext dataContext)
    {
        public async Task<List<Plane>> GetAllPlanesAsync()
        {
            return await dataContext.Planes.AsNoTracking().ToListAsync();
        }

        public async Task<Plane?> GetPlaneByIdAsync(int planeId)
        {
            return await dataContext.Planes
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.PlaneId.Equals(planeId));
        }

        public async Task AddPlaneAsync(Plane plane)
        {
            await dataContext.Planes.AddAsync(plane);
            await dataContext.SaveChangesAsync();
        }

        public async Task UpdatePlaneAsync(Plane plane)
        {
            var existingPlane = await dataContext.Planes.FindAsync(plane.PlaneId);

            if ( existingPlane == null )
            {
                //throw new InvalidOperationException($"User with id {user.UserId} does not exist.");

                // Utilizamos un Shell ya que asi esta la estructura del proyecto y segun creo es mejor que usar el throw exception
                await Shell.Current.DisplayAlert("Error", $"The plane {plane.Model} do not exist", "Ok");
                return;
            }

            existingPlane.PlaneId = plane.PlaneId;
            existingPlane.Model = plane.Model;
            existingPlane.Manufacturer = plane.Manufacturer;

            // De momento la version 1 solo utilizaremos el username y ya despues si tengo tiempo arreglo para la imagen jeje

            dataContext.Planes.Add(existingPlane);
            await dataContext.SaveChangesAsync();
        }

        public async Task DeletePlaneAsync(int planeId)
        {
            var plane = await dataContext.Planes.FindAsync(planeId);

            if ( plane == null )
            {
                await Shell.Current.DisplayAlert("Error", $"The plane {plane.Model} do not exist", "Ok");
                return;
            }

            dataContext.Planes.Remove(plane);
            await dataContext.SaveChangesAsync();
        }
    }
}
