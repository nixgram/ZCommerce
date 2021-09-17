using FluentValidation;
using ZCommerce.Application.Invoices.Commands;

namespace ZCommerce.Application.Invoices.Validators
{
    public class CreateInvoiceCommandValidator : AbstractValidator<CreateInvoiceCommand>
    {

        public CreateInvoiceCommandValidator()
        {
            RuleFor(m => m.AmountPaid).NotNull();
            RuleFor(m => m.Date).NotNull();
            RuleFor(m => m.From).NotEmpty().MinimumLength(3);
            RuleFor(m => m.To).NotEmpty().MinimumLength(3);
            RuleFor(m => m.InvoiceItems).SetValidator(new InvoiceItemValidator());

        }
    }
}