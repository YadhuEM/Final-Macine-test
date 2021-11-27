using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravellingApplicationNew.Models;
using TravellingApplicationNew.Repository;

namespace TravellingApplicationNew.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        ITravelRepository employeeProject;
        public ProjectController(ITravelRepository _p)
        {
            employeeProject = _p;
        }

        //get GetProjects
        [HttpGet]
        [Route("GetProjects")]
        public async Task<IActionResult> GetProjects()
        {
            try
            {
                var employees = await employeeProject.GetProjects();
                if (employees == null)
                {
                    return NotFound();
                }
                return Ok(employees);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        //get project by id

        [HttpGet]
        [Route("GetProjectById")]
        public async Task<IActionResult> GetProjectById(int id)
        {
            try
            {
                var employee = await employeeProject.GetProjectById(id);
                if (employee != null)
                {
                    return Ok(employee);
                }
                return NotFound();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }


        //add project
        [HttpPost]
        [Route("AddProject")]
        public async Task<IActionResult> AddProject([FromBody] ProjectTable model)
        {
            //check the validation of body
            if (ModelState.IsValid)
            {
                try
                {
                    var postId = await employeeProject.AddProject(model);
                    if (postId > 0)
                    {
                        return Ok(postId);
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                catch (Exception)
                {
                    return BadRequest();
                }
            }
            return BadRequest();
        }

        //update project
        [HttpPut]
        [Route("UpdateProject")]
        public async Task<IActionResult> UpdateProject([FromBody] ProjectTable model)
        {
            //check the validation of body
            if (ModelState.IsValid)
            {
                try
                {
                    await employeeProject.UpdateProject(model);
                    return Ok();
                }
                catch (Exception)
                {
                    return BadRequest();
                }
            }
            return BadRequest();
        }
    }
}
