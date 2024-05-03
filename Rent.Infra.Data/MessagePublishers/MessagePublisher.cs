using Rent.Domain.MessagePublishers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rent.Infra.Data.MessagePublishers
{
    public class MessagePublisher : IMessagePublisher
    {
        public async Task PublishAsync(string topic, object message)
        {
            Console.WriteLine($"Publishing to {topic}: {message}");
        }
    }
}
