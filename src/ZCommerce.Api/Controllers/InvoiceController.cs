using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ZCommerce.Api.Controllers.Common;
using ZCommerce.Application.Common.Interfaces;
using ZCommerce.Application.Invoices.Commands;
using ZCommerce.Application.Invoices.Queries;
using ZCommerce.Application.Invoices.ViewModels;

namespace ZCommerce.Api.Controllers
{
    [Authorize]
    public class InvoiceController : ApiBaseController
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