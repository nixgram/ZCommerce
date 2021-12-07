using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Application.Product.ViewModels;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Product.Queries
{
    public class GetAllProductsQuery : IRequest<List<ProductVm>>
    {
        public string UserId { get; set; }
    }


    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, List<ProductVm>>
    {
        private readonly IApplicationContext _context;
        private readonly IMapper _mapper;

        public GetAllProductsQueryHandler(IApplicationContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public async Task<List<ProductVm>> Handle(GetAllProductsQuery request,
            CancellationToken cancellationToken)
        {
            var productList = await _context.Products.Where(d => d.CreatedBy == request.UserId).AsQueryable()
                .ToListAsync(cancellationToken);

            var productVms = _mapper.Map<List<ProductVm>>(productList);
            return productVms;
        }
    }
}