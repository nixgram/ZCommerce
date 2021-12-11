using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Controllers.Common;
using Application.Common.Interfaces;
using Application.Invoices.Commands;
using Application.Invoices.Queries;
using Application.Invoices.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.v1
{
    [Authorize(Roles = "Consumer")]
    public class InvoiceController : ApiBaseControllerV1
    {
        private readonly ICurrentUserService _currentUserService;

        public InvoiceController(ICurrentUserService currentUserService)
        {
            _currentUserService = currentUserService;
        }

        [HttpPost, ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<int>> Create(CreateInvoiceCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpGet, ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IList<InvoiceVm>> Get()
        {
            return await Mediator.Send(new GetUserInvoicesQuery {UserId = _currentUserService.UserId});
        }
    }
}