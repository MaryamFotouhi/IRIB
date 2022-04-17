using Common.Application.Validation;
using FluentValidation;

namespace Shop.Application.Users.ChargeWallet
{
    public class ChargeUserWalletCommandValidator : AbstractValidator<ChargeUserWalletCommand>
    {
        public ChargeUserWalletCommandValidator()
        {
            RuleFor(r => r.Description)
                .NotNull()
                .NotEmpty()
                .WithMessage(ValidationMessages.required("توضیحات"));

            RuleFor(r => r.Price)
                .NotNull()
                .NotEmpty()
                .WithMessage(ValidationMessages.required("قیمت"))
                .GreaterThanOrEqualTo(1000)
                .WithMessage("شارژ باید بیشتر از 1000 تومان باشد!");
        }
    }
}