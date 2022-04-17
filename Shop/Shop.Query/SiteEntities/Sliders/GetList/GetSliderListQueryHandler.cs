using Common.Query;
using Microsoft.EntityFrameworkCore;
using Shop.Infrastructure;
using Shop.Query.SiteEntities.Sliders.DTOs;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Shop.Query.SiteEntities.Sliders.GetList
{
    public class GetSliderListQueryHandler : IQueryHandler<GetSliderListQuery, List<SliderDto>>
    {
        public GetSliderListQueryHandler(ShopContext context)
        {
            _context = context;
        }

        private readonly ShopContext _context;

        public async Task<List<SliderDto>> Handle(GetSliderListQuery request, CancellationToken cancellationToken)
        {
            return await _context.Sliders.OrderByDescending(d => d.CreationDate)
                .Select(s => new SliderDto()
                {
                    Id = s.Id,
                    CreationDate = s.CreationDate,
                    Title = s.Title,
                    Link = s.Link,
                    ImageName = s.ImageName

                }).ToListAsync(cancellationToken);
        }
    }
}