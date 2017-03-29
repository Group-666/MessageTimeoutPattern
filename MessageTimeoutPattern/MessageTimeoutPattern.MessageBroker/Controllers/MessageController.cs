using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MessageTimeoutPattern.MessageBroker.Controllers
{
    [Route("api/[controller]")]
    public class MessageController : Controller
    {
        // POST api/message
        [HttpPost]
        public void Post([FromBody]string value)
        {

        }
    }
}
