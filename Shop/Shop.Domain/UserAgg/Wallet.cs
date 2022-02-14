﻿using System;
using Common.Domain;
using Common.Domain.Exceptions;
using Shop.Domain.UserAgg.Enums;

namespace Shop.Domain.UserAgg
{
    public class Wallet : BaseEntity
    {
        public Wallet(int price, string desciption, bool isFinally, DateTime? finallyDate, WalletType type)
        {
            if (price < 500)
                throw new InvalidDomainDataException("مبلغ به اندازه کافی نمی باشد!");
            Price = price;
            Desciption = desciption;
            IsFinally = isFinally;
            FinallyDate = finallyDate;
            Type = type;
        }

        public long UserId { get; internal set; }
        public int Price { get; private set; }
        public string Desciption { get; private set; }
        public bool IsFinally { get; private set; }
        public DateTime? FinallyDate { get; private set; }
        public WalletType Type { get; private set; }

        public void Finally(string refCode)
        {
            IsFinally = true;
            FinallyDate=DateTime.Now;
            Desciption += $"کد پیگیری : {refCode}";
        }
    }
}