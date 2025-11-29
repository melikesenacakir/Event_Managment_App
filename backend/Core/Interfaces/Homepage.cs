using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Models;

namespace Core.Interfaces
{
    public interface IHomepageRepository
    {
        Task<List<Events>?> GetHomepage();
    }
    public interface IHomepageService
    {
        Task<ServiceResponse<List<Events>>> GetHomepage();
    }
}