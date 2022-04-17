using Common.Query;
using Shop.Domain.SiteEntities.Enums;

namespace Shop.Query.SiteEntities.Banners.DTOs
{
    public class BannerDto : BaseDto
    {
        public string Link { get; set; }
        public string ImageName { get; set; }
        public BannerPosition Position { get; set; }
    }
}