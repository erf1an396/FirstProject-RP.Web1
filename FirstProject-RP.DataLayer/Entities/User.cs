using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstProject_RP.DataLayer.Entities
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        public string FullName { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }

        public ICollection<Post> Posts { get; set; }    

        public ICollection<PostComment> PostComments { get; set; }

        public UserRole Role { get; set; }


        public enum UserRole
        {
            Admin,
            User,
            Writer,
        }
    }
}
