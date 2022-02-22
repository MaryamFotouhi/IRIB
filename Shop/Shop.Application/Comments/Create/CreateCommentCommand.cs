using Common.Application;

namespace Shop.Application.Comments.Create
{
    public class CreateCommentCommand : IBaseCommand
    {
        public CreateCommentCommand(long userId, long productId, string text)
        {
            UserId = userId;
            ProductId = productId;
            Text = text;
        }

        public long UserId { get; private set; }
        public long ProductId { get; private set; }
        public string Text { get; private set; }
    }
}