using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static FirstProject_RP.DataLayer.Entities.User;

namespace FirtsProject_RP.CoreLayer.DTOs.Users
{
    public class UserDto
    {
        public string FullName { get; set; }
        
        public string UserName { get; set; }
        
        public string Password { get; set; }

        public UserRole Role { get; set; }

        public int Id { get; set; }

        public DateTime CreationDate { get; set; }
    }
}
