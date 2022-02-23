using AdvertisementApp.Business.Interfaces;
using AdvertisementApp.Common.Enums;
using AdvertisementApp.Dtos;
using AdvertisementApp.UI.Base;
using AdvertisementApp.UI.Extensions;
using AdvertisementApp.UI.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdvertisementApp.UI.Controllers
{
    public class AdvertisementController : BaseController
    {
        private readonly IAppUserService _appUserService;
        private readonly IAdvertisementAppUserService _advertisementAppUserService;
        private readonly IMapper _mapper;

        public AdvertisementController(IAppUserService appUserService, IAdvertisementAppUserService advertisementAppUserService, IMapper mapper) : base(appUserService, mapper)
        {
            _appUserService = appUserService;
            _advertisementAppUserService = advertisementAppUserService;
            _mapper = mapper;
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> List(AdvertisementAppUserStatusType type = AdvertisementAppUserStatusType.Basvurdu)
        {
            var advertisements = await _advertisementAppUserService.GetList(type);
            return View(advertisements);
        }

        #region Hocanın Yaptığı Yöntem
        /*
         [Authorize(Roles = "Admin")]
        public async Task<IActionResult> ApprovedList()
        {
            var list = await _advertisementAppUserService.GetList(AdvertisementAppUserStatusType.Mulakat);
            return View(list);
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> RejectedList()
        {
            var list = await _advertisementAppUserService.GetList(AdvertisementAppUserStatusType.Olumsuz);
            return View(list);
        }
         */
        #endregion


        [Authorize(Roles = "Member")]
        public IActionResult Send(int advertisementId)
        {
            var userId = this.UserGender();

            MilitaryStatusSelectList();

            return View(new AdvertisementAppUserCreateModel
            {
                AdvertisementId = advertisementId,
                AppUserId = userId
            });
        }

        [Authorize(Roles = "Member")]
        [HttpPost]
        public async Task<IActionResult> Send(AdvertisementAppUserCreateModel model)
        {
            var createdAdvertisementAppUser = _mapper.Map<AdvertisementAppUserCreateDto>(model);

            if (model.CvFile != null)
            {
                Utils.File file = new Utils.File();
                file.FileUpload(model.CvFile, fileLocation: "cvFiles", out string validation, out string filePath);
                if (validation == null)
                    createdAdvertisementAppUser.CvPath = filePath;
                else
                    ModelState.AddModelError("", validation);
            }

            var response = await _advertisementAppUserService.CreateAsync(createdAdvertisementAppUser);

            if (response.ResponseType == Common.ResponseType.ValidationError)
            {
                MilitaryStatusSelectList();
                this.UserGender();
            }

            return this.ResponseRedirectAction(response: response, model: model, controllerName: "Home", actionName: "HumanResource");
            // Farklı yönlendirmeler için

            #region Uzun Hali
            //if (response.ResponseType == Common.ResponseType.ValidationError)
            //{
            //    foreach (var error in response.ValidationErrors)
            //    {
            //        ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
            //    }

            //    return View(model);
            //}
            //else
            //{
            //    return RedirectToAction("HumanResource", "Home");
            //}
            #endregion
        }

        public int UserGender()
        {
            #region Yeni yöntemler
            // int userID = this.UserKey();
            // string userName = this.ClaimType(type: "UserName");
            #endregion

            #region Uzun Yöntem
            // int userId = Convert.ToInt32(this.UserType(type: ClaimTypes.NameIdentifier));
            // var userResponse = await _appUserService.GetByIdAsync<AppUserListDto>(userId);
            // 
            // ViewBag.GenderId = userResponse.Data.GenderId;
            // return userId;
            #endregion

            ViewBag.GenderId = UserInfo.GenderId;
            return Id;
        }

        public void MilitaryStatusSelectList()
        {
            var items = Enum.GetValues(typeof(MilitaryStatusType));
            var list = new List<MilitaryStatusListDto>();

            foreach (int item in items)
            {
                list.Add(new()
                {
                    Id = item,
                    Definition = Enum.GetName(typeof(MilitaryStatusType), item)
                });
            }

            // ViewBag.MilitaryStatus = new SelectList(list, "Id", "Definition");
            ViewBag.MilitaryStatus = SelectListExtensions.SelectListModel(list, "Id", "Definition");
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> SetStatus(int advertisementAppUserId, AdvertisementAppUserStatusType type)
        {
            await _advertisementAppUserService.SetStatusAsync(advertisementAppUserId, type);
            return RedirectToAction(nameof(List));
        }
    }
}
