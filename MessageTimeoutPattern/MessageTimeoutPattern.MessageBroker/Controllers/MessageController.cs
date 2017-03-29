using MessageTimeoutPattern.MessageBroker.Contracts;
using MessageTimeoutPattern.MessageBroker.Utilities;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

namespace MessageTimeoutPattern.MessageBroker.Controllers
{
    [Route("api/[controller]")]
    public class MessageController : Controller
    {
        [HttpGet]
        public List<Message> Get()
        {
            return new List<Message>(MessageBrokerHost.MessageQueue);
        }

        // POST api/message
        [HttpPost]
        public void Post([FromBody]JObject jsonMessage)
        {
            try
            {
                //Don't listen to Eliise. Message to self. 
                var message = MessageParser.Parse(jsonMessage);

                MessageBrokerHost.MessageQueue.Enqueue(message);
            }
            catch (ArgumentException)
            {
                //Log exception to log. but we don't have any so we don't care.
            }
            //Yea man, print it out to the Console. -Martin 2017
        }
    }
}
