using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.DTOs;
using backend.Interfaces;

namespace backend.Services
{
    public class UserServices: IUsersService
    {
        private readonly IUsersRepository _usersRepo;
        public UserServices(IUsersRepository usersRepo)
        {
            _usersRepo = usersRepo;
        }

        public async Task<ServiceResponse<Models.Users>> GetUserAsync(Guid id)
        {
            var user = await _usersRepo.GetUser(id);
            if (user == null)
            {
                return await Task.FromResult(new ServiceResponse<Models.Users>()
                {
                    Success = false,
                    Data = null,
                    Message = "User not found"
                });
            }
            return await Task.FromResult(new ServiceResponse<Models.Users>()
            {
                Success = true,
                Data = user,
                Message = "User found"
            });
        }

        public async Task<ServiceResponse<List<Models.Users>>> GetUsersAsync()
        {
            var users = await _usersRepo.GetUsers();
            if (users == null)
            {
                return await Task.FromResult(new ServiceResponse<List<Models.Users>>()
                {
                    Success = false,
                    Data = null,
                    Message = "No users found"
                });
            }
            return await Task.FromResult(new ServiceResponse<List<Models.Users>>()
            {
                Success = true,
                Data = users,
                Message = "Users found"
            });
        }


        public async Task<ServiceResponse<Models.Users?>?> UpdateUserAsync(Guid id, Models.Users update,string confirmPassword)
        {
           var user = await _usersRepo.UpdateUser(id,update);
           if (user==null || confirmPassword==null){
            return await Task.FromResult(new ServiceResponse<Models.Users?>(){
                Success=false,
                Data=null,
                Message="invalid user",
            });
           }
           if (confirmPassword!=""){
                if (update.Password!=confirmPassword){
                    return await Task.FromResult(new ServiceResponse<Models.Users?>(){
                        Success=false,
                        Data=null,
                        Message="passwords do not match",
                    });
                }
                update.Password = BCrypt.Net.BCrypt.HashPassword(update.Password);
           }
           
           return await Task.FromResult(new ServiceResponse<Models.Users?>(){
               Success=true,
               Data=null,
               Message="User updated successfully",
           });
        }
    }
}