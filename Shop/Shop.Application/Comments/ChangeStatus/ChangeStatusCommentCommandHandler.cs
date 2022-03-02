using System.Threading;
using System.Threading.Tasks;
using Common.Application;
using Shop.Domain.CommentAgg.Repository;

namespace Shop.Application.Comments.ChangeStatus
{
    internal class ChangeStatusCommentCommandHandler:IBaseCommandHandler<ChangeStatusCommentCommand>
    {
        public ChangeStatusCommentCommandHandler(ICommentRepository repository)
        {
            _repository = repository;
        }

        private readonly ICommentRepository _repository;
        public async Task<OperationResult> Handle(ChangeStatusCommentCommand request, CancellationToken cancellationToken)
        {
            var comment =await _repository.GetTracking(request.Id);
            if (comment == null)
            {
                return OperationResult.NotFound();
            }
            else
            {
                comment.ChangeStatus(request.Status);
                await _repository.Save();
                return OperationResult.Success();
            }
        }
    }
}