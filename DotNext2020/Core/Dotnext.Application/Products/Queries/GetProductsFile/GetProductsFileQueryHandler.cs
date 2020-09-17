using Dotnext.Common;
using Dotnext.Infrastructure.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Northwind.Application.Products.Queries.GetProductsFile
{
    public class GetProductsFileQueryHandler : IRequestHandler<GetProductsFileQuery, ProductsFileVm>
    {
        private readonly INorthwindDbContext _context;
        private readonly ICsvFileBuilder _fileBuilder;
        private readonly IDateTime _dateTime;

        public GetProductsFileQueryHandler(INorthwindDbContext context, ICsvFileBuilder fileBuilder, IDateTime dateTime)
        {
            _context = context;
            _fileBuilder = fileBuilder;
            _dateTime = dateTime;
        }

        public async Task<ProductsFileVm> Handle(GetProductsFileQuery request, CancellationToken cancellationToken)
        {
            var records = await _context.Products
                .Include(p => p.Category)
                .Select(p => new ProductRecordDto
                {
                    Name = p.ProductName,
                    Category = p.Category.CategoryName,
                    Discontinued = p.Discontinued,
                    UnitPrice = p.UnitPrice
                })
                .ToListAsync(cancellationToken);

            var fileContent = _fileBuilder.BuildProductsFile(records);

            var vm = new ProductsFileVm
            {
                Content = fileContent,
                ContentType = "text/csv",
                FileName = $"{_dateTime.Now:yyyy-MM-dd}-Products.csv"
            };

            return vm;
        }
    }
}
