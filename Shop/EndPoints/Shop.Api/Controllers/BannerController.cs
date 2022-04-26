﻿using Common.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Shop.Api.Infrastructure.Security;
using Shop.Application.SiteEntities.Banners.Create;
using Shop.Application.SiteEntities.Banners.Edit;
using Shop.Domain.RoleAgg.Enums;
using Shop.Presentation.Facade.SiteEntities.Banner;
using Shop.Query.SiteEntities.Banners.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace Shop.Api.Controllers
{
    [PermissionChecker(Permission.CRUD_Banner)]
    public class BannerController : ApiController
    {
        private readonly IBannerFacade _facade;

        public BannerController(IBannerFacade facade)
        {
            _facade = facade;
        }
        [AllowAnonymous]
        [HttpGet]
        public async Task<ApiResult<List<BannerDto>>> GetList()
        {
            var result = await _facade.GetBanners();
            return QueryResult(result);
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<ApiResult<BannerDto?>> GetById(long id)
        {
            var result = await _facade.GetBannerById(id);
            return QueryResult(result);
        }

        [HttpPost]
        public async Task<ApiResult> Create([FromForm] CreateBannerCommand command)
        {
            var result = await _facade.CreateBanner(command);
            return CommandResult(result);
        }
        [HttpPut]
        public async Task<ApiResult> Edit([FromForm] EditBannerCommand command)
        {
            var result = await _facade.EditBanner(command);
            return CommandResult(result);
        }
    }
}

