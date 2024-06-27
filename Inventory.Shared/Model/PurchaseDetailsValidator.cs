using FluentValidation;
using Inventory.Shared.Model;

namespace Inventory.Shared.Model
{
    public class PurchaseDetailsValidator : AbstractValidator<PurchaseDetailsViewModel>
    {
        public PurchaseDetailsValidator()
        {
            CascadeMode = CascadeMode.Stop;
        }
    }
}