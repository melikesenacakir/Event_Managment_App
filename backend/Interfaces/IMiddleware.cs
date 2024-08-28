using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Interfaces
{
    public interface IMiddlewareService
    {
        string GenerateToken(Models.Users users, Guid userID);
        string _CheckExpired(Guid userID);
        
    }
}