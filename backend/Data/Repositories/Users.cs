using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Database;
using backend.DTOs;
using backend.Interfaces;
using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        private readonly ApplicationDB _db;
        
        public UsersRepository(ApplicationDB db)
        {
            _db = db;
        }
        public async Task<Users?> GetUser(Guid id)
        {
            return await _db.Users.FindAsync(id);
        }

        public async Task<List<Users>> GetUsers()
        {
            return await _db.Users.ToListAsync();
        }

        public async Task<Users?> Login(Users user)
        {
            return await _db.Users.FirstOrDefaultAsync(x => x.Username == user.Username && x.Password == user.Password);
        }

        public async Task<Users?> FilterUser(string username)
        {
            return await _db.Users.FirstOrDefaultAsync(x => x.Username == username);
        }

        public async Task<Users?> Register(Users user)
        {
           var register= await _db.Users.FirstOrDefaultAsync(x =>x.Username == user.Username);
             if (register == null)
            {
                 _db.Users.Add(user);
                 await _db.SaveChangesAsync();
                 return user;
            }
           
            return null;
        }

        public async Task<List<Users>?> UpdateUser(Guid id, Users update)
        {
            var user = await _db.Users.FindAsync(id);
            if (user == null)
            {
                return null;
            }
            if (update.Username!="")
            {
                var check = await _db.Users.FirstOrDefaultAsync(x => x.Username == update.Username && x.ID != id);
                if (check != null)
                {
                    return null;
                }
                user.Username = update.Username;
            }
            if (update.Password!="")
            {
                user.Password = update.Password;
            }
            if (update.Email!="")
            {
                user.Email = update.Email;
            }
            if (update.Name!="")
            {
                user.Name = update.Name;
            }
            if (update.Surname!="")
            {
                user.Surname = update.Surname;
            }
            _db.Users.Update(user);
            await _db.SaveChangesAsync();
            return await _db.Users.ToListAsync();
        }
    }
}