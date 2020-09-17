using System.Collections.Generic;

namespace Dotnext.Infrastructure.Interfaces
{
    public interface ICsvFileBuilder
    {
        byte[] BuildProductsFile(IEnumerable<ProductRecordDto> records);
    }
}
