using Common.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Shop.Application.Users.Create;
using Shop.Application.Users.Edit;
using Shop.Presentation.Facade.Users;
using Shop.Query.Users.DTOs;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Shop.Api.Infrastructure.Security;
using Shop.Domain.RoleAgg.Enums;

namespace Shop.Api.Controllers
{
    [Authorize]
    public class UsersController : ApiController
    {
        private readonly IUserFacade _userFacade;

        public UsersController(IUserFacade userFacade)
        {
            _userFacade = userFacade;
        }

        [PermissionChecker(Permission.User_Management)]
        [HttpGet]
        public async Task<ApiResult<UserFilterResult>> GetUsers([FromQuery] UserFilterParams filterParams)
        {
            var result = await _userFacade.GetUserByFilter(filterParams);
            return QueryResult(result);
        }

        [PermissionChecker(Permission.User_Management)]
        [HttpGet("{userId}")]
        public async Task<ApiResult<UserDto?>> GetById(long userId)
        {
            var result = await _userFacade.GetUserById(userId);
            return QueryResult(result);
        }

        [HttpGet("current")]
        public async Task<ApiResult<UserDto>> GetCurrentUser()
        {
            var result = await _userFacade.GetUserById(User.GetUserId());
            return QueryResult(result);
        }

        [PermissionChecker(Permission.User_Management)]
        [HttpPost]
        public async Task<ApiResult> Create(CreateUserCommand command)
        {
            var result = await _userFacade.CreateUser(command);
            return CommandResult(result);
        }

        [PermissionChecker(Permission.User_Management)]
        [HttpPut]
        public async Task<ApiResult> Edit(EditUserCommand command)
        {
            var result = await _userFacade.EditUser(command);
            return CommandResult(result);
        }
    }
}

