using MediatR;

namespace Dotnext.Application.Orders.Queries.GetQueryById
{
    public class GetOrderTotalQuery : IRequest<decimal>
    {
        public int Id { get; set; }
    }
}
