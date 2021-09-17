using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using ZCommerce.Application.Common.Interfaces;
using ZCommerce.Application.Invoices.Commands;
using ZCommerce.Domain.Entities;

namespace ZCommerce.Application.Invoices.Handlers
{
    public class CreateInvoiceCommandHandler : IRequestHandler<CreateInvoiceCommand, int>
    {
        private readonly IApplicationContext _context;
        private readonly IMapper _mapper;

        public CreateInvoiceCommandHandler(IApplicationContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateInvoiceCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Invoice>(request);
            await _context.Invoices.AddAsync(entity, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return entity.Id;
        }
    }
}