using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

//added models
using WebAPIDemo.Models;

namespace WebAPIDemo.Controllers
{//Create Employees Controller based on the model
    public class EmployeesController : ApiController
    {
        Employee[] employees = new Employee[]{
            new Employee { ID = 1, Name = "Mark", JoiningDate = DateTime.Parse(DateTime.Today.ToString()), Age = 30 },
            new Employee { ID = 2, Name = "Allan", JoiningDate = DateTime.Parse(DateTime.Today.ToString()), Age = 35 },
            new Employee { ID = 3, Name = "Johny", JoiningDate = DateTime.Parse(DateTime.Today.ToString()), Age = 21 }
        };

        public IEnumerable<Employee> GetAllEmployees()
        {
            return employees;
        }

        public IHttpActionResult GetEmployee(int id)
        {
            var employee = employees.FirstOrDefault((p) => p.ID == id); //pull id and place into employee
            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employee);
        }
    }
}
