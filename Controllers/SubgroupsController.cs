using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using react_slingshot_project.Entities;
using react_slingshot_project.Models;
using react_slingshot_project.Models.SubgroupsDto;
using react_slingshot_project.Services;

namespace react_slingshot_project.Controllers
{
    [Route("api/subgroups")]
    public class SubgroupsController : Controller
    {
        private ISubgroupInfoRepository _subgroupInfoRepository; 
        private readonly ILogger<SubgroupsController> logger;
        

        public SubgroupsController(ILogger<SubgroupsController> logger, ISubgroupInfoRepository subgroupInfoRepository)
        {
            this.logger = logger;
            _subgroupInfoRepository = subgroupInfoRepository;
        }

        [HttpGet()]
        public IActionResult GetSubgroups()
        {
            var subgroupEntities = _subgroupInfoRepository.GetSubgroups();

            var results = new List<SubgroupDto>();
            foreach (var subgroupEntity in subgroupEntities)
            {
                results.Add(new SubgroupDto{
                    id = subgroupEntity.id,
                    groupName = subgroupEntity.groupName,
                    description = subgroupEntity.description,
                    Created = subgroupEntity.Created,
                    Admin = subgroupEntity.Admin,
                    Members = subgroupEntity.Members                  
                });                
            }

            return Ok(results);
        }

        [HttpGet("{id}")]
        public IActionResult GetSubgroup(int id)
        {
            var subgroupEntity = _subgroupInfoRepository.GetSubgroup(id);

            if (subgroupEntity == null)
            {
                logger.LogInformation($"Subgroup with {id} was not found");
                return NotFound();
            }
            var result = new SubgroupDto{
                    id = subgroupEntity.id,
                    groupName = subgroupEntity.groupName,
                    description = subgroupEntity.description,
                    Created = subgroupEntity.Created,
                    Admin = subgroupEntity.Admin,
                    Members = subgroupEntity.Members                  
            };
            return Ok(result);
        }

        [HttpPost()]
        public IActionResult CreateSubgroup([FromBody] SubgroupCreateDto subgroup)
        {

            if (subgroup == null)
            {
                return BadRequest();        
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var newSubgroup = new Subgroup
            {
                    groupName = subgroup.groupName,
                    description = subgroup.description,
                    Created = subgroup.Created,
                    Admin = subgroup.Admin,
                    Members = subgroup.Members   
            };

            _subgroupInfoRepository.AddSubgroup(newSubgroup);
            if (!_subgroupInfoRepository.Save())
            {
                return StatusCode(500, "Saving subgroup was not successfull");
            }

            var createdSubgroup = new SubgroupDto{
                id = newSubgroup.id,
                groupName = newSubgroup.groupName,
                description = newSubgroup.description,
                Created = newSubgroup.Created,
                Admin = newSubgroup.Admin,
                Members = newSubgroup.Members   
            };

            return Ok(createdSubgroup);
        }
/*
        [HttpPut()]
        public IActionResult UpdateSubgroup([FromBody] SubgroupsUpdateDto subgroup)
        {  
            var subgroupToUpdate = _subgroupInfoRepository.GetSubgroups().FirstOrDefault(x => x.id == subgroup.id);
            
            if (subgroupToUpdate == null)
            {
                return NotFound();
            }
           
            var newSubgroup = new Subgroup
            {
                id = subgroup.id,
                fname = subgroup.fname,
                lname = subgroup.lname,
                description = subgroup.description
            };

           _subgroupInfoRepository.UpdateSubgroup(newSubgroup);
            if (!_subgroupInfoRepository.Save())
            {
                return StatusCode(500, "Updating subgroup was not successfull");
            }   
            return Ok(newSubgroup);
        }

        */

        [HttpDelete("{id}")]
        public IActionResult DeleteSubgroup(int id)
        {
            var subgroup = _subgroupInfoRepository.GetSubgroups().FirstOrDefault(x => x.id == id);

            if (subgroup == null)
            {
                return NotFound();  
            }
                
            _subgroupInfoRepository.DeleteSubgroup(subgroup);

           if (!_subgroupInfoRepository.Save())
            {
                return StatusCode(500, "Deleting subgroup was not successfull");
            }    

            return NoContent();
         }

    }
    
}
