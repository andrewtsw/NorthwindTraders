using Dotnext.Application.Products.Commands.Common;
using MediatR;

namespace Northwind.Application.Products.Commands.UpdateProduct
{
    public class UpdateProductCommand : IRequest
    {
        public int ProductId { get; set; }

        public EditProductDto Dto { get; set; }
    }
}
