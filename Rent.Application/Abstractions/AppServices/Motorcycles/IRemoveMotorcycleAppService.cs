﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rent.Application.Abstractions.AppServices.Motorcycles
{
    public interface IRemoveMotorcycleAppService : IAppService
    {
        Task RemoveAsync(Guid motorcycleId);
    }
}