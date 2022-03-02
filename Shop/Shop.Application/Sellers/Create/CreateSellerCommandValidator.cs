using Common.Application.Validation;
using Common.Application.Validation.FluentValidations;
using FluentValidation;

namespace Shop.Application.Sellers.Create
{
    public class CreateSellerCommandValidator:AbstractValidator<CreateSellerCommand>
    {
        public CreateSellerCommandValidator()
        {
            RuleFor(r => r.ShopName)
                .NotNull().NotEmpty().WithMessage(ValidationMessages.required("نام فروشگاه"));

            RuleFor(r => r.NationalCode)
                .NotNull().NotEmpty().WithMessage(ValidationMessages.required("کد ملی"))
                .ValidNationalId();
        }
    }
}