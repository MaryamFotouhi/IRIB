using Common.Application.Validation;
using Common.Application.Validation.FluentValidations;
using FluentValidation;

namespace Shop.Application.Users.Create
{
    public class CreateUserCommandValidator:AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(r => r.PhoneNumber)
                .NotNull().NotEmpty().WithMessage(ValidationMessages.required("شماره تلفن"))
                .ValidPhoneNumber();

            RuleFor(r => r.Email)
                .EmailAddress().WithMessage("ایمیل نامعتبر است!");

            RuleFor(r => r.Password)
                .NotNull().NotEmpty().WithMessage(ValidationMessages.required("رمز عبور"))
                .MinimumLength(4).WithMessage("رمز عبور باید حداقل 4 کاراکتر باشد!");
        }
    }
}