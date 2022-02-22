using System;
using Common.Application;
using Shop.Domain.CommentAgg.Enums;

namespace Shop.Application.Comments.ChangeStatus
{
    public class ChangeStatusCommentCommand:IBaseCommand
    {
        public ChangeStatusCommentCommand(long id,CommentStatus status)
        {
            Id = id;
            Status = status;
        }

        public long Id { get; private set; }
        public CommentStatus Status { get; private set; }
    }
}