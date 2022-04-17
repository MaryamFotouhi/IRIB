using System.Collections.Generic;
using Common.Query;
using Shop.Query.Users.DTOs;

namespace Shop.Query.Users.Addresses.GetList
{
    public class GetUserAddressesListQuery : IQuery<List<AddressDto>>
    {
        public GetUserAddressesListQuery(long userId)
        {
            UserId = userId;
        }

        public long UserId { get; private set; }
    }
}

