using FluentValidation;
using Inventory.Shared.Model;

namespace Inventory.Shared.Model
{
    public class PurchaseMasterValidator : AbstractValidator<PurchaseMaster>
    {
        public PurchaseMasterValidator()
        {
            CascadeMode = CascadeMode.Stop;
            RuleFor(p => p.InvoiceNo).NotEmpty().WithMessage("Purchase Invoice no. is a required field.")
              .Length(3, 10).WithMessage("First name must be between 3 and 10 characters.");
        }
    }
}