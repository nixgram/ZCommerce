using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.ProductCategory.Commands
{
    public class UpdateProductCategoryCommand : IRequest<bool>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public string LogoUrl { get; set; }
        public string Description { get; set; }
    }


    public class UpdateProductCategoryCommandHandler : IRequestHandler<UpdateProductCategoryCommand, bool>
    {
        private readonly ICurrentUserService _userService;
        private readonly IApplicationContext _context;
        private readonly IMapper _mapper;

        public UpdateProductCategoryCommandHandler(ICurrentUserService userService, IApplicationContext context,
            IMapper mapper)
        {
            _userService = userService;
            _context = context;
            _mapper = mapper;
        }

        public async Task<bool> Handle(UpdateProductCategoryCommand request, CancellationToken cancellationToken)
        {
            var isRequestedProductCategoryFoundAndValid =
                await _context.ProductCategories.FirstOrDefaultAsync(p =>
                    p.CreatedBy == _userService.UserId && p.Id == request.Id, cancellationToken);

            if (isRequestedProductCategoryFoundAndValid is null) return false;
            
            // TODO : Need to think about it to reduce this kind of hard mapping
            isRequestedProductCategoryFoundAndValid.Description = request.Description;
            isRequestedProductCategoryFoundAndValid.Name = request.Name;
            isRequestedProductCategoryFoundAndValid.ImageUrl = request.ImageUrl;
            isRequestedProductCategoryFoundAndValid.LogoUrl = request.LogoUrl;
            
            _context.ProductCategories.Update(isRequestedProductCategoryFoundAndValid);
            return await _context.SaveChangesAsync(cancellationToken) > 0;
        }
    }
}