using FluentValidation;

namespace Shop.Application.Orders.AddOrderItem
{
    public class AddOrderItemCommandValidator : AbstractValidator<AddOrderItemCommand>
    {
        public AddOrderItemCommandValidator()
        {
            RuleFor(r => r.Count)
                .GreaterThanOrEqualTo(1)
                .WithMessage("تعداد باید بیشتر از 0 بشد!");
        }
    }
}