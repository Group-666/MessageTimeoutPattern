using MessageTimeoutPattern.MessageBroker.Contracts;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MessageTimeoutPattern.MessageBroker.Utilities
{
    public class MessageBrokerHost
    {
        public static ConcurrentQueue<Message> MessageQueue { get; } = new ConcurrentQueue<Message>();

        internal static void Start()
        {
            Task.Run(() => Work());
        }

        private static void Work()
        {
            while (true)
            {
                Task.Delay(new TimeSpan(0, 0, 1));

                var messages = new List<Message>(MessageQueue);

                Message tempMessage;
                messages.ForEach(m => MessageQueue.TryDequeue(out tempMessage));
                
                foreach(var message in messages)
                    if (message.TimeToLive > DateTime.Now)
                        MessageQueue.Enqueue(message);
            }
        }
    }
}
