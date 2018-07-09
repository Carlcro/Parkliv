using System.ComponentModel.DataAnnotations;

namespace react_slingshot_project.Models.MembersDto
{
    public class MembersCreateDto
    {

       [Required] 
       [MaxLength(50)]
       public string fname { get; set; }
       [Required]
       [MaxLength(50)]
       public string lname { get; set; }
       [MaxLength(240)]
       public string description {get; set; }
    }
}
