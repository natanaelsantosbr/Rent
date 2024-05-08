using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rent.Domain.Events.DeliveryMan
{
    public class CNHImageUploadEvent
    {
        public CNHImageUploadEvent()
        {   
        
        }

        public CNHImageUploadEvent(Guid deliveryMan, byte[] imageData)
        {
            DeliveryMan = deliveryMan;
            ImageData = imageData;
        }

        public Guid DeliveryMan { get; set; }
        public byte[] ImageData { get; set; }
    }
}
