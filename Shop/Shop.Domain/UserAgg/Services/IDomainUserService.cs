namespace Shop.Domain.UserAgg.Services
{
    public interface IDomainUserService
    {
        bool EmailIsExist(string email);
        bool PhoneNumberIsExist(string phoneNumber);
    }
}
