using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace FirstProject_RP.WebMVC.Models
{
    public class RegisterViewModel
    {
        
        [Display(Name = "نام کاربری")]
        [Required(ErrorMessage = "{0} را وارد کنید ")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "{0} را وارد کنید ")]
        [Display(Name = "نام و نام خانوادگی")]
        public string Password { get; set; }


        [Required(ErrorMessage = "{0} را وارد کنید ")]
        [Display(Name = "کلمه عبور ")]
        [MinLength(6, ErrorMessage = "{0} باید بیشتراز ۵ کاراکتر باشد")]
        public string FullName { get; set; }

    }
}
