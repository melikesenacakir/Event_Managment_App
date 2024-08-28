using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Controllers;
using backend.DTOs;
using backend.Services;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace backend.Interfaces
{
    public interface IUsersRepository
    {
        Task<Models.Users?> Login(Models.Users user);
        Task<Models.Users?> Register(Models.Users user);
        Task<List<Models.Users>> GetUsers();
        Task<Models.Users?> GetUser(Guid id);
        Task<List<Models.Users>?> UpdateUser(Guid id, Models.Users update);
        Task<Models.Users?> FilterUser(string username);
    }

    public interface IUsersService{
        Task<ServiceResponse<List<Models.Users>>> GetUsersAsync();
        Task<ServiceResponse<Models.Users>> GetUserAsync(Guid id);
        Task<ServiceResponse<Models.Users?>?> UpdateUserAsync(Guid id, Models.Users update,string confirmPassword); //burası değişecek id jwt veya sessiondan gelicek

    }
}