using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Moq;
using Xunit;
using ZCommerce.Application.Common.Interfaces;
using ZCommerce.Application.Invoices.Commands;
using ZCommerce.Application.Invoices.ViewModels;
using ZCommerce.Domain.Entities;
using ZCommerce.Domain.Enums;

namespace ZCommerce.Application.Tests.Invoices.Handlers
{
    public class CreateInvoiceCommandHandlerTest
    {
        private readonly Mock<IApplicationContext> _context = new();
        private readonly Mock<IMapper> _mapper = new();
        private readonly IMediator _mediator;

        public CreateInvoiceCommandHandlerTest(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Fact]
        public async Task CreateInvoice_WithValidObject_ReturnInvoiceId()
        {
            _mapper.Setup(opt => opt.Map<Invoice>(It.IsAny<CreateInvoiceCommand>())).Returns((Invoice) default);
            _context.Setup(opt => opt.Invoices.AddAsync(It.IsAny<Invoice>(), default));
            _context.Setup(opt => opt.SaveChangesAsync(default)).ReturnsAsync(1);
            var mediatR = new Mock<IMediator>();
            mediatR.Setup(opt => opt.Send(It.IsAny<CreateInvoiceCommand>(), default)).ReturnsAsync(1);
            var result = await mediatR.Object.Send(GetValidInvoiceCommand());
            Assert.IsType<int>(result);
        }

        [Fact]
        public async Task CreateInvoice_WithInValidObject_ThrowException()
        {
            _mapper.Setup(opt => opt.Map<Invoice>(It.IsAny<CreateInvoiceCommand>())).Returns((Invoice) default);
            _context.Setup(opt => opt.Invoices.AddAsync(It.IsAny<Invoice>(), default));
            _context.Setup(opt => opt.SaveChangesAsync(default)).ReturnsAsync(-1);
            var mediatR = new Mock<IMediator>();
            mediatR.Setup(opt => opt.Send(It.IsAny<CreateInvoiceCommand>(), default))
                .ThrowsAsync(new Exception("Invalid Exception"));

            await Assert.ThrowsAsync<Exception>(() => mediatR.Object.Send(GetInvalidInvoiceCommand()));
        }
        

        private static CreateInvoiceCommand GetValidInvoiceCommand()
        {
            return new CreateInvoiceCommand
            {
                Date = DateTime.Now,
                Discount = 10,
                From = "Dhaka",
                To = "Dhaka",
                Logo = "logo.png",
                Tax = 10,
                AmountPaid = 100,
                DiscountType = DiscountType.Flat,
                DueDate = null,
                InvoiceItems = new List<InvoiceItemVm>()
                {
                    new() {Id = 0, Item = "Napa", Quantity = 4, Rate = 5}
                },
                InvoiceNumber = "12345678",
                PaymentTerms = "None",
                TaxType = TaxType.Flat
            };
        }

        private static CreateInvoiceCommand GetInvalidInvoiceCommand()
        {
            return new CreateInvoiceCommand
            {
                Discount = -10,
                From = "Dhaka",
                To = "D",
                Logo = "logo.png",
                Tax = -10,
                AmountPaid = -100,
                DiscountType = DiscountType.Flat,
                DueDate = null,
                InvoiceItems = new List<InvoiceItemVm>()
                {
                    new() {Id = 0, Item = "Napa", Quantity = 4, Rate = 5}
                },
                InvoiceNumber = "12345678",
                PaymentTerms = "None",
                TaxType = TaxType.Flat
            };
        }
    }
}