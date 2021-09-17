using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using InvoiceManagementApp.Application.Common.Interfaces;
using InvoiceManagementApp.Application.Invoices.Queries;
using InvoiceManagementApp.Application.Invoices.ViewModels;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace InvoiceManagementApp.Application.Invoices.Handlers
{
    public class GetUserInvoicesQueryHandler : IRequestHandler<GetUserInvoicesQuery, IList<InvoiceVm>>
    {
        private readonly IApplicationContext _context;
        private readonly IMapper _mapper;

        public GetUserInvoicesQueryHandler(IApplicationContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public async Task<IList<InvoiceVm>> Handle(GetUserInvoicesQuery request, CancellationToken cancellationToken)
        {
            var result = new List<InvoiceVm>();

            var invoices = await _context.Invoices.Include(i => i.InvoiceItems)
                .Where(i => i.CreatedBy == request.UserId).ToListAsync(cancellationToken);
            if (invoices != null)
            {
                result = _mapper.Map<List<InvoiceVm>>(invoices);
            }
            return result;
        }
    }
}