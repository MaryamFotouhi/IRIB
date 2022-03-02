using Common.Application.Validation;
using Common.Application.Validation.FluentValidations;
using FluentValidation;

namespace Shop.Application.Users.Edit
{
    public class EditUserCommandValidator:AbstractValidator<EditUserCommand>
    {
        public EditUserCommandValidator()
        {
            RuleFor(r => r.Avatar)
                .JustImageFile();

            RuleFor(r => r.PhoneNumber)
                .NotNull().NotEmpty().WithMessage(ValidationMessages.required("شماره تلفن"))
                .ValidPhoneNumber();

            RuleFor(r => r.Email)
                .EmailAddress().WithMessage("ایمیل نامعتبر است!");
        }
    }
}