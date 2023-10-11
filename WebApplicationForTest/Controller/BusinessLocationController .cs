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

    public class BusinessLocationController : ControllerBase
    {
        private readonly AppDBContexts _appDBContexts;

        public BusinessLocationController(AppDBContexts appDBContexts)
        {
            _appDBContexts = appDBContexts;
        }
        private static List<BusinessLocation> _locations = new List<BusinessLocation>
        {
        new BusinessLocation { Name = "Location 1", Address = "123 Main St", TelephoneNumber = "123-456-7890" },
        new BusinessLocation { Name = "Location 2", Address = "456 Elm St", TelephoneNumber = "987-654-3210" }
        };

        // GET: api/BusinessLocation
        [HttpGet]
        public IEnumerable<BusinessLocation> GetLocations()
        {
            return _appDBContexts.BusinessLocation.ToList();
        }

        // GET: api/BusinessLocation/5
        [HttpGet("{id}")]
        public ActionResult<BusinessLocation> GetLocation(string name)
        {
            var location = _appDBContexts.BusinessLocation.FirstOrDefault(l => l.Name == name);
            if (location == null)
            {
                return NotFound();
            }
            return location;
        }

        // POST: api/BusinessLocation
        [HttpPost]
        public ActionResult<BusinessLocation> PostLocation(BusinessLocation location)
        {
            _locations.Add(location);
            return CreatedAtAction("GetLocation", new { id = location.Name }, location);
        }

        // PUT: api/BusinessLocation/5
        [HttpPut("{id}")]
        public IActionResult PutLocation(string id, BusinessLocation location)
        {
            var existingLocation = _appDBContexts.BusinessLocation.FirstOrDefault(l => l.Name == id);
            if (existingLocation == null)
            {
                return NotFound();
            }

            existingLocation.Name = location.Name;
            existingLocation.Address = location.Address;
            existingLocation.TelephoneNumber = location.TelephoneNumber;

            return NoContent();
        }

        // DELETE: api/BusinessLocation/5
        [HttpDelete("{id}")]
        public IActionResult DeleteLocation(string id)
        {
            var location = _appDBContexts.BusinessLocation.FirstOrDefault(l => l.Name == id);
            if (location == null)
            {
                return NotFound();
            }

            _appDBContexts.BusinessLocation.Remove(location);
            return NoContent();
        }
    }
}
