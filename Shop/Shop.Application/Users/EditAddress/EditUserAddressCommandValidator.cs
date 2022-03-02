using Common.Application.Validation;
using Common.Application.Validation.FluentValidations;
using FluentValidation;

namespace Shop.Application.Users.EditAddress
{
    public class EditUserAddressCommandValidator:AbstractValidator<EditUserAddressCommand>
    {
        public EditUserAddressCommandValidator()
        {
            RuleFor(r => r.City)
                .NotNull().NotEmpty().WithMessage(ValidationMessages.required("شهر"));

            RuleFor(r => r.Shire)
                .NotNull().NotEmpty().WithMessage(ValidationMessages.required("استان"));

            RuleFor(r => r.Name)
                .NotNull().NotEmpty().WithMessage(ValidationMessages.required("نام"));

            RuleFor(r => r.Family)
                .NotNull().NotEmpty().WithMessage(ValidationMessages.required("نام خانوادگی"));

            RuleFor(r => r.NationalCode)
                .NotNull().NotEmpty().WithMessage(ValidationMessages.required("کد ملی"))
                .ValidNationalId();

            RuleFor(r => r.PostalAddress)
                .NotNull().NotEmpty().WithMessage(ValidationMessages.required("آدر پستی"));

            RuleFor(r => r.PostalCode)
                .NotNull().NotEmpty().WithMessage(ValidationMessages.required("کد پستی"));
        }
    }
}