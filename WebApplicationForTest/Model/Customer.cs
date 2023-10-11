using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationForTest.Model
{
    // Customer Model
    public class Customer
    {
        public int Id { get; set; }
        public ICollection<BusinessLocation> BusinessLocations { get; set; }
        public int CustomerNumber { get; set; }
        public string Name { get; set; }
    }
}
