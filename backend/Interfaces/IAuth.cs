using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Services;

namespace backend.Interfaces
{
    public interface IAuthService
    {
        Task<ServiceResponse<Models.Users>> LoginAsync(Models.Users user);
        Task<ServiceResponse<Models.Users>> RegisterAsync(Models.Users user);
        
    }
}