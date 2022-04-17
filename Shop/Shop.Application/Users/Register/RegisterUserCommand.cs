using Common.Application;
using Common.Application.Validation.FluentValidations;
using Common.Domain.ValueObjects;

namespace Shop.Application.Users.Register
{
    public class RegisterUserCommand:IBaseCommand
    {
        public PhoneNumber PhoneNumber { get; private set; }
        public string Password { get; private set; }

        public RegisterUserCommand(PhoneNumber phoneNumber, string password)
        {
            PhoneNumber = phoneNumber;
            Password = password;
        }
    }
}