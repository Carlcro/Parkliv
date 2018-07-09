using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace react_slingshot_project.Entities
{
    public class Member
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        [Required]
        [MaxLength(50)]
        public string fname { get; set; }
        [Required]
        [MaxLength(50)]
        public string lname { get; set; }
        [Required]
        [MaxLength(240)]
        public string description { get; set; }
    }
}