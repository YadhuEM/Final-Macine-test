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
    public class EmployeeController : ControllerBase
    {

        ITravelRepository employeeRegistration;
        public EmployeeController(ITravelRepository _p)
        {
            employeeRegistration = _p;
        }

        //getemployees
        [HttpGet]
        [Route("GetEmployees")]
        public async Task<IActionResult> GetEmployees()
        {
            try
            {
                var employees = await employeeRegistration.GetEmployees();
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
        [Route("GetEmployeeById")]
        public async Task<IActionResult> GetEmployeeById(int id)
        {
            try
            {
                var employee = await employeeRegistration.GetEmployeeById(id);
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
        [Route("AddEmployee")]
        public async Task<IActionResult> AddEmployee([FromBody] EmployeeRegistration model)
        {
            //check the validation of body
            if (ModelState.IsValid)
            {
                try
                {
                    var postId = await employeeRegistration.AddEmployee(model);
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
        [Route("UpdateEmployee")]
        public async Task<IActionResult> UpdateEmployee([FromBody] EmployeeRegistration model)
        {
            //check the validation of body
            if (ModelState.IsValid)
            {
                try
                {
                    await employeeRegistration.UpdateEmployee(model);
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
