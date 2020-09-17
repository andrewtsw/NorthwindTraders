using System.Threading;
using System.Threading.Tasks;
using Dotnext.Application.Common.Exceptions;
using Dotnext.Domain.Entities;
using Dotnext.Infrastructure.Interfaces;
using MediatR;

namespace Northwind.Application.Products.Commands.UpdateProduct
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand>
    {
        private readonly INorthwindDbContext _context;

        public UpdateProductCommandHandler(INorthwindDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Products.FindAsync(request.ProductId);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Product), request.ProductId);
            }

            entity.ProductId = request.ProductId;
            entity.ProductName = request.Dto.ProductName;
            entity.CategoryId = request.Dto.CategoryId;
            entity.SupplierId = request.Dto.SupplierId;
            entity.UnitPrice = request.Dto.UnitPrice;
            entity.Discontinued = request.Dto.Discontinued;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
