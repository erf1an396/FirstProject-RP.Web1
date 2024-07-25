using FirstProject_RP.CoreLayer.Utilities;
using FirtsProject_RP.CoreLayer.DTOs.Users;
using FirtsProject_RP.CoreLayer.Services.Users;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using FirstProject_RP.WebMVC.Models;

namespace FirstProject_RP.WebMVC.Controllers
{
    
    public class AuthController : Controller
    {
        private readonly IUserService _userService;


        public AuthController(IUserService uerService)
        {
            _userService = uerService;
        }


        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid == false)
                return View(model);

            //List<Task<OperationResult>> operationResults = new List<Task<OperationResult>>();

            //operationResults.Add( _userService.LoginUser1(new UserLoginDto()
            //{
            //    UserName = model.UserName,
            //    Password = model.Password
            //}));


            //operationResults.Add(_userService.LoginUser1(new UserLoginDto()
            //{
            //    UserName = model.UserName,
            //    Password = model.Password
            //}));


            //Task.WaitAll(operationResults.ToArray());

            var result =  _userService.LoginUser(new UserLoginDto()
            {
                UserName = model.UserName,
                Password = model.Password
            });

            //if (result.status == OperationResultStatus.NotFound)
            //{
            //    ModelState.AddModelError("UserName", "اطلاعات یافت نشد");
            //    return View(model);
            //}
            return RedirectToAction("Index", "Home");
        }


        [HttpGet]
        public IActionResult Register()
        {
           
            return View();
        }


        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid == false)
                return View(model);

            var result = _userService.RegisterUser(new UserRegisterDto()
            {
                UserName = model.UserName,
                FullName = model.FullName,
                Password = model.Password
            });

            if (result.Status == OperationResultStatus.NotFound)
            {
                ModelState.AddModelError("UserName", "اطلاعات یافت نشد");
                return View(model);
            }
            return RedirectToAction("Login");
        }

        
    }

    
}
