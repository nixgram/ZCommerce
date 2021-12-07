using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Controllers.Common;
using Application.Common.Interfaces;
using Application.Product.Commands;
using Application.Product.Queries;
using Application.Product.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.v1
{
    [Authorize]
    public class ProductController : ApiBaseControllerV1
    {
        private readonly ICurrentUserService _currentUserService;

        public ProductController(ICurrentUserService currentUserService)
        {
            _currentUserService = currentUserService;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<ProductVm>> Create(CreateProductCommand command)
        {
            return await Mediator.Send(command);
        }


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<ProductVm>>> Get()
        {
            return await Mediator.Send(new GetAllProductsQuery {UserId = _currentUserService.UserId});
        }
    }
}