using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using ZCommerce.Application.Common.Interfaces;

namespace ZCommerce.Application.ProductCategory.Commands
{
    public class CreateProductCategoryCommand : IRequest<int>
    {
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public string LogoUrl { get; set; }
        public string Description { get; set; }
    }


    public class CreateProductCategoryCommandHandler : IRequestHandler<CreateProductCategoryCommand, int>
    {
        private readonly IApplicationContext _context;
        private readonly IMapper _mapper;

        public CreateProductCategoryCommandHandler(IApplicationContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateProductCategoryCommand request, CancellationToken cancellationToken)
        {
            var productCategory = _mapper.Map<Domain.Entities.ProductCategory>(request);
            await _context.ProductCategories.AddAsync(productCategory, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return productCategory.Id;
        }
    }
}