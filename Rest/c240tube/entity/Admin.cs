using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace c240tube.entity
{
    public class Admin : BaseEntity
    {
        [StringLength(100)]
        public string? Name { get; set; }
        [Required]
        public string Surname { get; set; }
        public string Phone { get; set; }
        public Auth Auth { get; set; }

    }
}
