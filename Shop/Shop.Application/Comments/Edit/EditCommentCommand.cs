using Common.Application;

namespace Shop.Application.Comments.Edit
{
    public class EditCommentCommand : IBaseCommand
    {
        public long Id { get; private set; }
        public string Text { get; private set; }
        public long UserId { get; private set; }

        public EditCommentCommand(long id, string text, long userId)
        {
            Id = id;
            Text = text;
            UserId = userId;
        }
    }
}