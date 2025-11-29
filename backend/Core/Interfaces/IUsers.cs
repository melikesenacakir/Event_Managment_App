using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Models;

namespace Core.Interfaces
{
    public interface IUsersRepository
    {
        Task<Users?> Login(Users user);
        Task<Users?> Register(Users user);
        Task<List<Users>> GetUsers();
        Task<Users?> GetUser(Guid id);
        Task<List<Users>?> UpdateUser(Guid id, Users update);
        Task<Users?> FilterUser(string username);
    }

    public interface IUsersService{
        Task<ServiceResponse<List<Users>>> GetUsersAsync();
        Task<ServiceResponse<Users>> GetUserAsync(Guid id);
        Task<ServiceResponse<Users?>?> UpdateUserAsync(Guid id, Users update,string confirmPassword); //burası değişecek id jwt veya sessiondan gelicek

    }
}