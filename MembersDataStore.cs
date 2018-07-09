using System.Collections.Generic;
using react_slingshot_project.Models;
using react_slingshot_project.Models.MembersDto;

namespace react_slingshot_project
{
    public class MembersDataStore
    {
        public static MembersDataStore Current {get;} = new MembersDataStore();
        public List<MembersDto> Members { get; set; }
    
        public MembersDataStore(){
            Members = new List<MembersDto>(){                
                new MembersDto(){
                    id = 1,
                    fname = "Carl",
                    lname = "Cronsioe",
                    description = "lång"
                  },
                new MembersDto(){
                     id = 2,
                     fname = "Pål",
                     lname = "Ahren",
                     description = "musiker"
                 }          
             
            };
        }
    }
}