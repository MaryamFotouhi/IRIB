using Common.Application;
using Microsoft.AspNetCore.Http;
using Shop.Domain.UserAgg.Enums;

namespace Shop.Application.Users.Edit
{
    public class EditUserCommand:IBaseCommand
    {
        
        public long Id { get; private set; }
        public IFormFile Avatar { get; private set; }
        public string Name { get; private set; }
        public string Family { get; private set; }
        public string PhoneNumber { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public Gender Gender { get; private set; }

        public EditUserCommand(long id, IFormFile avatar, string name, string family, string phoneNumber, string email, string password, Gender gender)
        {
            Id = id;
            Avatar = avatar;
            Name = name;
            Family = family;
            PhoneNumber = phoneNumber;
            Email = email;
            Password = password;
            Gender = gender;
        }
    }
}