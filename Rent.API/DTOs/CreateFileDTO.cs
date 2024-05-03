namespace Rent.API.DTOs
{
    public class CreateFileDTO
    {
        public IFormFile File { get; set; }

        public byte[] ConvertFormFileToByteArray(IFormFile file)
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                file.CopyTo(memoryStream);
                return memoryStream.ToArray();
            }
        }
    }
}
