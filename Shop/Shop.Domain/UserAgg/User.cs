using System;
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
        public string Name { get; private set; }
        public string Family { get; private set; }
        public string PhoneNumber { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public Gender Gender { get; private set; }
        public string AvatarName { get; private set; }
        public bool IsActive { get; private set; }
        public List<UserRole> Roles { get; private set; }
        public List<Wallet> Wallets { get; private set; }
        public List<UserAddress> Addresses { get; private set; }
        public List<UserToken> Tokens { get; private set; }

        private User()
        {

        }

        public User(string name, string family, string phoneNumber, string email, string password,
            Gender gender, IUserDomainService domainService)
        {
            Guard(phoneNumber, email, domainService);
            Name = name;
            Family = family;
            PhoneNumber = phoneNumber;
            Email = email;
            Password = password;
            Gender = gender;
            AvatarName = "Avatar.png";
            IsActive = true;
            Roles = new List<UserRole>();
            Wallets = new List<Wallet>();
            Addresses = new List<UserAddress>();
            Tokens = new List<UserToken>();
        }

        public static User Register(string phoneNumber, string password, IUserDomainService domainService)
        {
            return new User("", "", phoneNumber, "", password, Gender.None, domainService);
        }

        public void Edit(string name, string family, string phoneNumber, string email, Gender gender,
            IUserDomainService domainService)
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

        public void EditAddress(UserAddress address, long addressId)
        {
            var currentAddress = Addresses.FirstOrDefault(a => a.Id == addressId);
            if (currentAddress == null)
                throw new NullOrEmptyDomainDataException("Address Not Found!");

            address.Edit(address.Shire, address.City, address.PostalCode, address.PostalAddress,
                address.PhoneNumber, address.Name, address.Family, address.NationalCode);
        }

        public void DeleteAddress(long addressId)
        {
            var currentAddress = Addresses.FirstOrDefault(a => a.Id == addressId);
            if (currentAddress == null)
                throw new NullOrEmptyDomainDataException("Address Not Found!");

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

        public void SetAvatar(string imageName)
        {
            if (string.IsNullOrWhiteSpace(imageName))
                AvatarName = "Avatar.png";

            AvatarName = imageName;
        }

        public void AddToken(string hashJwtToken, string hashRefreshToken, DateTime tokenExpireDate, DateTime refreshTokenExpireDate, string device)
        {
            var activeTokenCount = Tokens.Count(c => c.RefreshTokenExpireDate > DateTime.Now);
            if (activeTokenCount == 3)
                throw new InvalidDomainDataException("امکان استفاده همزمان از 4 دستگاه وجود ندارد!");
            
            var token = new UserToken(hashJwtToken, hashRefreshToken, tokenExpireDate, refreshTokenExpireDate, device);
            token.UserId = Id;
            Tokens.Add(token);
        }

        public void RemoveToken(long tokenId)
        {
            var token = Tokens.FirstOrDefault(f => f.Id == tokenId);
            if (token == null)
                throw new InvalidDomainDataException("Invalid TokenId");

            Tokens.Remove(token);
        }

        private void Guard(string phoneNumber, string email, IUserDomainService domainService)
        {
            NullOrEmptyDomainDataException.CheckString(phoneNumber, nameof(phoneNumber));

            if (phoneNumber.Length != 11)
                throw new InvalidDomainDataException("شماره موبایل نامعتبر است!");

            if (!string.IsNullOrWhiteSpace(email))
                if (email.IsValidEmail() == false)
                    throw new InvalidDomainDataException("ایمیل نامعتبر است!");
            
            if (phoneNumber != PhoneNumber)
                if (domainService.PhoneNumberIsExist(phoneNumber))
                    throw new InvalidDomainDataException("شماره موبایل تکراری است!");
                
            
            if (email != Email)
                if (domainService.EmailIsExist(email))
                    throw new InvalidDomainDataException("ایمیل تکراری است!");
        }
    }
}
