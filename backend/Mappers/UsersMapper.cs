using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Controllers;
using backend.DTOs;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace backend.Mappers
{
    public static class UsersMapper
    {
        public static UsersDTO ToUsersDTO(this Models.Users users){
            return new UsersDTO{
                ID=users.ID,
                Name=users.Name,
                Surname=users.Surname,
                Email=users.Email,
                Username=users.Username,
            };
        }
        public static Models.Users FromUpdateDTO(this UpdateDTO users){
            return new Models.Users{
                Name=users.Name,
                Surname=users.Surname,
                Email=users.Email,
                Password=users.Password,
                Username=users.Username
            };
        }
        public static Models.Users FromLoginDTO(this LoginDTO users){
            return new Models.Users{
                Username=users.Username,
                Password=users.Password
            };
        }
        public static Models.Users FromRegisterDTO(this RegisterDTO users){
            return new Models.Users{
                Name=users.Name,
                Surname=users.Surname,
                Email=users.Email,
                Password=users.Password,
                Username=users.Username
            };
        }
    }
}