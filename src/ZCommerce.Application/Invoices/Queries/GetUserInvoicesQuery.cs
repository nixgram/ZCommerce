using System.Collections.Generic;
using MediatR;
using ZCommerce.Application.Invoices.ViewModels;

namespace ZCommerce.Application.Invoices.Queries
{
    public class GetUserInvoicesQuery : IRequest<IList<InvoiceVm>>
    {
        public string UserId { get; set; }
    }
}