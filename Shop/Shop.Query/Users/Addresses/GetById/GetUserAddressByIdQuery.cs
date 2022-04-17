using Common.Query;
using Shop.Query.Users.DTOs;

namespace Shop.Query.Users.Addresses.GetById
{
    public class GetUserAddressByIdQuery : IQuery<AddressDto?>
    {
        public GetUserAddressByIdQuery(long addressId)
        {
            AddressId = addressId;
        }

        public long AddressId { get; private set; }
    }
}


