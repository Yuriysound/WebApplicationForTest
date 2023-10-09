using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplicationForTest.Model;

namespace WebApplicationForTest.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusinessLocationController : ControllerBase
    {
        private static List<BusinessLocation> _locations = new List<BusinessLocation>
        {
        new BusinessLocation { Name = "Location 1", Address = "123 Main St", TelephoneNumber = "123-456-7890" },
        new BusinessLocation { Name = "Location 2", Address = "456 Elm St", TelephoneNumber = "987-654-3210" }
        };

        // GET: api/BusinessLocation
        [HttpGet]
        public IEnumerable<BusinessLocation> GetLocations()
        {
            return _locations;
        }

        // GET: api/BusinessLocation/5
        [HttpGet("{id}")]
        public ActionResult<BusinessLocation> GetLocation(int id)
        {
            var location = _locations.Find(l => l.Name == id.ToString());
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
            var existingLocation = _locations.Find(l => l.Name == id);
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
            var location = _locations.Find(l => l.Name == id);
            if (location == null)
            {
                return NotFound();
            }

            _locations.Remove(location);
            return NoContent();
        }
    }
}
