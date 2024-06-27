using FluentValidation;
using Inventory.Shared.Model;

namespace Inventory.Shared.Model
{
    public class PurchaseDetailsValidatorViewmodel : AbstractValidator<PurchaseDetailsViewModel>
    {
        public PurchaseDetailsValidatorViewmodel()
        {
            CascadeMode = CascadeMode.Stop;

            RuleFor(p => p.ItemId).NotEmpty().WithMessage("Item is a required field.");
            RuleFor(p => p.Quantity).NotEmpty().WithMessage("Quantity is a required field.");
            RuleFor(p => p.Price).NotEmpty().WithMessage("Price is a required field.");
        }
    }
}