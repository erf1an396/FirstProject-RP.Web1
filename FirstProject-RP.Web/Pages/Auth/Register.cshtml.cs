using System.ComponentModel.DataAnnotations;
using FirstProject_RP.CoreLayer.Utilities;
using FirtsProject_RP.CoreLayer.DTOs.Users;
using FirtsProject_RP.CoreLayer.Services.Users;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FirstProject_RP.Web.Pages.Auth
{
    [BindProperties]
    [ValidateAntiForgeryToken]
    public class RegisterModel : PageModel
    {
        

        #region Properties

        [Display(Name = "نام کاربری")]
        [Required(ErrorMessage = "{0} را وارد کنید ")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "{0} را وارد کنید ")]
        [Display(Name = "نام و نام خانوادگی")]
        public string Password { get; set; }


        [Required(ErrorMessage = "{0} را وارد کنید ")]
        [Display(Name = "کلمه عبور ")]
        [MinLength(6,ErrorMessage = "{0} باید بیشتراز ۵ کاراکتر باشد")]
        public string FullName { get; set; }

        #endregion

        private readonly IUserService _userService;



        public RegisterModel(IUserService userService)
        {
            _userService = userService;
        }
        public void OnGet()
        {
            
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();

            var result = _userService.RegisterUser(new UserRegisterDto()
            {
                FullName = FullName,
                UserName = UserName,
                Password = Password
            });
            if (result.Status == OperationResultStatus.Error)
            {
                ModelState.AddModelError("UserName",result.Message);
                return Page();
            }
            return RedirectToPage("Login");
        }
    }
}
