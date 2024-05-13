namespace Rent.API.Extensions
{
    public static class FormFileExtensions
    {
        public static byte[] ToByteArray(this IFormFile file)
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                file.CopyTo(memoryStream);
                return memoryStream.ToArray();
            }
        }
    }
}
