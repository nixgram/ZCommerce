using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ZCommerce.Application.Common.Interfaces;
using ZCommerce.Application.ProductCategory.ViewModel;

namespace ZCommerce.Application.ProductCategory.Queries
{
    public class GetProductCategoryQuery : IRequest<IEnumerable<ProductCategoryVm>>
    {
        // TODO : Rest of the pagination / filter stuff will be here for non-user
        public string UserId { get; set; }

        public GetProductCategoryQuery(string userId) => UserId = userId;
    }

    public class
        GetProductCategoryQueryHandler : IRequestHandler<GetProductCategoryQuery, IEnumerable<ProductCategoryVm>>
    {
        private readonly IApplicationContext _context;
        private readonly IMapper _mapper;

        public GetProductCategoryQueryHandler(IApplicationContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductCategoryVm>> Handle(GetProductCategoryQuery request,
            CancellationToken cancellationToken)
        {
            var productCategories = await _context.ProductCategories.Where(p => p.CreatedBy == request.UserId)
                .ToListAsync(cancellationToken);
            return _mapper.Map<List<ProductCategoryVm>>(productCategories);
        }
    }
}