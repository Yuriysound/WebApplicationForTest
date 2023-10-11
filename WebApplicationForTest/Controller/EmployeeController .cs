using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplicationForTest.Model;

namespace WebApplicationForTest.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class EmployeeController : ControllerBase
    {
        private readonly AppDBContexts _appDBContexts;

        public EmployeeController(AppDBContexts appDBContexts)
        {
            _appDBContexts = appDBContexts;
        }

        private static List<Employee> _employees = new List<Employee>
        {
        new Employee { Email = "employee1@example.com", FirstName = "John", LastName = "Doe", PhoneNumber = "111-222-3333" },
        new Employee { Email = "employee2@example.com", FirstName = "Jane", LastName = "Smith", PhoneNumber = "444-555-6666" }
        };

        // GET: api/Employee
        [HttpGet]
        public IEnumerable<Employee> GetEmployees()
        {
            return _employees;
        }

        // GET: api/Employee/employee1@example.com
        [HttpGet("{email}")]
        public ActionResult<Employee> GetEmployee(string email)
        {
            var employee = _appDBContexts.Employee.FirstOrDefault(e => e.Email == email);
            if (employee == null)
            {
                return NotFound();
            }
            return employee;
        }

        // POST: api/Employee
        [HttpPost]
        public ActionResult<Employee> PostEmployee(Employee employee)
        {
            if (_employees.Exists(e => e.Email == employee.Email))
            {
                return Conflict("Employee with the same email already exists.");
            }

            _employees.Add(employee);
            return CreatedAtAction("GetEmployee", new { email = employee.Email }, employee);
        }

        // PUT: api/Employee/employee1@example.com
        [HttpPut("{email}")]
        public IActionResult PutEmployee(string email, Employee employee)
        {
            var existingEmployee = _appDBContexts.Employee.FirstOrDefault(e => e.Email == email);
            if (existingEmployee == null)
            {
                return NotFound();
            }

            existingEmployee.Email = employee.Email;
            existingEmployee.FirstName = employee.FirstName;
            existingEmployee.LastName = employee.LastName;
            existingEmployee.PhoneNumber = employee.PhoneNumber;

            return NoContent();
        }

        // DELETE: api/Employee/employee1@example.com
        [HttpDelete("{email}")]
        public IActionResult DeleteEmployee(string email)
        {
            var employee = _appDBContexts.Employee.FirstOrDefault(e => e.Email == email);
            if (employee == null)
            {
                return NotFound();
            }

            _appDBContexts.Employee.Remove(employee);
            return NoContent();
        }
    }
}
