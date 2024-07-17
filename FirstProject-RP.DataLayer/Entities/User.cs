using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstProject_RP.DataLayer.Entities
{
    public class User :BaseEntity
    {
  

        public string FullName { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }

        #region Relations

        public ICollection<Post> Posts { get; set; }    

        public ICollection<PostComment> PostComments { get; set; }

        #endregion

        public UserRole Role { get; set; }


        public enum UserRole
        {
            Admin,
            User,
            Writer,
        }
    }
}
