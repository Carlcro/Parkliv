using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace react_slingshot_project.Entities
{
    public class Subgroup
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        [Required]
        [MaxLength(50)]
        public string groupName { get; set; }
       
        [Required]
        [MaxLength(240)]
        public string description { get; set; }
        
        [Required]
        public DateTime Created { get; set; }          

        [Required]
        public virtual Member Admin {get; set;}
        public int AdminId  { get; set; }
        public virtual ICollection<Member> Members { get; set; }  =
                                new List<Member>();
    }
}