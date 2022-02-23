using Common.Application;

namespace Shop.Application.Comments.Edit
{
    public class EditCommentCommand : IBaseCommand
    {
        public EditCommentCommand(long id, string text, long userId)
        {
            Id = id;
            Text = text;
            UserId = userId;
        }

        public long Id { get; private set; }
        public string Text { get; private set; }
        public long UserId { get; private set; }
    }
}