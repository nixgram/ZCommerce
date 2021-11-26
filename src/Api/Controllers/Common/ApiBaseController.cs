using Api.Attributes;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace Api.Controllers.Common
{
    [ValidationActionFilter, ApiController, Route("api/v1/[controller]")]
    public class ApiBaseControllerV1 : ControllerBase
    {
        // ReSharper disable once UnassignedField.Global
#pragma warning disable 649
        private IMediator _mediator;
#pragma warning restore 649

        protected IMediator Mediator => _mediator ?? HttpContext.RequestServices.GetService<IMediator>();
    }
}