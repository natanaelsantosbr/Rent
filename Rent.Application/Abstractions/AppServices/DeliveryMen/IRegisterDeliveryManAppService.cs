﻿using Rent.Application.DTOs.DeliveryMen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rent.Application.Abstractions.AppServices.DeliveryMen
{
    public interface IRegisterDeliveryManAppService : IAppService
    {
        Task<bool> RegisterDeliveryManAsync(RegisterDeliveryManDTO dto);
    }
}
