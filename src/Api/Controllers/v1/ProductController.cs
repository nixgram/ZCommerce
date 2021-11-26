using System.Threading.Tasks;
using Api.Controllers.Common;
using Application.Product.Commands;
using Application.Product.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.v1
{
    public class ProductController : ApiBaseControllerV1
    {
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<ProductVm>> Create(CreateProductCommand command)
        {
            return await Mediator.Send(command);
        }
    }
}