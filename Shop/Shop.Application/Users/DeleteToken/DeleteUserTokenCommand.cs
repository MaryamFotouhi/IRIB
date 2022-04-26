using Common.Application;

namespace Shop.Application.Users.DeleteToken
{
    public class DeleteUserTokenCommand : IBaseCommand
    {
        public long Id { get; private set; }
        public long UserId { get; private set; }


        public DeleteUserTokenCommand(long userId, long id)
        {
            UserId = userId;
            Id = id;
        }
    }
}

