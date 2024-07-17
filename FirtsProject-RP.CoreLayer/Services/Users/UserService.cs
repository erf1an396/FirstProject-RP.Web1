using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeYad_Blog.CoreLayer.Utilities;
using FirstProject_RP.DataLayer.Context;
using FirstProject_RP.DataLayer.Entities;
using FirtsProject_RP.CoreLayer.DTOs.Users;
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
            var isFullNameExist = _blogContext.Users.Any(u => u.UserName == userRegisterDto.UserName);
            if (isFullNameExist)
                OperationResult.Error("نام کاربری تکراری است ");
            

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
    }
}
