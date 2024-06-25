using FluentValidation;
using Inventory.Shared.Model;

namespace Inventory.Shared.Model
{
    public class PurchaseDetailsValidator : AbstractValidator<PurchaseDetails>
    {
        public PurchaseDetailsValidator()
        {
            CascadeMode = CascadeMode.Stop;
        }
    }
}