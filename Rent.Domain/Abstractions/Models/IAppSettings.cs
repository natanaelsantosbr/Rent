using Rent.Domain.Models.ValueObjects.Settings;

namespace Rent.Domain.Abstractions.Models
{
    public interface IAppSettings
    {
        public JwtConfig JWT { get; set; }

        public string PathImageCNH { get; set; }

        public RabbitMqConfig RabbitMq { get; set; }
    }
}
