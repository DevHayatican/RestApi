using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace c240tube.entity
{
    public class BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public bool IsDeleted { get; set; }

        public DateTime CreateAt { get; set; }
        public BaseEntity()
        {
            this.IsDeleted = false;
            CreateAt = DateTime.Now;
        }
    }
}
