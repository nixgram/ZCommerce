using System.Threading.Tasks;
using Application.Common.Interfaces;
using Application.Product.Commands;
using Application.Product.ViewModels;
using AutoMapper;
using MediatR;
using Moq;
using Xunit;

namespace ZCommerce.Application.Tests.Product.Commands
{
    public class CreateProductCommandTests
    {
        private readonly Mock<IApplicationContext> _context = new();
        private readonly Mock<IMapper> _mapper = new();


        [Fact]
        public async Task CreateProduct_WithValidObject_ReturnProductVm()
        {
            _mapper.Setup(opt => opt.Map<Domain.Entities.Product.Product>(It.IsAny<CreateProductCommand>()))
                .Returns((Domain.Entities.Product.Product) default);

            _context.Setup(opt => opt.Products.AddAsync(It.IsAny<Domain.Entities.Product.Product>(), default));
            _context.Setup(opt => opt.SaveChangesAsync(default)).ReturnsAsync(1);

            var mediatR = new Mock<IMediator>();

            mediatR.Setup(opt => opt.Send(It.IsAny<CreateProductCommand>(), default))
                .ReturnsAsync(new ProductVm {Id = 1});

            var result = await mediatR.Object.Send(new CreateProductCommand());

            Assert.IsType<ProductVm>(result);
            Assert.IsType<long>(result.Id);
            Assert.NotNull(result);
        }
    }
}