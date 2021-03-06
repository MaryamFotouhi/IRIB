using Common.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Shop.Application.Categories.AddChild;
using Shop.Application.Categories.Create;
using Shop.Application.Categories.Edit;
using Shop.Presentation.Facade.Categories;
using Shop.Query.Categories.DTOs;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Shop.Api.Infrastructure.Security;
using Shop.Domain.RoleAgg.Enums;

namespace Shop.Api.Controllers
{
    [PermissionChecker(Permission.Category_Management)]
    public class CategoryController : ApiController
    {
        private readonly ICategoryFacade _categoryFacade;

        public CategoryController(ICategoryFacade categoryFacade)
        {
            _categoryFacade = categoryFacade;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<ApiResult<List<CategoryDto>>> GetCategories()
        {
            var result = await _categoryFacade.GetCategories();
            return QueryResult(result);
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<ApiResult<CategoryDto>> GetCategoryById(long id)
        {
            var result = await _categoryFacade.GetCategoryById(id);
            return QueryResult(result);
        }

        [HttpGet("getChild/{parentId}")]
        public async Task<ApiResult<List<ChildCategoryDto>>> GetCategoriesByParentId(long parentId)
        {
            var result = await _categoryFacade.GetCategoriesByParentId(parentId);
            return QueryResult(result);
        }

        [HttpPost]
        public async Task<ApiResult<long>> CreateCategory(CreateCategoryCommand command)
        {
            var result = await _categoryFacade.Create(command);
            var url = Url.Action("GetCategoryById", "Category", new { id = result.Data }, Request.Scheme);
            return CommandResult(result, HttpStatusCode.Created, url);
        }

        [HttpPost("AddChild")]
        public async Task<ApiResult<long>> CreateCategory(AddChildCategoryCommand command)
        {
            var result = await _categoryFacade.AddChild(command);
            var url = Url.Action("GetCategoryById", "Category", new { id = result.Data }, Request.Scheme);
            return CommandResult(result, HttpStatusCode.Created, url);
        }

        [HttpPut]
        public async Task<ApiResult> EditCategory(EditCategoryCommand command)
        {
            var result = await _categoryFacade.Edit(command);
            return CommandResult(result);
        }

        [HttpDelete("{categoryId}")]
        public async Task<ApiResult> DeleteCategory(long categoryId)
        {
            var result = await _categoryFacade.Delete(categoryId);
            return CommandResult(result);
        }
    }
}

