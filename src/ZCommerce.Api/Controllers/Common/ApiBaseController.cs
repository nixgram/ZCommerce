using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace ZCommerce.Api.Controllers.Common
{
    [ApiController, Route("api/v1/[controller]")]
    public class ApiBaseController : ControllerBase
    {
        // ReSharper disable once UnassignedField.Global
#pragma warning disable 649
        private IMediator _mediator;
#pragma warning restore 649

        protected IMediator Mediator => _mediator ?? HttpContext.RequestServices.GetService<IMediator>();
    }
}