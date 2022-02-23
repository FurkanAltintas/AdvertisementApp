using AdvertisementApp.Business.Interfaces;
using AdvertisementApp.Dtos;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AdvertisementApp.UI.Base
{
    public class BaseController : Controller
    {
        public int Id { get; set; }
        public UserInfo UserInfo { get; set; }

        private readonly IAppUserService _appUserService;
        private readonly IMapper _mapper;

        public BaseController(IAppUserService appUserService, IMapper mapper)
        {
            _appUserService = appUserService;
            _mapper = mapper;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var userId = int.Parse((HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)).Value);

            var user = this.UserKey(userId);

            var userUpdate = _mapper.Map<UserInfo>(user);

            Id = userId;
            UserInfo = userUpdate;

            base.OnActionExecuting(context);
        }

        #region  Async
        /*
          public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var userId = int.Parse((HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)).Value);

            var user = await this.UserKey(userId);

            Id = userId;
            AppUserUpdateDto = user;
            await base.OnActionExecutionAsync(context, next);
        }
         */
        #endregion

        public AppUserUpdateDto UserKey(int userId)
        {
            var response = _appUserService.GetByIdAsync<AppUserUpdateDto>(userId);
            return response.Result.Data;
        }
    }
}
