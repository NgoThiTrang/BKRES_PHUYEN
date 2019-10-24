using AutoMapper;
using DoAn.App_Start;
using DoAn.Common.Common;
using System.Linq;
using DoAn.Data.Model;
using DoAn.Service;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

using Web.Infrastructure.Core;
using Web.Models;

namespace DoAn.Api
{
    [Authorize(Roles = "ProvinceManagement")]
    [RoutePrefix("api/warningprofile")]
    public class WarningProfileController : ApiControllerBase
    {
        private IWarningProfileService _warningProfileService;
        private ApplicationUserManager _userManager;
        private IExceptionLogService _errorService;

        public WarningProfileController(IExceptionLogService errorService, IWarningProfileService warningProfileService, ApplicationUserManager userManager) : base(errorService)
        {
            _warningProfileService = warningProfileService;
            _userManager = userManager;
            _errorService = errorService;
        }


        // GET: CauHinhCanhBao
        [HttpGet]
        [Route("getwarningprofile")]
        public HttpResponseMessage GetWarningProfile(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                var lstCauhinh = Mapper.Map<IEnumerable<WarningProfile>,IEnumerable<WarningProfileViewModel>>(_warningProfileService.GetByUserId(User.Identity.GetUserId()).ToList());
                response = request.CreateResponse(HttpStatusCode.OK, lstCauhinh);
                return response;
            });
        }


        [Route("delete")]
        [HttpDelete]
        public HttpResponseMessage Delete(HttpRequestMessage request, int Id)
        {
            _warningProfileService.Delete(Id);
            _warningProfileService.Save();
            return request.CreateResponse(HttpStatusCode.OK, Id);
        }

        [Route("update")]
        [HttpPost]
        public HttpResponseMessage UpdateWarningProfile(HttpRequestMessage request, WarningProfileViewModel modelVm)
        {
            if (!ModelState.IsValid)
            {
                return request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
            else
            {
                
                var model = new WarningProfile();
                if (modelVm.Id == 0)
                {
                    model.UserId = User.Identity.GetUserId();
                    model.Name = modelVm.Name;
                 
                    model.Low_Thres = modelVm.Low_Thres;
                    model.Up_Thres = modelVm.Up_Thres;
                    model.ProcessTimeOut = modelVm.ProcessTimeOut;
                    model.WarningContent = modelVm.WarningContent;

                    switch (model.Name)
                    {
                        case "PH":
                            if (model.Low_Thres <= 7 || model.Low_Thres >= 9 || model.Up_Thres >= 9 || model.Up_Thres <= 7)
                            {
                                return request.CreateErrorResponse(HttpStatusCode.BadRequest, "Vui lòng đặt ngưỡng trong khoảng từ 7-9");
                            }
                            break;
                        case "Salt":
                            if (model.Low_Thres <= 5 || model.Up_Thres >= 35||model.Up_Thres<=model.Low_Thres)
                            {
                                return request.CreateErrorResponse(HttpStatusCode.BadRequest, "Vui lòng đặt ngưỡng trong khoảng từ 5-35");
                            }
                            break;
                        case "Oxy":
                            if (model.Low_Thres <= 3.5 || model.Up_Thres >= 8 || model.Up_Thres <= model.Low_Thres)
                            {
                                return request.CreateErrorResponse(HttpStatusCode.BadRequest, "Vui lòng đặt ngưỡng trong khoảng từ 3.5-8");
                            }
                            break;
                        case "Temp":
                            if (model.Low_Thres <= 18 || model.Up_Thres >= 33 || model.Up_Thres <= model.Low_Thres)
                            {
                                return request.CreateErrorResponse(HttpStatusCode.BadRequest, "Vui lòng đặt ngưỡng trong khoảng từ 18-33");
                            }
                            break;
                        case "H2S":
                            if (model.Low_Thres <= 0 || model.Up_Thres >= 0.05 || model.Up_Thres <= model.Low_Thres)
                            {
                                return request.CreateErrorResponse(HttpStatusCode.BadRequest, "Vui lòng đặt ngưỡng trong khoảng từ 0-0.05");
                            }
                            break;
                        case "NH3":
                            if (model.Low_Thres <= 0.1 || model.Up_Thres >= 0.3 || model.Up_Thres <= model.Low_Thres)
                            {
                                return request.CreateErrorResponse(HttpStatusCode.BadRequest, "Vui lòng đặt ngưỡng trong khoảng từ 0.1-0.3");
                            }
                            break;
                        case "NH4":
                            if (model.Low_Thres <= 0.01 || model.Up_Thres >= 0.2 || model.Up_Thres <= model.Low_Thres)
                            {
                                return request.CreateErrorResponse(HttpStatusCode.BadRequest, "Vui lòng đặt ngưỡng trong khoảng từ 0.01-0.2");
                            }
                            break;

                        default: return request.CreateErrorResponse(HttpStatusCode.BadRequest, "Yêu cầu cập nhật đúng tên tham số quan trắc");
                    }
                    _warningProfileService.Insert(model);
                    _warningProfileService.Save();
                }
                else
                {
                    model = _warningProfileService.GetById(modelVm.Id);
                    model.Name = modelVm.Name;
                    model.Low_Thres = modelVm.Low_Thres;
                    model.Up_Thres = modelVm.Up_Thres;
                    model.ProcessTimeOut = modelVm.ProcessTimeOut;
                    model.WarningContent = modelVm.WarningContent;

                    switch (model.Name)
                    {
                        case "PH":
                            if (model.Low_Thres <= 7 || model.Up_Thres >= 9 || model.Up_Thres <= model.Low_Thres)
                            {
                                return request.CreateErrorResponse(HttpStatusCode.BadRequest, "Vui lòng đặt ngưỡng trong khoảng từ 7-9");
                            }
                            break;
                        case "Salt":
                            if (model.Low_Thres <= 5 || model.Up_Thres >= 35 || model.Up_Thres <= model.Low_Thres || model.Up_Thres <= model.Low_Thres)
                            {
                                return request.CreateErrorResponse(HttpStatusCode.BadRequest, "Vui lòng đặt ngưỡng trong khoảng từ 5-35");
                            }
                            break;
                        case "Oxy":
                            if (model.Low_Thres <= 3.5 || model.Up_Thres >= 8 || model.Up_Thres <= model.Low_Thres)
                            {
                                return request.CreateErrorResponse(HttpStatusCode.BadRequest, "Vui lòng đặt ngưỡng trong khoảng từ 3.5-8");
                            }
                            break;
                        case "Temp":
                            if (model.Low_Thres <= 18 || model.Up_Thres >= 33 || model.Up_Thres <= model.Low_Thres)
                            {
                                return request.CreateErrorResponse(HttpStatusCode.BadRequest, "Vui lòng đặt ngưỡng trong khoảng từ 18-33");
                            }
                            break;
                        case "H2S":
                            if (model.Low_Thres <= 0 || model.Up_Thres >= 0.05 || model.Up_Thres <= model.Low_Thres)
                            {
                                return request.CreateErrorResponse(HttpStatusCode.BadRequest, "Vui lòng đặt ngưỡng trong khoảng từ 0-0.05");
                            }
                            break;
                        case "NH3":
                            if (model.Low_Thres <= 0.1 || model.Up_Thres >= 0.3 || model.Up_Thres <= model.Low_Thres)
                            {
                                return request.CreateErrorResponse(HttpStatusCode.BadRequest, "Vui lòng đặt ngưỡng trong khoảng từ 0.1-0.3");
                            }
                            break;
                        case "NH4":
                            if (model.Low_Thres <= 0.01 || model.Up_Thres >= 0.2 || model.Up_Thres <= model.Low_Thres)
                            {
                                return request.CreateErrorResponse(HttpStatusCode.BadRequest, "Vui lòng đặt ngưỡng trong khoảng từ 0.01-0.2");
                            }
                            break;

                        default: return request.CreateErrorResponse(HttpStatusCode.BadRequest, "Yêu cầu cập nhật đúng tên tham số quan trắc");
                    }
                    _warningProfileService.Update(model);
                    _warningProfileService.Save();
                }
                var responseData = Mapper.Map<WarningProfile, WarningProfileViewModel>(model);
                responseData.Name = _warningProfileService.GetById(model.Id).Name;
                return request.CreateResponse(HttpStatusCode.Created, responseData);
            }
        }

        [Route("reset")]
        [HttpPost]
        public HttpResponseMessage ResetWarningProfile(HttpRequestMessage request)
        {
            string userId = User.Identity.GetUserId(); // lay ra id nguoi dung hien tai dang nhap
            _warningProfileService.DeleteAllByUser(userId);
            try
            {
                _warningProfileService.InsertCauHinhCanhBaoByUser(userId);
            }
            catch(Exception ex)
            {
                return request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
            return request.CreateResponse(HttpStatusCode.Created, "Reset Success");
        }
    }
}
