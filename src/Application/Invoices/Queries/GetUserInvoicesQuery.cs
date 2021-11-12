using System.Collections.Generic;
using Application.Invoices.ViewModels;
using MediatR;

namespace Application.Invoices.Queries
{
    public class GetUserInvoicesQuery : IRequest<IList<InvoiceVm>>
    {
        public string UserId { get; set; }
    }
}