using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using react_slingshot_project.Entities;
using react_slingshot_project.Models.MembersDto;
using react_slingshot_project.Services;

namespace react_slingshot_project.Controllers
{
    [Route("api/members")]
    public class MembersController : Controller
    {
        private IMemberInfoRepository _memberInfoRepository; 
        private readonly ILogger<MembersController> logger;
        

        public MembersController(ILogger<MembersController> logger, IMemberInfoRepository memberInfoRepository)
        {
            this.logger = logger;
            _memberInfoRepository = memberInfoRepository;
        }

        [HttpGet()]
        public IActionResult GetMembers()
        {
            var memberEntities = _memberInfoRepository.GetMembers();

            var results = new List<MembersDto>();
            foreach (var memberEntity in memberEntities)
            {
                results.Add(new MembersDto{
                    id = memberEntity.id,
                    fname = memberEntity.fname,
                    lname = memberEntity.lname,
                    description = memberEntity.description
                });                
            }

            return Ok(results);
        }

        [HttpGet("{id}")]
        public IActionResult GetMember(int id)
        {
            var member = _memberInfoRepository.GetMember(id);

            if (member == null)
            {
                logger.LogInformation($"Member with {id} was not found");
                return NotFound();
            }
            var result = new MembersDto{
                id = member.id,
                fname = member.fname,
                lname = member.lname,
                description = member.description
            };
            return Ok(result);
        }

        [HttpPost()]
        public IActionResult CreateMember([FromBody] MembersCreateDto member)
        {

            if (member == null)
            {
                return BadRequest();        
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var newMember = new Member
            {
                fname = member.fname,
                lname = member.lname,
                description = member.description
            };

            _memberInfoRepository.AddMember(newMember);
            if (!_memberInfoRepository.Save())
            {
                return StatusCode(500, "Saving member was not successfull");
            }

            var createdMember = new MembersDto{
                id = newMember.id,
                fname = newMember.fname,
                lname = newMember.lname,
                description = newMember.description
            };

            return Ok(createdMember);
        }

        [HttpPut()]
        public IActionResult UpdateMember([FromBody] MembersUpdateDto member)
        {  
            var memberToUpdate = _memberInfoRepository.GetMembers().FirstOrDefault(x => x.id == member.id);
            
            if (memberToUpdate == null)
            {
                return NotFound();
            }
           
            var newMember = new Member
            {
                id = member.id,
                fname = member.fname,
                lname = member.lname,
                description = member.description
            };

           _memberInfoRepository.UpdateMember(newMember);
            if (!_memberInfoRepository.Save())
            {
                return StatusCode(500, "Updating member was not successfull");
            }   
            return Ok(newMember);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteMember(int id)
        {
            var member = _memberInfoRepository.GetMembers().FirstOrDefault(x => x.id == id);

            if (member == null)
            {
                return NotFound();  
            }
                
            _memberInfoRepository.DeleteMember(member);

           if (!_memberInfoRepository.Save())
            {
                return StatusCode(500, "Deleting member was not successfull");
            }    

            return NoContent();
        }
    }
}
