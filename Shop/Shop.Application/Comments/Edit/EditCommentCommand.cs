using System.Threading;
using System.Threading.Tasks;
using Common.Application;
using Shop.Domain.CommentAgg.Repository;

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
    public class EditCommentCommandHandler : IBaseCommandHandler<EditCommentCommand>
    {
        public EditCommentCommandHandler(ICommentRepository repository)
        {
            _repository = repository;
        }

        private readonly ICommentRepository _repository;
        public async Task<OperationResult> Handle(EditCommentCommand request, CancellationToken cancellationToken)
        {
            var comment = await _repository.GetTracking(request.Id);
            if (comment == null || comment.UserId!=request.UserId)
            {
                return OperationResult.NotFound();
            }
            else
            {
                comment.Edit(request.Text);
                await _repository.Save();
                return OperationResult.Success();
            }
        }
    }
}