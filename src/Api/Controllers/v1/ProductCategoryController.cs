using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Controllers.Common;
using Application.Common.Interfaces;
using Application.ProductCategory.Commands;
using Application.ProductCategory.Queries;
using Application.ProductCategory.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.v1
{
    [Authorize]
    public class ProductCategoryController : ApiBaseControllerV1
    {
        private readonly ICurrentUserService _currentUserService;

        public ProductCategoryController(ICurrentUserService currentUserService)
        {
            _currentUserService = currentUserService;
        }

        [HttpPost]
        public async Task<int> Create(CreateProductCategoryCommand command)
            => await Mediator.Send(command);

        [HttpGet]
        public async Task<IEnumerable<ProductCategoryVm>> Get() =>
            await Mediator.Send(new GetProductCategoryQuery(_currentUserService.UserId));

        [HttpPut]
        public async Task<bool> Update(UpdateProductCategoryCommand command) => await Mediator.Send(command);

        [AllowAnonymous]
        [HttpGet("all")]
        public async Task<IEnumerable<ProductCategoryVm>> All() =>
            await Mediator.Send(new GetAllProductCategoryCommand());
    }
}