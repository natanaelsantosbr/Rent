using Rent.Domain.Entities.DeliveryMen;

namespace Rent.API.DTOs
{
    public class CreateRegisterDeliveryManDTO
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string CNPJ { get; set; }
        public DateTime BirthDate { get; set; }
        public string CNH { get; set; }
        public CNHTypeEnum TypeCNH { get; set; }
        public IFormFile File { get; set; }
    }
}
