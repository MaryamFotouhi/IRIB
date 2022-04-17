using Common.Query;
using Microsoft.EntityFrameworkCore;
using Shop.Infrastructure;
using Shop.Query.SiteEntities.Banners.DTOs;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Shop.Query.SiteEntities.Banners.GetList
{
    public class GetBannerListQueryHandler : IQueryHandler<GetBannerListQuery, List<BannerDto>>
    {
        public GetBannerListQueryHandler(ShopContext context)
        {
            _context = context;
        }

        private readonly ShopContext _context;

        public async Task<List<BannerDto>> Handle(GetBannerListQuery request, CancellationToken cancellationToken)
        {
            return await _context.Banners.OrderByDescending(d => d.CreationDate)
                .Select(b => new BannerDto()
                {
                    Id = b.Id,
                    CreationDate = b.CreationDate,
                    Link = b.Link,
                    ImageName = b.ImageName,
                    Position = b.Position

                }).ToListAsync(cancellationToken);
        }
    }
}