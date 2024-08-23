using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Controllers;
using backend.DTOs;

namespace backend.Mappers
{
    public static class UsersMapper
    {
        public static UsersDTO ToUsersDTO(this Models.Users users){
            return new UsersDTO{
                ID=users.ID,
                Name=users.Name,
                Surname=users.Surname,
                Role=users.Role,
                Email=users.Email,
                Password=users.Password,
                Username=users.Username
            };
        }
    }
}