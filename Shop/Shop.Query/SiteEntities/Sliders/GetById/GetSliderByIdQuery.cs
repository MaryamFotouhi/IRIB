using Common.Query;
using Shop.Query.SiteEntities.Sliders.DTOs;

namespace Shop.Query.SiteEntities.Sliders.GetById
{
    public class GetSliderByIdQuery : IQuery<SliderDto>
    {
        public GetSliderByIdQuery(long sliderId)
        {
            SliderId = sliderId;
        }

        public long SliderId { get; private set; }
    }
}