using System;
using System.Collections.Generic;
using System.Linq;
using Common.Domain;
using Common.Domain.Exceptions;
using Shop.Domain.SellerAgg.Enums;
using Shop.Domain.SellerAgg.Services;

namespace Shop.Domain.SellerAgg
{
    public class Seller : AggregateRoot
    {
        private Seller()
        {

        }
        public Seller(long userId, string shopName, string nationalCode,IDomainSellerService domainService)
        {
            Guard(shopName, nationalCode);
            UserId = userId;
            ShopName = shopName;
            NationalCode = nationalCode;
            Inventories=new List<SellerInventory>();
            if (domainService.CheckSellerInfo(this)==false)
            {
                throw new InvalidDomainDataException("اطلاعات نامعتبر است!");
            }
        }

        public long UserId { get; private set; }
        public string ShopName { get; private set; }
        public string NationalCode { get; private set; }
        public SellerStatus Status { get; private set; }
        public DateTime? LastUpdate { get; private set; }
        public List<SellerInventory> Inventories { get; private set; }

        public void Edit(string shopName, string nationalCode,SellerStatus status,IDomainSellerService domainService)
        {
            Guard(shopName, nationalCode);
            if (nationalCode != NationalCode)
            {
                if (domainService.NationalCodeIsExist(nationalCode))
                {
                    throw new InvalidDomainDataException("کد ملی متعلق به شخص دیگری است!");
                }
            }
            ShopName = shopName;
            NationalCode = nationalCode;
            Status = status;
        }
        public void AddInventory(SellerInventory inventory)
        {
            if (Inventories.Any(i => i.ProductId == inventory.ProductId) == null)
            {
                throw new InvalidDomainDataException("این محصول قبلا ثبت شده است!");
            }
            Inventories.Add(inventory);
        }
        public void EditInventory(long inventoryId,int count,int price,int? discountPercentage)
        {
            var currentInventory = Inventories.FirstOrDefault(i => i.Id == inventoryId);
            if (currentInventory == null)
            {
                throw new NullOrEmptyDomainDataException("Inventory Not Found");
            }
            currentInventory.Edit(count,price, discountPercentage);
        }
        public void DeleteInventory(long inventoryId)
        {
            var currentInventory = Inventories.FirstOrDefault(i => i.Id == inventoryId);
            if (currentInventory == null)
            {
                throw new NullOrEmptyDomainDataException("Inventory Not Found");
            }
            Inventories.Remove(currentInventory);
        }
        public void ChangeStatus(SellerStatus status)
        {
            Status = status;
            LastUpdate = DateTime.Now;
        }
        private void Guard(string shopName, string nationalCode)
        {
            NullOrEmptyDomainDataException.CheckString(shopName, nameof(nationalCode));
            NullOrEmptyDomainDataException.CheckString(nationalCode, nameof(nationalCode));
            if (IranianNationalIdChecker.IsValid(nationalCode) == false)
            {
                throw new InvalidDomainDataException("کد ملی نامعتبر است!");
            }
        }
    }
}
