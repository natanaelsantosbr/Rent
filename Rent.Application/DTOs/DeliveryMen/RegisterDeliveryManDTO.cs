using Rent.Domain.Entities.DeliveryMen;

namespace Rent.Application.DTOs.DeliveryMen
{
    public class RegisterDeliveryManDTO
    {
        public RegisterDeliveryManDTO()
        {
            
        }
        public RegisterDeliveryManDTO(string name, string email, string password, string cNPJ, DateTime birthDate, string cNH, CNHTypeEnum typeCNH, byte[] imageCNH)
        {
            Name = name;
            Email = email;
            Password = password;
            CNPJ = cNPJ;
            BirthDate = birthDate;
            CNH = cNH;
            TypeCNH = typeCNH;
            ImageCNH = imageCNH;
        }

        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string CNPJ { get; set; }
        public DateTime BirthDate { get; set; }
        public string CNH { get; set; }
        public CNHTypeEnum TypeCNH { get; set; }
        public byte[] ImageCNH { get; set; }
    }
}
