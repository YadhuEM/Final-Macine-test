using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravellingApplicationNew.Models;

namespace TravellingApplicationNew.Repository
{
    public class TravelRepository: ITravelRepository
    {
        FINAL_TRAVELContext _db;

        public TravelRepository(FINAL_TRAVELContext db)
        {
            _db = db;
        }
        public Login validateUser(string username, string password)
        {
            if (_db != null)
            {
                Login dbuser = _db.Login.FirstOrDefault(em => em.UserName == username && em.UserPassword == password);
                if (dbuser != null)
                {
                    return dbuser;
                }
            }
            return null;

        }

        //get all employees
        public async Task<List<EmployeeRegistration>> GetEmployees()
        {
            if (_db != null)
            {
                return await _db.EmployeeRegistration.ToListAsync();
            }
            return null;
        }

        //get employee by id
        public async Task<EmployeeRegistration> GetEmployeeById(int id)
        {
            if (_db != null)
            {
                //LINQ
                return await (from c in _db.EmployeeRegistration
                              
                              where c.EmpId == id 
                              select new EmployeeRegistration
                              {
                                  EmpId = c.EmpId,
                                  FirstName = c.FirstName,
                                  LastName = c.LastName,
                                  Age = c.Age,
                                  Gender = c.Gender,
                                  IsActive = (bool)c.IsActive,
                                  Address = c.Address,
                                  PhoneNumber=c.PhoneNumber

                              }).FirstOrDefaultAsync();
            }
            return null;
        }

        //add employee
        public async Task<int> AddEmployee(EmployeeRegistration employee)
        {
            if (_db != null)
            {
                await _db.EmployeeRegistration.AddAsync(employee);
                await _db.SaveChangesAsync(); //commit the transaction
                return employee.EmpId;
            }
            return 0;

        }

        //update employee
        public async Task UpdateEmployee(EmployeeRegistration employee)
        {
            if (_db != null)
            {
                _db.EmployeeRegistration.Update(employee);
                await _db.SaveChangesAsync(); //commit the transaction

            }
        }


        //requests
        //get all requests
        public async Task<List<RequestTable>> GetRequests()
        {
            if (_db != null)
            {
                return await _db.RequestTable.ToListAsync();
            }
            return null;
        }

        //get employee by id
        public async Task<RequestTable> GetRequestById(int id)
        {
            if (_db != null)
            {
                //LINQ
                return await (from c in _db.RequestTable

                              where c.RequestId == id
                              select new RequestTable
                              {
                                  RequestId = c.RequestId,
                                  CauseTravel = c.CauseTravel,
                                  Source = c.Source,
                                  Destination = c.Destination,
                                  Priority = c.Priority,
                                  IsActive = (bool)c.IsActive,
                                  NoDays = c.NoDays,
                                  FromDate=c.FromDate,
                                  ToDate=c.ToDate,
                                  EmpId=c.EmpId

                              }).FirstOrDefaultAsync();
            }
            return null;
        }

        //add employee
        public async Task<int> AddRequest(RequestTable employee)
        {
            if (_db != null)
            {
                await _db.RequestTable.AddAsync(employee);
                await _db.SaveChangesAsync(); //commit the transaction
                return employee.RequestId;
            }
            return 0;

        }

        //update employee
        public async Task UpdateRequest(RequestTable employee)
        {
            if (_db != null)
            {
                _db.RequestTable.Update(employee);
                await _db.SaveChangesAsync(); //commit the transaction

            }
        }

        //projects
       
        //get all projects
        public async Task<List<ProjectTable>> GetProjects()
        {
            if (_db != null)
            {
                return await _db.ProjectTable.ToListAsync();
            }
            return null;
        }

        //get employee by id
        public async Task<ProjectTable> GetProjectById(int id)
        {
            if (_db != null)
            {
                //LINQ
                return await (from c in _db.ProjectTable

                              where c.ProjectId == id
                              select new ProjectTable
                              {
                                  ProjectId = c.ProjectId,
                                  ProjectName = c.ProjectName,
                                  
                                  IsActive = (bool)c.IsActive,
                                 

                              }).FirstOrDefaultAsync();
            }
            return null;
        }

        //add project
        public async Task<int> AddProject(ProjectTable employee)
        {
            if (_db != null)
            {
                await _db.ProjectTable.AddAsync(employee);
                await _db.SaveChangesAsync(); //commit the transaction
                return employee.ProjectId;
            }
            return 0;

        }

        //update project
        public async Task UpdateProject(ProjectTable employee)
        {
            if (_db != null)
            {
                _db.ProjectTable.Update(employee);
                await _db.SaveChangesAsync(); //commit the transaction

            }
        }
    }
}
