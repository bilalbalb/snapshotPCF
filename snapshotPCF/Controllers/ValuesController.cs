using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.ApplicationInsights;

namespace snapshotPCF.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {

        TelemetryClient _telemetryClient = new TelemetryClient();
        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public void Get(int id)
        {
            if (id == 1)
            {
                ArgumentNullException ex = new ArgumentNullException();
                _telemetryClient.TrackException(ex);
            }
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
