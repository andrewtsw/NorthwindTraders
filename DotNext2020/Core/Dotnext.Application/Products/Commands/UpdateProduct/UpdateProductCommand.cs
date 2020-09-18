using Dotnext.Application.Products.Commands.Common;
using MediatR;

namespace Dotnext.Application.Products.Commands.UpdateProduct
{
    public class UpdateProductCommand : IRequest
    {
        public int ProductId { get; set; }

        public EditProductDto Dto { get; set; }
    }
}
