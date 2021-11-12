using System.Linq;
using Application.Invoices.Commands;
using FluentValidation;

namespace Application.Invoices.Validators
{
    public class CreateInvoiceCommandValidator : AbstractValidator<CreateInvoiceCommand>
    {
        public CreateInvoiceCommandValidator()
        {
            RuleFor(m => m.AmountPaid).NotNull().Must(m => m >= 0).WithMessage("Paid Cannot be negative number");
            RuleFor(m => m.Date).NotNull();
            RuleFor(m => m.From).NotEmpty().MinimumLength(3);
            RuleFor(m => m.To).NotEmpty().MinimumLength(3);
            RuleFor(m => m.InvoiceItems).SetValidator(new InvoiceItemValidator());
            RuleFor(m => m.Discount).NotNull().Must(m => m >= 0);
            RuleFor(m => m.Tax).NotNull().Must(m => m >= 0);
        }
    }
}