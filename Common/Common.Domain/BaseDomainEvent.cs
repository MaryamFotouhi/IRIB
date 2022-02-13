﻿using MediatR;
using System;

namespace Common.Domain
{
    public class BaseDomainEvent : INotification
    {
        public BaseDomainEvent()
        {
            CreationDate = DateTime.Now;
        }

        public DateTime CreationDate { get; protected set; }
    }
}