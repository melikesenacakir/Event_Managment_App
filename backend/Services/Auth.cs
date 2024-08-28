using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Interfaces;

namespace backend.Services
{
    public class AuthServices: IAuthService
    {
        private readonly IUsersRepository _authRepo;
         ServiceResponse<Models.Users> _response = new();
        public AuthServices(IUsersRepository authRepo)
        {
            _authRepo = authRepo;
        }

         public async Task<ServiceResponse<Models.Users>> LoginAsync(Models.Users user)
        {
           var userData= await _authRepo.FilterUser(user.Username);
           if (userData==null)
           {
               return await Task.FromResult(new ServiceResponse<Models.Users>(){
                   Success=false,
                   Data=null,
                   Message="username or password does not match",
               });
           }
           var result = BCrypt.Net.BCrypt.Verify(user.Password,userData?.Password);
              if (result.Equals(false))
              {
                    return await Task.FromResult(new ServiceResponse<Models.Users>()
                    {
                        Success = false,
                        Data = null,
                        Message = "username or password does not match"
                    });
              };

              return await Task.FromResult(new ServiceResponse<Models.Users>(){
                Success = true,
                Data=null,
                Message="Login Successful",
              });
        }

        public async Task<ServiceResponse<Models.Users>> RegisterAsync(Models.Users user)
        {
            user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);
            var result = await _authRepo.Register(user);
            if (result==null){
                return await Task.FromResult(new ServiceResponse<Models.Users>(){
                    Success=false,
                    Data=null,
                    Message="username already exists",
                });
            }
            return await Task.FromResult(new ServiceResponse<Models.Users>(){
                Success=true,
                Data=result,
                Message="User registered successfully",
            });
        }
    }
}