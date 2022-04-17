using System.Collections.Generic;
using Common.Query;
using Shop.Query.Categories.DTOs;

namespace Shop.Query.Categories.GetByParentId
{
    public class GetCategoryByParentIdQuery:IQuery<List<ChildCategoryDto>>
    {
        public long ParentId { get; private set; }

        public GetCategoryByParentIdQuery(long parentId)
        {
            ParentId = parentId;
        }
    }
}