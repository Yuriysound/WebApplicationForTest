using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using WebApplicationForTest.Model;

namespace WebApplicationForTest.Controller
{
    

    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CustomerController : ControllerBase
    {
        private readonly AppDBContexts _appDBContexts;

        public CustomerController(AppDBContexts appDBContexts)
        {
            _appDBContexts = appDBContexts;
        }

        private readonly List<Customer> _customers = new List<Customer>
        {
        new Customer { CustomerNumber = 1, Name = "Customer A" },
        new Customer { CustomerNumber = 2, Name = "Customer B" }
        };

        // GET: api/Customer
        [HttpGet]
        public IEnumerable<Customer> GetCustomers()
        {
            return _customers;
        }

        // GET: api/Customer/1
        [HttpGet("{id}")]
        public ActionResult<Customer> GetCustomer(int id)
        {
            var customer = _appDBContexts.Customers.FirstOrDefault(c => c.CustomerNumber == id);
            if (customer == null)
            {
                return NotFound();
            }
            return customer;
        }

        // POST: api/Customer
        [HttpPost]
        public ActionResult<Customer> PostCustomer(Customer customer)
        {
            _customers.Add(customer);
            return CreatedAtAction("GetCustomer", new { id = customer.CustomerNumber }, customer);
        }

        // PUT: api/Customer/1
        [HttpPut("{id}")]
        public IActionResult PutCustomer(int id, Customer customer)
        {
            var existingCustomer = _appDBContexts.Customers.FirstOrDefault(c => c.CustomerNumber == id);
            if (existingCustomer == null)
            {
                return NotFound();
            }

            existingCustomer.Name = customer.Name;
            return NoContent();
        }

        // DELETE: api/Customer/1
        [HttpDelete("{id}")]
        public IActionResult DeleteCustomer(int id)
        {
            var customer = _appDBContexts.Customers.FirstOrDefault(c => c.CustomerNumber == id);
            if (customer == null)
            {
                return NotFound();
            }

            _appDBContexts.Customers.Remove(customer);
            return NoContent();
        }
    }

}
