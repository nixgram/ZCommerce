using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ZCommerce.Api.Controllers.Common;
using ZCommerce.Application.Common.Interfaces;
using ZCommerce.Application.ProductCategory.Commands;
using ZCommerce.Application.ProductCategory.Queries;
using ZCommerce.Application.ProductCategory.ViewModel;

namespace ZCommerce.Api.Controllers
{
    [Authorize]
    public class ProductCategoryController : ApiBaseController
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