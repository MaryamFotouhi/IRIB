using Common.Application;
using Shop.Application.Comments.Create;
using Shop.Application.Comments.Edit;
using Shop.Query.Comments.DTOs;
using System.Threading.Tasks;
using Shop.Application.Comments.ChangeStatus;

namespace Shop.Presentation.Facade.Comments
{
    public interface ICommentFacade
    {
        Task<OperationResult> ChangeStatus(ChangeStatusCommentCommand command);
        Task<OperationResult> CreateComment(CreateCommentCommand command);
        Task<OperationResult> EditComment(EditCommentCommand command);


        Task<CommentDto?> GetCommentById(long id);
        Task<CommentFilterResult> GetCommentsByFilter(CommentFilterParams filterParams);
    }
}

