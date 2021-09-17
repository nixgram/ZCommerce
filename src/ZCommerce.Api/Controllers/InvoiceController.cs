using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ZCommerce.Application.Common.Interfaces;
using ZCommerce.Application.Invoices.Commands;
using ZCommerce.Application.Invoices.Queries;
using ZCommerce.Application.Invoices.ViewModels;

namespace ZCommerce.Api.Controllers
{
    [Authorize]
    
    public class InvoiceController : ApiController
    {
        private readonly ICurrentUserService _currentUserService;

        public InvoiceController(ICurrentUserService currentUserService)
        {
            _currentUserService = currentUserService;
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateInvoiceCommand command)
        {
            return await Mediator.Send(command);
        }


        [HttpGet]
        public async Task<IList<InvoiceVm>> Get()
        {
            return await Mediator.Send(new GetUserInvoicesQuery {UserId = _currentUserService.UserId});
        }
    }
}