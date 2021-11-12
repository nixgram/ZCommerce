using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Application.ProductCategory.ViewModel;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.ProductCategory.Commands
{
    public class GetAllProductCategoryCommand : IRequest<IEnumerable<ProductCategoryVm>>
    {
        // TODO : Rest of the pagination / filter stuff will be here for non-user
    }

    public class
        GetAllProductCategoryCommandHandler : IRequestHandler<GetAllProductCategoryCommand,
            IEnumerable<ProductCategoryVm>>
    {
        private readonly IApplicationContext _context;
        private readonly IMapper _mapper;

        public GetAllProductCategoryCommandHandler(IApplicationContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductCategoryVm>> Handle(GetAllProductCategoryCommand request,
            CancellationToken cancellationToken)
        {
            var all = await _context.ProductCategories.ToListAsync(cancellationToken);
            return _mapper.Map<IEnumerable<ProductCategoryVm>>(all);
        }
    }
}