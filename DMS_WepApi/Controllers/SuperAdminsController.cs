﻿using System.Net;
using System.Net.Http;
using System.Web.Http;
using DMS_WepApi.Models;
using System.Web.Http.Cors;
using DMS_BLL.Repositories;
using DMS_BOL.Validation_Classes;
using DMS_WepApi.ResponseClasses;

namespace DMS_WepApi.Controllers
{
    [Authorize]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class SuperAdminsController : ApiController
    {
        private SuperAdminsRepo SuperAdminRepoObj;

        public SuperAdminsController()
        {
            SuperAdminRepoObj = new SuperAdminsRepo();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidationActionFilter]
        [Route("api/Register/SuperAdmin")]
        public HttpResponseMessage RegisterSuperAdmin([FromBody] ValidateSuperAdmin user)
        {
            if (user != null)
            {
                var reas = SuperAdminRepoObj.InsertSuperAdmin(user);
                if (reas == 1)
                    return Request.CreateResponse(HttpStatusCode.Created, new GRValidation()
                    {
                        StatusCode = 201,
                        Success = true,
                        Message = "Your account has been registered successfully!",
                    });
                else if (reas == -1)
                    return Request.CreateResponse(HttpStatusCode.Forbidden, new GRValidation()
                    {
                        StatusCode = 403,
                        Success = false,
                        Message = "Invalid OTP provided. Please ensure to enter correct OTP again!",
                    });
                else
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, new GRValidation()
                    {
                        StatusCode = 500,
                        Success = false,
                        Message = "Error occured on creating Account. Please try again later!",
                    });
            }
            else
                return Request.CreateResponse(HttpStatusCode.PreconditionFailed, new GRValidation()
                {
                    StatusCode = 412,
                    Success = false,
                    Message = "Invalid data provided!"
                });
        }

        [HttpPost]
        [ValidationActionFilter]
        [Route("api/Update/SuperAdmin")]
        [Authorize(Roles = "SuperAdmin")]
        public HttpResponseMessage UpdateSuperAdmin([FromBody] ValidateSuperAdmin user)
        {
            if (user != null && user.UserUpdatedBy > 0 && user.UserID > 0)
            {
                var reas = SuperAdminRepoObj.UpdateSuperAdmin(user);
                if (reas)
                    return Request.CreateResponse(HttpStatusCode.OK, new GRValidation()
                    {
                        StatusCode = 200,
                        Success = true,
                        Message = "Your account details has been updated successfully!",
                    });
                else
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, new GRValidation()
                    {
                        StatusCode = 500,
                        Success = false,
                        Message = "Error occured on updating Account. Please try again later!",
                    });
            }
            else
                return Request.CreateResponse(HttpStatusCode.PreconditionFailed, new GRValidation()
                {
                    StatusCode = 412,
                    Success = false,
                    Message = "Invalid data provided. Please provide User ID or Updated By!"
                });
        }

        [HttpPost]
        [ValidationActionFilter]
        [Route("api/InActive/SuperAdmin")]
        [Authorize(Roles = "SuperAdmin")]
        public HttpResponseMessage InActiveSuperAdmin([FromBody] ValidateUsersIA user)
        {
            if (user != null && user.UserUpdatedBy > 0 && user.UserID > 0)
            {
                var reas = SuperAdminRepoObj.InActiveSuperAdmin(user);
                if (reas)
                    return Request.CreateResponse(HttpStatusCode.OK, new GRValidation()
                    {
                        StatusCode = 200,
                        Success = true,
                        Message = "Account has been deactivated successfully!",
                    });
                else
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, new GRValidation()
                    {
                        StatusCode = 500,
                        Success = false,
                        Message = "Error occured on deactivating Account. Please try again later!",
                    });
            }
            else
                return Request.CreateResponse(HttpStatusCode.PreconditionFailed, new GRValidation()
                {
                    StatusCode = 412,
                    Success = false,
                    Message = "Invalid data provided!"
                });
        }

        [HttpPost]
        [ValidationActionFilter]
        [Route("api/ReActive/SuperAdmin")]
        [Authorize(Roles = "SuperAdmin")]
        public HttpResponseMessage ReActiveSuperAdmin([FromBody] ValidateUsersIA user)
        {
            if (user != null && user.UserUpdatedBy > 0 && user.UserID > 0)
            {
                var reas = SuperAdminRepoObj.ReActiveSuperAdmin(user);
                if (reas)
                    return Request.CreateResponse(HttpStatusCode.OK, new GRValidation()
                    {
                        StatusCode = 200,
                        Success = true,
                        Message = "Account has been activated successfully!",
                    });
                else
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, new GRValidation()
                    {
                        StatusCode = 500,
                        Success = false,
                        Message = "Error occured on activating Account. Please try again later!",
                    });
            }
            else
                return Request.CreateResponse(HttpStatusCode.PreconditionFailed, new GRValidation()
                {
                    StatusCode = 412,
                    Success = false,
                    Message = "Invalid data provided!"
                });
        }

        [HttpGet]
        [ValidationActionFilter]
        [Route("api/Get/SuperAdmin")]
        [Authorize(Roles = "SuperAdmin")]
        public HttpResponseMessage GetSuperAdminByID(int SuperAdminID)
        {
            if (SuperAdminID > 0)
            {
                var reas = SuperAdminRepoObj.GetUserDetailById(SuperAdminID);
                if (reas != null)
                    return Request.CreateResponse(HttpStatusCode.OK, new GRIValidation()
                    {
                        StatusCode = 200,
                        Success = true,
                        Message = "Account record has been recieved successfully!",
                        Datalist = reas
                    });
                else
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, new GRValidation()
                    {
                        StatusCode = 500,
                        Success = false,
                        Message = "Error occured on getting Account details. Please try again later!",
                    });
            }
            else
                return Request.CreateResponse(HttpStatusCode.PreconditionFailed, new GRValidation()
                {
                    StatusCode = 412,
                    Success = false,
                    Message = "Invalid data provided!"
                });
        }

    }
}
