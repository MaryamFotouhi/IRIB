using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Shop.Domain.CategoryAgg.Repository;
using Shop.Domain.CommentAgg.Repository;
using Shop.Domain.OrderAgg.Repository;
using Shop.Domain.ProductAgg.Repository;
using Shop.Domain.RoleAgg.Repository;
using Shop.Domain.SellerAgg.Repository;
using Shop.Domain.SiteEntities.Repositiry;
using Shop.Domain.UserAgg.Repository;
using Shop.Infrastructure.Persistent.Dapper;
using Shop.Infrastructure.Persistent.Ef.CategoryAgg;
using Shop.Infrastructure.Persistent.EF.CommentAgg;
using Shop.Infrastructure.Persistent.Ef.OrderAgg;
using Shop.Infrastructure.Persistent.EF.ProductAgg;
using Shop.Infrastructure.Persistent.Ef.RoleAgg;
using Shop.Infrastructure.Persistent.Ef.SellerAgg;
using Shop.Infrastructure.Persistent.Ef.SiteEntities.Repositories;
using Shop.Infrastructure.Persistent.Ef.UserAgg;

namespace Shop.Infrastructure
{
    public class InfrastructureBootstrapper
    {
        public static void Init(IServiceCollection services,string connectionString)
        {
            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<ICommentRepository, CommentRepository>();
            services.AddTransient<IOrderRepository, OrderRepository>();
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<IRoleRepository, RoleRepository>();
            services.AddTransient<ISellerRepository, SellerRepository>();
            services.AddTransient<IBannerRepository, BannerRepository>();
            services.AddTransient<ISliderRepository, SliderRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            
            services.AddTransient<DapperContext>(_ => new DapperContext(connectionString));

            services.AddDbContext<ShopContext>(option=>
            {
                option.UseSqlServer(connectionString);
            });
        }
    }
}