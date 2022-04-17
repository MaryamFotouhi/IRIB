using System.Threading;
using System.Threading.Tasks;
using Common.Query;
using Microsoft.EntityFrameworkCore;
using Shop.Infrastructure;
using Shop.Query.SiteEntities.Banners.DTOs;

namespace Shop.Query.SiteEntities.Banners.GetById
{
    public class GetBannerByIdQueryHandler : IQueryHandler<GetBannerByIdQuery, BannerDto>
    {
        public GetBannerByIdQueryHandler(ShopContext context)
        {
            _context = context;
        }

        private readonly ShopContext _context;
        public async Task<BannerDto> Handle(GetBannerByIdQuery request, CancellationToken cancellationToken)
        {
            var banner = await _context.Banners.FirstOrDefaultAsync(b => b.Id == request.BannerId, cancellationToken);
            if (banner == null)
            {
                return null;
            }
            else
            {
                return new BannerDto()
                {
                    Id = banner.Id,
                    CreationDate = banner.CreationDate,
                    Link = banner.Link,
                    ImageName = banner.ImageName,
                    Position = banner.Position
                };
            }
        }
    }
}