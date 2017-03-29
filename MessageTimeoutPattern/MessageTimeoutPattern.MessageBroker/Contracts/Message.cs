using System;

namespace MessageTimeoutPattern.MessageBroker.Contracts
{
    public class Message
    {
        public Guid Id { get; }
        public DateTime Timestamp { get; }
        public DateTime TimeToLive { get; }
        public string Topic { get; }
        public string Content { get; }

        public Message(Guid id, DateTime timestamp, DateTime timeToLive, string topic, string content)
        {
            //f the rules.
            Id = id;
            Timestamp = timestamp;
            TimeToLive = timeToLive;
            Topic = topic;
            Content = content;
        }

        public override string ToString()
            => $"{nameof(Message)}: {nameof(Id)}='{Id}', {nameof(Timestamp)}='{Timestamp}', {nameof(Topic)}='{Topic}', {nameof(Content)}='{Content}'. ";
    }
}
