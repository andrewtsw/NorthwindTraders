using Dotnext.Domain.Entities;

namespace Dotnext.Domain.Services.Interfaces
{
    public interface IOrdersService
    {
        decimal CalculateTotalPrice(Order order);

        decimal CalculateDiscount(Order order);

        decimal CalculateTax(Order order);
    }
}
