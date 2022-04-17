using FluentValidation;

namespace Shop.Application.Sellers.AddInventory
{
    public class AddSellerInventoryCommandValidator : AbstractValidator<AddSellerInventoryCommand>
    {
        public AddSellerInventoryCommandValidator()
        {
            RuleFor(r => r.Count)
                .GreaterThanOrEqualTo(1)
                .WithMessage("تعداد باید بیشتر از 0 بشد!");

            RuleFor(r => r.Price)
                .GreaterThanOrEqualTo(1)
                .WithMessage("قیمت باید بیشتر از 0 بشد!");

        }
    }
}