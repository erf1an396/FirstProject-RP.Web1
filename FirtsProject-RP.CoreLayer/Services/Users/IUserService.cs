
using FirstProject_RP.CoreLayer.Utilities;
using FirstProject_RP.DataLayer.Entities;
using FirtsProject_RP.CoreLayer.DTOs.Users;

namespace FirtsProject_RP.CoreLayer.Services.Users;

public interface IUserService
{
    OperationResult RegisterUser (UserRegisterDto userRegister);
    UserDto LoginUser(UserLoginDto userLogin);


    //Task<OperationResult> LoginUser1(UserLoginDto userLoginDto);
}