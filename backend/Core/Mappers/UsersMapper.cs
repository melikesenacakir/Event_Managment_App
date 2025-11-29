using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.DTOs;
using Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Core.Mappers
{
    public static class UsersMapper
    {
        public static UsersDTO ToUsersDTO(this Users users){
            return new UsersDTO{
                ID=users.ID,
                Name=users.Name,
                Surname=users.Surname,
                Email=users.Email,
                Username=users.Username,
            };
        }
        public static Users FromUpdateDTO(this UpdateDTO users){
            return new Users{
                Name=users.Name,
                Surname=users.Surname,
                Email=users.Email,
                Password=users.Password,
                Username=users.Username
            };
        }
        public static Users FromLoginDTO(this LoginDTO users){
            return new Users{
                Username=users.Username,
                Password=users.Password
            };
        }
        public static Users FromRegisterDTO(this RegisterDTO users){
            return new Users{
                Name=users.Name,
                Surname=users.Surname,
                Email=users.Email,
                Password=users.Password,
                Username=users.Username
            };
        }
    }
}