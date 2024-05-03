﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rent.Application.MessagePublishers
{
    public interface IMessagePublisher
    {
        Task PublishAsync(string topic, object message);
    }
}
