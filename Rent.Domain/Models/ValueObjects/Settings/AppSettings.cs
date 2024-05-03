using Rent.Domain.Abstractions.Models;

namespace Rent.Domain.Models.ValueObjects.Settings
{
    public class AppSettings : IAppSettings
    {
        public JwtConfig JWT { get; set; }
        public string PathImageCNH { get; set; }
    }
}
