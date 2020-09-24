using AutoMapper;
using AutoMapper.QueryableExtensions;
using Dotnext.Application.Services.Interfaces;
using Dotnext.Infrastructure.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Dotnext.Application.Products.Queries.GetProductsList
{
    internal class GetProductsListQueryHandler : IRequestHandler<GetProductsListQuery, ProductsListVm>
    {
        private readonly INorthwindDbContext _context;
        private readonly IMapper _mapper;
        private readonly IPermissionsManager _permissionsManager;

        public GetProductsListQueryHandler(INorthwindDbContext context, IMapper mapper, IPermissionsManager permissionsManager)
        {
            _context = context;
            _mapper = mapper;
            _permissionsManager = permissionsManager;
        }

        public async Task<ProductsListVm> Handle(GetProductsListQuery request, CancellationToken cancellationToken)
        {
            var products = await _context.Products
                .ProjectTo<ProductDto>(_mapper.ConfigurationProvider)
                .OrderBy(p => p.ProductName)
                .ToListAsync(cancellationToken);

            var vm = new ProductsListVm
            {
                Products = products,
                CreateEnabled = true // TODO: Set based on user permissions.
            };

            return vm;
        }
    }
}
