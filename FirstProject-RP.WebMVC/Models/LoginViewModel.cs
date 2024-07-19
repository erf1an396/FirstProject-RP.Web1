using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace FirstProject_RP.WebMVC.Models
{
    public class LoginViewModel 
    {

            [Required(ErrorMessage = "نام کاربری را وارد کنید")]
            public string UserName { get; set; }

            [Required(ErrorMessage = "پسوورد را وارد کنید")]
            [MinLength(6, ErrorMessage = "باید بیشتراز ۵ کاراکتر باشد")]
            public string Password { get; set; }
        
    }
}
