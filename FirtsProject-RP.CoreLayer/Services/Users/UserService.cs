using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure;
using CodeYad_Blog.CoreLayer.Utilities;
using FirstProject_RP.DataLayer.Context;
using FirstProject_RP.DataLayer.Entities;
using FirtsProject_RP.CoreLayer.DTOs.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace FirtsProject_RP.CoreLayer.Services.Users
{
    public class UserService : IUserService
    {
        private readonly BlogContext _blogContext;

        public UserService(BlogContext blogContext)
        {
            _blogContext = blogContext;
        }


        public OperationResult RegisterUser(UserRegisterDto userRegisterDto)
        {
            

            var isUserNameExist = _blogContext.Users.Any(u => u.UserName == userRegisterDto.UserName);
            if (isUserNameExist)
               return OperationResult.Error("نام کاربری تکراری است ");
                


            var passwordHash = userRegisterDto.Password.EncodeToMd5();
            _blogContext.Users.Add(new User()
            {
                FullName = userRegisterDto.FullName,
                UserName = userRegisterDto.UserName,
                IsDeleted = false,
                CreationDate = DateTime.Now,
                Role = User.UserRole.User,
                Password = passwordHash


            });
            _blogContext.SaveChanges();
            return OperationResult.Success();
        }

        public UserDto LoginUser(UserLoginDto userLoginDto)
        {
            var PasswordHash = userLoginDto.Password.EncodeToMd5();
            var User = _blogContext.Users.FirstOrDefault(u => u.UserName == userLoginDto.UserName && u.Password == PasswordHash);

            if(User == null)
                return null;

            var UserDto = new UserDto()
            {
                FullName = User.FullName,
                UserName = User.UserName,
                Password = User.Password,
                Role = User.Role, 
                CreationDate = User.CreationDate,
                Id = User.Id 
            };
            return UserDto;

            
        }



        //public async Task<OperationResult> LoginUser1(UserLoginDto userLoginDto)
        //{
        //    var PasswordHash = userLoginDto.Password.EncodeToMd5();
        //    var isUserExist = await _blogContext.Users.AnyAsync(u => u.UserName == userLoginDto.UserName && u.Password == PasswordHash);
        //    if (!isUserExist)
        //        return OperationResult.NotFound();

        //    return OperationResult.Success();
        //}
    }
}
