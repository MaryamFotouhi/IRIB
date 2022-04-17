using Common.Application.Validation;
using FluentValidation;

namespace Shop.Application.Users.Register
{
    public class RegisterUserCommandValidator:AbstractValidator<RegisterUserCommand>
    {
        public RegisterUserCommandValidator()
        {
            RuleFor(r => r.Password)
                .NotNull()
                .NotEmpty()
                .WithMessage(ValidationMessages.required("رمز عبور"))
                .MinimumLength(6)
                .WithMessage("رمز عبور باید حداقل 6 کاراکتر باشد!");

        }
    }
}