using AutoMapper;
using AutoMapper.QueryableExtensions;
using Dotnext.Application.Common.Exceptions;
using Dotnext.Domain.Entities;
using Dotnext.Infrastructure.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Dotnext.Application.Products.Queries.GetProductDetail
{
    internal class GetProductDetailQueryHandler : IRequestHandler<GetProductDetailQuery, ProductDetailVm>
    {
        private readonly INorthwindDbContext _context;
        private readonly IMapper _mapper;

        public GetProductDetailQueryHandler(INorthwindDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ProductDetailVm> Handle(GetProductDetailQuery request, CancellationToken cancellationToken)
        {
            var vm = await _context.Products
                .ProjectTo<ProductDetailVm>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(p => p.ProductId == request.Id, cancellationToken);

            if (vm == null)
            {
                throw new NotFoundException(nameof(Product), request.Id);
            }

            return vm;
        }
    }
}
