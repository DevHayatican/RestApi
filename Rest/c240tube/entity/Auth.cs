using c240tube.entity.enums;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace c240tube.entity
{
    [Table("Auths")]
    public class Auth : BaseEntity
    {
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [MinLength(6)]
        public string Password { get; set; }
        public ERole Role { get; set; }


    }
}
