using Common.Query;
using Shop.Query.SiteEntities.Banners.DTOs;

namespace Shop.Query.SiteEntities.Banners.GetById
{
    public class GetBannerByIdQuery : IQuery<BannerDto>
    {
        public GetBannerByIdQuery(long bannerId)
        {
            BannerId = bannerId;
        }

        public long BannerId { get; private set; }
    }
}