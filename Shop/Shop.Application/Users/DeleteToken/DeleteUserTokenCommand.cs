using Common.Application;

namespace Shop.Application.Users.DeleteToken
{
    public class DeleteUserTokenCommand : IBaseCommand
    {
        public long UserId { get; private set; }
        public long TokenId { get; private set; }

        public DeleteUserTokenCommand(long userId, long tokenId)
        {
            UserId = userId;
            TokenId = tokenId;
        }
    }
}

