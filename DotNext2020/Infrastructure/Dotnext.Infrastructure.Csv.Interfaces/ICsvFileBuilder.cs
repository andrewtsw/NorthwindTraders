using System.Collections.Generic;

namespace Dotnext.Infrastructure.Csv.Interfaces
{
    public interface ICsvFileBuilder
    {
        byte[] BuildProductsFile(IEnumerable<ProductRecordDto> records);
    }
}
