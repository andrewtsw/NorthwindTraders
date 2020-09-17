using CsvHelper.Configuration;
using Dotnext.Infrastructure.Csv.Interfaces;
using System.Globalization;

namespace Dotnext.Infrastructure.Csv.Implementation
{
    public sealed class ProductFileRecordMap : ClassMap<ProductRecordDto>
    {
        public ProductFileRecordMap()
        {
            AutoMap(CultureInfo.InvariantCulture);
            Map(m => m.UnitPrice).Name("Unit Price").ConvertUsing(c => (c.UnitPrice ?? 0).ToString("C"));
        }
    }
}
