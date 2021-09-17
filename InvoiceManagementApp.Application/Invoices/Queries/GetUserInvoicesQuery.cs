using System.Collections.Generic;
using InvoiceManagementApp.Application.Invoices.ViewModels;
using MediatR;

namespace InvoiceManagementApp.Application.Invoices.Queries
{
    public class GetUserInvoicesQuery : IRequest<IList<InvoiceVm>>
    {
        public string UserId { get; set; }
    }
}