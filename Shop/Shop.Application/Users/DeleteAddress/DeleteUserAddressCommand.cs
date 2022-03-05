using Common.Application;

namespace Shop.Application.Users.DeleteAddress
{
    public class DeleteUserAddressCommand:IBaseCommand
    {
        public DeleteUserAddressCommand(long userId, long addressId)
        {
            UserId = userId;
            AddressId = addressId;
        }

        public long UserId { get; private set; }
        public long AddressId { get; private set; }
    }
}