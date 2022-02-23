using System.Threading;
using System.Threading.Tasks;
using Common.Application;
using Shop.Domain.CommentAgg.Repository;

namespace Shop.Application.Comments.Edit
{
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