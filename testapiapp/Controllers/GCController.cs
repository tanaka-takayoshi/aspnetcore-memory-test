using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace testapiapp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GCController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            var l1 = GC.GetAllocatedBytesForCurrentThread();
            var l2 = GC.GetTotalMemory(false);
            GC.Collect();
            var l3 = GC.GetAllocatedBytesForCurrentThread();
            var l4 = GC.GetTotalMemory(false);
            return new []{"AllocatedBytesForCurrentThread",$"{l1} to {l3}","TotalMemory",$"{l2} to {l4}"};
        }

    }
}
