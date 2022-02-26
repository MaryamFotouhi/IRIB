using Common.Application.Validation;
using Common.Application.Validation.FluentValidations;
using FluentValidation;

namespace Shop.Application.Orders.Checkout
{
    public class CheckoutOrderCommandValidator:AbstractValidator<CheckoutOrderCommand>
    {
        public CheckoutOrderCommandValidator()
        {
            RuleFor(r => r.Name)
                .NotNull().NotEmpty().WithMessage(ValidationMessages.required("نام"));

            RuleFor(r => r.Family)
                .NotNull().NotEmpty().WithMessage(ValidationMessages.required("نام خانوادگی"));

            RuleFor(r => r.Shire)
                .NotNull().NotEmpty().WithMessage(ValidationMessages.required("استان"));

            RuleFor(r => r.City)
                .NotNull().NotEmpty().WithMessage(ValidationMessages.required("شهر"));

            RuleFor(r => r.PhoneNumber)
                .NotNull().NotEmpty().WithMessage(ValidationMessages.required("شماره موبایل"))
                .MinimumLength(11).WithMessage("شماره موبایل نامعتبر است!")
                .MaximumLength(11).WithMessage("شماره موبایل نامعتبر است!");

            RuleFor(r => r.NationalCode)
                .NotNull().NotEmpty().WithMessage(ValidationMessages.required("کد ملی"))
                .MinimumLength(11).WithMessage("کد ملی نامعتبر است!")
                .MaximumLength(11).WithMessage("کد ملی نامعتبر است!")
                .ValidNationalId();

            RuleFor(r => r.PostalCode)
                .NotNull().NotEmpty().WithMessage(ValidationMessages.required("کد پستی"));
        }
    }
}