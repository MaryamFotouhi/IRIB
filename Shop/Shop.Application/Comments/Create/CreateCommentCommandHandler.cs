using System.Threading;
using System.Threading.Tasks;
using Common.Application;
using Shop.Domain.CommentAgg;
using Shop.Domain.CommentAgg.Repository;

namespace Shop.Application.Comments.Create
{
    internal class CreateCommentCommandHandler : IBaseCommandHandler<CreateCommentCommand>
    {
        private readonly ICommentRepository _repository;

        public CreateCommentCommandHandler(ICommentRepository repository)
        {
            _repository = repository;
        }

        public async Task<OperationResult> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
        {
            var comment = new Comment(request.UserId, request.ProductId, request.Text);
             _repository.Add(comment);
            await _repository.Save();
            return OperationResult.Success();
        }
    }
}