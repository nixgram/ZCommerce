using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace ZCommerce.Api.Controllers
{
    [ApiController, Route("api/[controller]")]
    public class ApiController : ControllerBase
    {
        // ReSharper disable once UnassignedField.Global
        public IMediator _mediator;

        protected IMediator Mediator => _mediator ?? HttpContext.RequestServices.GetService<IMediator>();
    }
}