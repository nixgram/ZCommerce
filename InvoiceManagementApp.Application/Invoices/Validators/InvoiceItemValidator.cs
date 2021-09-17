using System.Collections.Generic;
using System.Linq;
using FluentValidation.Validators;
using InvoiceManagementApp.Application.Invoices.ViewModels;

namespace InvoiceManagementApp.Application.Invoices.Validators
{
    public class InvoiceItemValidator : PropertyValidator
    {
        public InvoiceItemValidator() : base("Property {PropertyName} should not be an empty list.")
        {
        }

        protected override bool IsValid(PropertyValidatorContext context)
        {
            // ReSharper disable once UsePatternMatching
            var list = context.PropertyValue as List<InvoiceItemVm>;
            return list != null && list.Any();
        }
    }
}