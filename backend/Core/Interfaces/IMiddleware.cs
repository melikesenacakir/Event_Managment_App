using Core.Entities;
using Core.Models;

namespace Core.Interfaces
{
    public interface IMiddlewareService
    {
        string GenerateToken(Users users, Guid userID);
        string _CheckExpired(Guid userID);
        
    }
}