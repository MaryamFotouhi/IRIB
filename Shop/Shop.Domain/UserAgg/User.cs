using Common.Domain;
using Common.Domain.Exceptions;
using Shop.Domain.UserAgg.Enums;
using System.Collections.Generic;
using System.Linq;
using Shop.Domain.UserAgg.Services;

namespace Shop.Domain.UserAgg
{
    public class User : AggregateRoot
    {
        public User(string name, string family, string phoneNumber, string email, string password,
            Gender gender, IDomainUserService domainService)
        {
            Guard(phoneNumber, email, domainService);
            Name = name;
            Family = family;
            PhoneNumber = phoneNumber;
            Email = email;
            Password = password;
            Gender = gender;
        }

        public string Name { get; private set; }
        public string Family { get; private set; }
        public string PhoneNumber { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public Gender Gender { get; private set; }
        public List<UserRole> Roles { get; private set; }
        public List<Wallet> Wallets { get; private set; }
        public List<UserAddress> Addresses { get; private set; }

        public static User Register(string phoneNumber, string email, string password, IDomainUserService domainService)
        {
            return new User("", "", phoneNumber, email, password, Enums.Gender.None, domainService);
        }
        public void Edit(string name, string family, string phoneNumber, string email, Gender gender, IDomainUserService domainService)
        {
            Guard(phoneNumber, email, domainService);
            Name = name;
            Family = family;
            PhoneNumber = phoneNumber;
            Email = email;
            Gender = gender;
        }
        public void AddAddress(UserAddress address)
        {
            address.UserId = Id;
            Addresses.Add(address);
        }
        public void EditAddress(UserAddress address)
        {
            var oldAddress = Addresses.FirstOrDefault(a => a.Id == address.Id);
            if (oldAddress == null)
            {
                throw new NullOrEmptyDomainDataException("Address Not Found");
            }
            Addresses.Remove(oldAddress);
            Addresses.Add(address);
        }
        public void DeleteAddress(long addressId)
        {
            var currentAddress = Addresses.FirstOrDefault(a => a.Id == addressId);
            if (currentAddress == null)
            {
                throw new NullOrEmptyDomainDataException("Address Not Found");
            }
            Addresses.Remove(currentAddress);
        }
        public void ChargeWallet(Wallet wallet)
        {
            wallet.UserId = Id;
            Wallets.Add(wallet);
        }
        public void SetRoles(List<UserRole> roles)
        {
            roles.ForEach(r => r.UserId = Id);
            Roles.Clear();
            Roles.AddRange(roles);
        }

        public void Guard(string phoneNumber, string email, IDomainUserService domainService)
        {
            NullOrEmptyDomainDataException.CheckString(phoneNumber, nameof(phoneNumber));
            NullOrEmptyDomainDataException.CheckString(email, nameof(email));
            if (phoneNumber.Length != 11)
            {
                throw new InvalidDomainDataException("شماره موبایل نامعتبر است!");
            }
            if (email.IsValidEmail() == false)
            {
                throw new InvalidDomainDataException("ایمیل نامعتبر است!");
            }
            if (phoneNumber != PhoneNumber)
            {
                if (domainService.PhoneNumberIsExist(phoneNumber))
                {
                    throw new InvalidDomainDataException("شماره موبایل تکراری است!");
                }
            }
            if (email != Email)
            {
                if (domainService.EmailIsExist(email))
                {
                    throw new InvalidDomainDataException("ایمیل تکراری است!");
                }
            }
        }
    }
}
