using System;
using System.Collections.Generic;
using react_slingshot_project.Entities;

namespace react_slingshot_project.Models.SubgroupsDto
{
    public class SubgroupCreateDto
    {
     public string groupName { get; set; }  
     public string description { get; set; }
     public DateTime Created { get; set; }       
    
     public int AdminId { get; set; }    
     public  Member Admin {get; set;} 
     public virtual ICollection<Member> Members { get; set; }
    }
}
