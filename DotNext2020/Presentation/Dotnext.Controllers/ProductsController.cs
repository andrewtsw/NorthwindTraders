using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Dotnext.Application.Products.Queries.GetProductsList;
using Dotnext.Application.Products.Queries.GetProductDetail;
using Dotnext.Application.Products.Commands.CreateProduct;
using Dotnext.Application.Products.Commands.UpdateProduct;
using Dotnext.Application.Products.Commands.DeleteProduct;
using Dotnext.Application.Products.Queries.GetProductsFile;
using Dotnext.Application.Products.Commands.Common;

namespace Dotnext.Controllers
{
    [Authorize]
    public class ProductsController : BaseController
    {
        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<ProductsListVm>> GetAll()
        {
            var vm = await Mediator.Send(new GetProductsListQuery());

            return base.Ok(vm);
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<ProductDetailVm>> Get(int id)
        {
            var vm = await Mediator.Send(new GetProductDetailQuery { Id = id });

            return base.Ok(vm);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create([FromBody] EditProductDto dto)
        {
            var productId = await Mediator.Send(new CreateProductCommand { Dto = dto });

            return Ok(productId);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Update(int id, [FromBody] EditProductDto dto)
        {
            await Mediator.Send(new UpdateProductCommand { ProductId = id, Dto = dto });

            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Delete(int id)
        {
            await Mediator.Send(new DeleteProductCommand { Id = id });

            return NoContent();
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<FileResult> Download()
        {
            var vm = await Mediator.Send(new GetProductsFileQuery());

            return File(vm.Content, vm.ContentType, vm.FileName);
        }
    }
}