using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rent.Domain.Abstractions.Validations
{
    public interface IValidable
    {
        bool Valid { get; }
        bool Invalid { get; }
        IEnumerable<string> Alerts { get; }
    }
}
