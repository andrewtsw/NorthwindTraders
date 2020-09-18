using Dotnext.Domain.Entities;

namespace Dotnext.DomainServices
{
    public interface IOrdersService
    {
        decimal CalculateTotalPrice(Order order);

        decimal CalculateDiscount(Order order);

        decimal CalculateTax(Order order);
    }
}
