using Dotnext.Domain.Entities;
using Dotnext.Infrastructure.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Dotnext.Application.Products.Commands.CreateProduct
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, int>
    {
        private readonly INorthwindDbContext _context;

        public CreateProductCommandHandler(INorthwindDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            //TODO: Map Dto to Product Entity
            var entity = new Product
            {
                ProductName = request.Dto.ProductName,
                CategoryId = request.Dto.CategoryId,
                SupplierId = request.Dto.SupplierId,
                UnitPrice = request.Dto.UnitPrice,
                Discontinued = request.Dto.Discontinued
            };

            _context.Products.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return entity.ProductId;
        }
    }
}
