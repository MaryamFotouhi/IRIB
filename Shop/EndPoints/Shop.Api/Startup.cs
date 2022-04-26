using System;
using Common.Application;
using Common.Application.FileUtil.Interfaces;
using Common.Application.FileUtil.Services;
using Common.AspNetCore;
using Common.AspNetCore.Middlewares;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Shop.Api.Infrastructure;
using Shop.Api.Infrastructure.JwtUtil;
using Shop.Config;

namespace Shop.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            //services.AddControllers();
            //Customize BadRequest
            services.AddControllers()
                .ConfigureApiBehaviorOptions(option =>
                {
                    option.InvalidModelStateResponseFactory = (context =>
                    {
                        var result = new ApiResult()
                        {
                            IsSuccess = false,
                            MetaData = new MetaData()
                            {
                                AppStatusCode = AppStatusCode.BadRequest,
                                Message = ModelStateUtil.GetModelStateErrors(context.ModelState)
                            }
                        };
                        return new BadRequestObjectResult(result);
                    });
                });

            services.AddSwaggerGen(option =>
            {
                var jwtSecurityScheme = new OpenApiSecurityScheme
                {
                    Scheme = "bearer",
                    BearerFormat = "JWT",
                    Name = "JWT Authentication",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Description = "Enter Token",

                    Reference = new OpenApiReference
                    {
                        Id = JwtBearerDefaults.AuthenticationScheme,
                        Type = ReferenceType.SecurityScheme
                    }
                };

                option.AddSecurityDefinition(jwtSecurityScheme.Reference.Id, jwtSecurityScheme);

                option.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    { jwtSecurityScheme, Array.Empty<string>() }
                });
            });

            //Connection
            services.RegisterShopDependency(Configuration.GetConnectionString("DefaultConnection"));

            //Authentication JWT
            services.RegisterApiDependency();

            CommonBootstrapper.Init(services);
            services.AddTransient<IFileService, FileService>();

            //Config JWT
            services.AddJwtAuthentication(Configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //if (env.IsDevelopment())
            //{
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Shop.Api v1"));
            //}

            app.UseHttpsRedirection();

            app.UseRouting();

            //Cors
            app.UseCors("ShopApi");


            //Active Authentication
            app.UseAuthentication();

            app.UseAuthorization();

            //Middleware For Customize Error
            app.UseApiCustomExceptionHandler();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
