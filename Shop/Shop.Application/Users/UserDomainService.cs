using Shop.Domain.UserAgg.Repository;
using Shop.Domain.UserAgg.Services;

namespace Shop.Application.Users
{
    public class UserDomainService: IUserDomainService
    {
        private readonly IUserRepository _repository;

        public UserDomainService(IUserRepository repository)
        {
            _repository = repository;
        }

        public bool EmailIsExist(string email)
        {
            return _repository.Exists(u => u.Email == email);
        }

        public bool PhoneNumberIsExist(string phoneNumber)
        {
            return _repository.Exists(u => u.PhoneNumber == phoneNumber);
        }
    }
}