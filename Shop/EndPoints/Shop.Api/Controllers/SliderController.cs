﻿using Common.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Shop.Application.SiteEntities.Sliders.Create;
using Shop.Application.SiteEntities.Sliders.Edit;
using Shop.Presentation.Facade.SiteEntities.Slider;
using Shop.Query.SiteEntities.Sliders.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Shop.Api.Infrastructure.Security;
using Shop.Domain.RoleAgg.Enums;

namespace Shop.Api.Controllers
{
    [PermissionChecker(Permission.CRUD_Slider)]
    public class SliderController : ApiController
    {
        private readonly ISliderFacade _facade;


        public SliderController(ISliderFacade facade)
        {
            _facade = facade;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<ApiResult<List<SliderDto>>> GetList()
        {
            var result = await _facade.GetSliders();
            return QueryResult(result);
        }

        [HttpGet("{id}")]
        public async Task<ApiResult<SliderDto?>> GetById(long id)
        {
            var result = await _facade.GetSliderById(id);
            return QueryResult(result);
        }

        [HttpPost]
        public async Task<ApiResult> Create(CreateSliderCommand command)
        {
            var result = await _facade.CreateSlider(command);
            return CommandResult(result);
        }
        [HttpPut]
        public async Task<ApiResult> Edit(EditSliderCommand command)
        {
            var result = await _facade.EditSlider(command);
            return CommandResult(result);
        }
    }
}

