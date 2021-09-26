using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using ZCommerce.Application.Common.cache;
using ZCommerce.Application.Common.Interfaces;
using ZCommerce.Application.Invoices.Queries;
using ZCommerce.Application.Invoices.ViewModels;

namespace ZCommerce.Application.Invoices.Handlers
{
    public class GetUserInvoicesQueryHandler : IRequestHandler<GetUserInvoicesQuery, IList<InvoiceVm>>
    {
        private readonly IApplicationContext _context;
        private readonly IMapper _mapper;
        private readonly IDistributedCache _cache;

        public GetUserInvoicesQueryHandler(IApplicationContext context, IMapper mapper, IDistributedCache cache)
        {
            _context = context;
            _mapper = mapper;
            _cache = cache;
        }


        public async Task<IList<InvoiceVm>> Handle(GetUserInvoicesQuery request, CancellationToken cancellationToken)
        {
            var recordKey = "InvoiceVms_" + DateTime.Now.ToString("yyyyMMdd_hhmm");
            var data = await _cache.GetRecordAsync<IList<InvoiceVm>>(recordKey);
            if (data != null) return data;
            var result = new List<InvoiceVm>();
            var invoices = await _context.Invoices.Include(i => i.InvoiceItems)
                .Where(i => i.CreatedBy == request.UserId).AsNoTracking().ToListAsync(cancellationToken);
            if (invoices == null) return result;
            result = _mapper.Map<List<InvoiceVm>>(invoices);
            await _cache.SetRecordAsync(recordKey, result.ToArray());
            return result;
        }
    }
}