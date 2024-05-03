using Rent.Domain.Entities.DeliveryMen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rent.Application.DTOs.DeliveryMen
{
    public class RegisterDeliveryManDTO
    {
        public string Name { get; set; }
        public string CNPJ { get; set; }
        public DateTime BirthDate { get; set; }
        public string CNH { get; set; }
        public CNHTypeEnum TypeCNH { get; set; }
        public byte[] CNHImage { get; set; }
    }
}
