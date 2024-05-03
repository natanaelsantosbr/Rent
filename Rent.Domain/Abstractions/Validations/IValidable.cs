namespace Rent.Domain.Abstractions.Validations
{
    public interface IValidable
    {
        bool Valid { get; }
        bool Invalid { get; }
        IEnumerable<string> Alerts { get; }
    }
}
