namespace Dotnext.Infrastructure.Csv.Interfaces
{
    public class ProductRecordDto
    {
        public string Category { get; set; }

        public string Name { get; set; }

        public decimal? UnitPrice { get; set; }

        public bool Discontinued { get; set; }
    }
}
