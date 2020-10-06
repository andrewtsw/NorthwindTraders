using Dotnext.Application.Common.Exceptions;
using Dotnext.Domain.Entities;
using Dotnext.Domain.Services.Interfaces;
using Dotnext.Infrastructure.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Dotnext.Application.Orders.Queries.GetQueryById
{
    internal class GetOrderTotalQueryHandler : IRequestHandler<GetOrderTotalQuery, decimal>
    {
        private readonly INorthwindDbContext _context;
        private readonly IOrdersService _ordersService;

        public GetOrderTotalQueryHandler(INorthwindDbContext context, IOrdersService ordersService)
        {
            _context = context;
            _ordersService = ordersService;
        }

        public async Task<decimal> Handle(GetOrderTotalQuery request, CancellationToken cancellationToken)
        {
            var order = await _context.Orders
                .Include(o => o.OrderDetails)
                .FirstOrDefaultAsync(o => o.OrderId == request.Id, cancellationToken);

            if (order == null)
            {
                throw new NotFoundException(nameof(Order), request.Id);
            }

            // Domain model
            // return order.CalculateTotalPrice();

            // Anemic moder
            return _ordersService.CalculateTotalPrice(order);
        }
    }
}
