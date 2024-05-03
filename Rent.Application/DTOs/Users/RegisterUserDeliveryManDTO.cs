namespace Rent.Application.DTOs.Users
{
    public class RegisterUserDeliveryManDTO
    {
        public RegisterUserDeliveryManDTO()
        {
            
        }

        public RegisterUserDeliveryManDTO(string name, string email, string password)
        {
            Name = name;
            Email = email;
            Password = password;
        }

        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

    }
}
