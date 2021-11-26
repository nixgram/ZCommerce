using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Application.Product.ViewModels;
using AutoMapper;
using MediatR;

namespace Application.Product.Commands
{
    public class CreateProductCommand : IRequest<ProductVm>
    {
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
        public string Sku { get; set; }
        public decimal Price { get; set; }
        public IList<AdditionalInformationVm> AdditionalInformations { get; set; }
        public int ProductCategoryId { get; set; }
    }

    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, ProductVm>
    {
        private readonly IApplicationContext _context;
        private readonly IMapper _mapper;

        public CreateProductCommandHandler(IApplicationContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ProductVm> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = _mapper.Map<Domain.Entities.Product.Product>(request);
            await _context.Products.AddAsync(product, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return _mapper.Map<ProductVm>(product);
        }
    }
}