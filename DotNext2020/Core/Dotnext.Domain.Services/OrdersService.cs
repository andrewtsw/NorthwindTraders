using Dotnext.Domain.Services.Interfaces;
using Dotnext.Domain.Entities;
using System.Linq;

namespace Dotnext.Domain.Services
{
    internal class OrdersService : IOrdersService
    {
        public decimal CalculateTotalPrice(Order order)
        {
            var subTotal = order.OrderDetails.Sum(x => x.UnitPrice * x.Quantity);
            var discount = CalculateDiscount(order);
            var tax = CalculateTax(order);
            return subTotal - discount + tax;
        }

        public decimal CalculateDiscount(Order order)
        {
            // TODO:
            return 0;
        }

        public decimal CalculateTax(Order order)
        {
            // TODO:
            return 0;
        }
    }
}
