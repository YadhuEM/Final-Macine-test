using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravellingApplicationNew.Models;

namespace TravellingApplicationNew.Repository
{
   public interface ITravelRepository
    {
        //--- get all employee ---//
        Task<List<EmployeeRegistration>> GetEmployees();
        
        //get employee by id
        Task<EmployeeRegistration> GetEmployeeById(int id);
        
        //add employee
        Task<int> AddEmployee(EmployeeRegistration employee);

        //update employee
        Task UpdateEmployee(EmployeeRegistration employee);

        //--- get all requests ---//
        Task<List<RequestTable>> GetRequests();

        //get request by id
        Task<RequestTable> GetRequestById(int id);

        //add employee
        Task<int> AddRequest(RequestTable employee);

        //update employee
        Task UpdateRequest(RequestTable employee);


        //--- get all projects ---//
        Task<List<ProjectTable>> GetProjects();

        //get request by id
        Task<ProjectTable> GetProjectById(int id);

        //add employee
        Task<int> AddProject(ProjectTable employee);

        //update employee
        Task UpdateProject(ProjectTable employee);


        // get user Login
        public Login validateUser(string username, string password);
    }
}
