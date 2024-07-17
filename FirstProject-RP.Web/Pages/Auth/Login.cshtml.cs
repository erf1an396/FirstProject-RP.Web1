using System.ComponentModel.DataAnnotations;
using CodeYad_Blog.CoreLayer.Utilities;
using FirtsProject_RP.CoreLayer.DTOs.Users;
using FirtsProject_RP.CoreLayer.Services.Users;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Identity.Client;

namespace FirstProject_RP.Web.Pages.Auth
{
    [ValidateAntiForgeryToken]
    [BindProperties]
    public class LoginModel : PageModel
    {
        private readonly IUserService _userService;

        public LoginModel(IUserService userService)
        {
            _userService = userService;
        }

        [Required(ErrorMessage = "نام کاربری را وارد کنید")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "پسوورد را وارد کنید")]
        [MinLength(6,ErrorMessage = "باید بیشتراز ۵ کاراکتر باشد")]
        public string Password { get; set; }

        public void OnGet()
        {
            
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid == false)
                return Page();

            var result = _userService.LoginUser(new UserLoginDto()
            {
                UserName = UserName,
                Password = Password

            });

            if (result.Status == OperationResultStatus.NotFound)
            {
                ModelState.AddModelError("UserName", "اطلاعات یافت نشد");
                return Page();
            }
            return RedirectToPage("../Index");
        }
    }
}
