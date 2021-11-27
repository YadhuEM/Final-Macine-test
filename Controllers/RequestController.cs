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
    public class RequestController : ControllerBase
    {
        ITravelRepository employeeRequest;
        public RequestController(ITravelRepository _p)
        {
            employeeRequest = _p;
        }

        //get requests
        [HttpGet]
        [Route("GetRequests")]
        public async Task<IActionResult> GetRequests()
        {
            try
            {
                var employees = await employeeRequest.GetRequests();
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

        //get employee by id

        [HttpGet]
        [Route("GetRequestById")]
        public async Task<IActionResult> GetRequestById(int id)
        {
            try
            {
                var employee = await employeeRequest.GetRequestById(id);
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


        //add employee
        [HttpPost]
        [Route("AddRequest")]
        public async Task<IActionResult> AddRequest([FromBody] RequestTable model)
        {
            //check the validation of body
            if (ModelState.IsValid)
            {
                try
                {
                    var postId = await employeeRequest.AddRequest(model);
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

        //update employee
        [HttpPut]
        [Route("UpdateRequest")]
        public async Task<IActionResult> UpdateRequest([FromBody] RequestTable model)
        {
            //check the validation of body
            if (ModelState.IsValid)
            {
                try
                {
                    await employeeRequest.UpdateRequest(model);
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
