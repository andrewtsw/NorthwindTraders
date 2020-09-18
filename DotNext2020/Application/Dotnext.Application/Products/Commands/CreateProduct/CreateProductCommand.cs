using Dotnext.Application.Products.Commands.Common;
using MediatR;

namespace Dotnext.Application.Products.Commands.CreateProduct
{
    public class CreateProductCommand : IRequest<int>
    {
        public EditProductDto Dto { get; set; }
    }
}
