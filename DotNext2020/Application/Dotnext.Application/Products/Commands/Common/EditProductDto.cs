namespace Dotnext.Application.Products.Commands.Common
{
    public class EditProductDto
    {
        public string ProductName { get; set; }

        public decimal? UnitPrice { get; set; }

        public int? SupplierId { get; set; }

        public int? CategoryId { get; set; }

        public bool Discontinued { get; set; }
    }
}
