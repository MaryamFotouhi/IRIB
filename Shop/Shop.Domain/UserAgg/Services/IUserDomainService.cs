namespace Shop.Domain.UserAgg.Services
{
    public interface IUserDomainService
    {
        bool EmailIsExist(string email);
        bool PhoneNumberIsExist(string phoneNumber);
    }
}
