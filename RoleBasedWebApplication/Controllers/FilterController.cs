using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using RoleBasedWebApplication.Models;

namespace RoleBasedWebApplication.Controllers
{
    public class FilterController : ApiController
    {
        private EntriesContext db = new EntriesContext();

        // POST: api/Filter
        public IEnumerable<Artifact> Post([FromBody]FilterData data)
        {
            var artifacts = db.Artifacts.Where(a => a.Name.Contains(data.Name) 
                || (a.OrderWorth >= data.PriceFrom && a.OrderWorth <= data.PriceTo)).ToList();
            return artifacts;
        }
    }

    public class FilterData
    {
        public string Name { get; set; }
        public int PriceFrom { get; set; }
        public int PriceTo { get; set; }
    }
}
