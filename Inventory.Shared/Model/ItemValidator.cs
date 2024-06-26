using FluentValidation;

namespace Inventory.Shared.Model
{
    public class ItemValidator : AbstractValidator<Item>
    {
        public ItemValidator()
        {
            CascadeMode = CascadeMode.Stop;
            RuleFor(i => i.Name).NotEmpty().WithMessage("Item name is a required field.")
                .Length(3, 50).WithMessage("Item name must be between 3 and 50 characters.");
        }
    }
}