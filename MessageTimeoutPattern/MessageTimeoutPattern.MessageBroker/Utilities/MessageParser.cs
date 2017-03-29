using MessageTimeoutPattern.MessageBroker.Contracts;
using Newtonsoft.Json.Linq;
using System;

namespace MessageTimeoutPattern.MessageBroker.Utilities
{
    public class MessageParser
    {
        public static Message Parse(JObject json)
        {
            var id = Guid.NewGuid();
            var timestamp = DateTime.Now;

            var topic = (string)json["topic"];
            var content = (string)json["content"];
            // Get time to live in secounds.
            var secounds = (int)json["timeToLive"];
            var timeToLive = DateTime.Now.AddSeconds(secounds);

            if (string.IsNullOrWhiteSpace(topic) || string.IsNullOrWhiteSpace(content))
                throw new ArgumentException("Topic or content does not contain any content. Or the json message is invalid. Or invalid message.");

            return new Message(id, timestamp, timeToLive, topic, content);
        }
    }
}
