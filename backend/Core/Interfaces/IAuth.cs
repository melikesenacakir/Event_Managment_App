using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Models;

namespace Core.Interfaces
{
    public interface IAuthService
    {
        Task<ServiceResponse<Users>> LoginAsync(Users user);
        Task<ServiceResponse<Users>> RegisterAsync(Users user);
        
    }
}