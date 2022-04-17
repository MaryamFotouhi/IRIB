using Common.Query.Filter;
using MediatR;

namespace Common.Query
{
    public interface IQuery<TResponse> : IRequest<TResponse> where TResponse : class
    {

    }
    public class QueryFilter<TResponse, TParam> : IQuery<TResponse>
        where TResponse : BaseFilter
        where TParam : BaseFilterParam
    {
        public QueryFilter(TParam filterParams)
        {
            FilterParams = filterParams;
        }

        public TParam FilterParams { get; set; }
    }
}