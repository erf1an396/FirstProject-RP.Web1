using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirtsProject_RP.CoreLayer.DTOs.Users
{
    public class UserRegisterDto
    {
        public string FullName { get; set; }
        
        public string UserName { get; set; }
        
        public string Password { get; set; }
    }
}
