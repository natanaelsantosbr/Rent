namespace Rent.Application.Abstractions.AppServices.MotorycleRentals
{
    public interface ICalculateReturnCostAppService : IAppService
    {
        Task<decimal> CalculeReturnCostAsync(Guid rentalId, DateTime returnDate);
    }
}
