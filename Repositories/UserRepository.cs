using Microsoft.EntityFrameworkCore;
using Proyecto1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto1.Repositories
{
    public class UserRepository(DataContext dataContext)
    {
        public async Task<List<User>> GetAllUsersAsync()
        {
            return await dataContext.Users.AsNoTracking().ToListAsync();
        }

        public async Task<User?> GetUserByIdAsync(int userId)
        {
            return await dataContext.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.UserId.Equals(userId));
        }

        public async Task AddUserAsync(User user)
        {
            await dataContext.Users.AddAsync(user);
            await dataContext.SaveChangesAsync();
        }

        public async Task UpdateUserAsync(User user)
        {
            var existingUser = await dataContext.Users.FindAsync(user.UserId);

            if ( existingUser == null )
            {
                //throw new InvalidOperationException($"User with id {user.UserId} does not exist.");
                
                // Utilizamos un Shell ya que asi esta la estructura del proyecto y segun creo es mejor que usar el throw exception
                await Shell.Current.DisplayAlert("Error", $"The user name {user.UserName} do not exist", "Ok");
                return;
            }

            existingUser.UserId = user.UserId;
            existingUser.UserName = user.UserName;

            // De momento la version 1 solo utilizaremos el username y ya despues si tengo tiempo arreglo para la imagen jeje

            dataContext.Users.Add(existingUser);
            await dataContext.SaveChangesAsync();
        }

        public async Task DeleteUserAsync(int userId)
        {
            var user = await dataContext.Users.FindAsync(userId);

            if ( user == null )
            {
                await Shell.Current.DisplayAlert("Error", $"The user name {user.UserName} do not exist", "Ok");
                return;
            }

            dataContext.Users.Remove(user);
            await dataContext.SaveChangesAsync();
        }
    }
}

