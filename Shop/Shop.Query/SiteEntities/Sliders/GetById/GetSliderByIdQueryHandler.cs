using Common.Query;
using Microsoft.EntityFrameworkCore;
using Shop.Infrastructure;
using Shop.Query.SiteEntities.Sliders.DTOs;
using System.Threading;
using System.Threading.Tasks;

namespace Shop.Query.SiteEntities.Sliders.GetById
{
    public class GetSliderByIdQueryHandler : IQueryHandler<GetSliderByIdQuery, SliderDto>
    {
        public GetSliderByIdQueryHandler(ShopContext context)
        {
            _context = context;
        }

        private readonly ShopContext _context;
        public async Task<SliderDto> Handle(GetSliderByIdQuery request, CancellationToken cancellationToken)
        {
            var slider = await _context.Sliders.FirstOrDefaultAsync(s => s.Id == request.SliderId, cancellationToken);
            if (slider == null)
            {
                return null;
            }
            else
            {
                return new SliderDto()
                {
                    Id = slider.Id,
                    CreationDate = slider.CreationDate,
                    Title = slider.Title,
                    Link = slider.Link,
                    ImageName = slider.ImageName
                };
            }
        }
    }
}