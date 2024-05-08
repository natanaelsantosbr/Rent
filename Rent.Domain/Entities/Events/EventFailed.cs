using Rent.Domain.Abstractions.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rent.Domain.Entities.Events
{
    public class EventFailed : BaseEntity
    {
        protected EventFailed() { }

        public EventFailed(string queue, string body, string errorMesage, string? stackTrace)
        {
            QueueName = queue;
            JsonPayload = body;
            ErrorMessage = errorMesage;
            this.StackTrace = stackTrace;
        }

        public string QueueName { get; private set; }
        public string JsonPayload { get; private set; }
        public string ErrorMessage { get; private set; }
        public string? StackTrace { get; private set; }
    }
}
