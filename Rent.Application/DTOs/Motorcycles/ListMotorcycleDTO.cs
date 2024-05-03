namespace Rent.Application.DTOs.Motorcycles
{
    public class ListMotorcycleDTO
    {
        public ListMotorcycleDTO()
        {
            
        }

        public Guid Id { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public string LicensePlate { get; set; }
    }
}
