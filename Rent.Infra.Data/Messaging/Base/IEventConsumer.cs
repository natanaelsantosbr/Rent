using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rent.Infra.Data.Messaging.Base
{
    public interface IEventConsumer
    {
        void StartConsuming();
    }
}
