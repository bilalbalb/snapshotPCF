using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.ApplicationInsights;
using Microsoft.ApplicationInsights.DataContracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace snapshotPCF.Controllers
{
    [Produces("application/json")]
    [Route("api/Test")]
    public class TestController : Controller
    {

        TelemetryClient _telemetryClient = new TelemetryClient();
        

        [HttpPost(Name ="Post")]
        [Route("postdata")]
        public IActionResult PostData([FromBody]string value)
        {
            if (value == null)
            {
                _telemetryClient.TrackAvailability("Post api", DateTimeOffset.Now, TimeSpan.MaxValue, "test1", true);
                return Ok($"{value}, was passed , { DateTime.Now}");
            }

            else
            {
                EventTelemetry eventTelmetry = new EventTelemetry();
                eventTelmetry.Name = "Test Event";
                eventTelmetry.Timestamp = DateTime.Now;
                _telemetryClient.TrackEvent(eventTelmetry);
                return Unauthorized();
            }
        }
    }
}
