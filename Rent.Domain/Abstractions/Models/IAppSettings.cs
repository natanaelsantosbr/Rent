using Rent.Domain.Models.ValueObjects.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rent.Domain.Abstractions.Models
{
    public interface IAppSettings
    {
        public JwtConfig JWT { get; set; }
    }
}
