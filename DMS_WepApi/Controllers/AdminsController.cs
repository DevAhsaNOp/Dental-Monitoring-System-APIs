﻿using System.Net;
using System.Net.Http;
using System.Web.Http;
using DMS_WepApi.Models;
using System.Web.Http.Cors;
using DMS_BLL.Repositories;
using DMS_WepApi.ResponseClasses;
using DMS_BOL.Validation_Classes;

namespace DMS_WepApi.Controllers
{
    //[Authorize]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class AdminsController : ApiController
    {
        private AdminsRepo AdminRepoObj;

        public AdminsController()
        {
            AdminRepoObj = new AdminsRepo();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidationActionFilter]
        [Route("api/Register/Admin")]
        public HttpResponseMessage RegisterAdmin([FromBody] ValidateAdmin user)
        {
            if (user != null)
            {
                var reas = AdminRepoObj.InsertAdmin(user);
                if (reas == 1)
                    return Request.CreateResponse(HttpStatusCode.Created, new GRValidation()
                    {
                        StatusCode = 201,
                        Success = true,
                        Message = "Your account has been registered successfully!",
                    });
                else if (reas == -1)
                    return Request.CreateResponse(HttpStatusCode.OK, new GRValidation()
                    {
                        StatusCode = 403,
                        Success = false,
                        Message = "Invalid OTP provided. Please ensure to enter correct OTP again!",
                    });
                else if (reas == -2)
                    return Request.CreateResponse(HttpStatusCode.OK, new GRValidation()
                    {
                        StatusCode = 404,
                        Success = false,
                        Message = "Email already exists. Please ensure to enter not used email account again!",
                    });
                else if (reas == -3)
                    return Request.CreateResponse(HttpStatusCode.OK, new GRValidation()
                    {
                        StatusCode = 405,
                        Success = false,
                        Message = "Phone Number already exists. Please ensure to enter not used phone number again!",
                    });
                else
                    return Request.CreateResponse(HttpStatusCode.OK, new GRValidation()
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
        [Route("api/Update/Admin")]
        //[Authorize(Roles = "Admin,SuperAdmin")]
        public HttpResponseMessage UpdateAdmin([FromBody] ValidateAdmin user)
        {
            if (user != null && user.UserUpdatedBy > 0 && user.UserID > 0 && !string.IsNullOrEmpty(user.UserUpdatePhoneNumber) && !string.IsNullOrEmpty(user.UserUpdateEmail))
            {
                var reas = AdminRepoObj.UpdateAdmin(user);
                if (reas == 1)
                    return Request.CreateResponse(HttpStatusCode.OK, new GRValidation()
                    {
                        StatusCode = 200,
                        Success = true,
                        Message = "Your account details has been updated successfully!",
                    });
                else if (reas == -1)
                    return Request.CreateResponse(HttpStatusCode.OK, new GRValidation()
                    {
                        StatusCode = 404,
                        Success = false,
                        Message = "Email already exists. Please ensure to enter not used email account again!",
                    });
                else if (reas == -2)
                    return Request.CreateResponse(HttpStatusCode.OK, new GRValidation()
                    {
                        StatusCode = 405,
                        Success = false,
                        Message = "Phone Number already exists. Please ensure to enter not used phone number again!",
                    });
                else
                    return Request.CreateResponse(HttpStatusCode.OK, new GRValidation()
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
                    Message = "Invalid data provided. Please provide User ID or Updated By or User Update Email/Phone Number!"
                });
        }

        [HttpPost]
        [ValidationActionFilter]
        [Route("api/InActive/Admin")]
        //[Authorize(Roles = "Admin,SuperAdmin")]
        public HttpResponseMessage InActiveAdmin([FromBody] ValidateUsersIA user)
        {
            if (user != null && user.UserUpdatedBy > 0 && user.UserID > 0)
            {
                var reas = AdminRepoObj.InActiveAdmin(user);
                if (reas)
                    return Request.CreateResponse(HttpStatusCode.OK, new GRValidation()
                    {
                        StatusCode = 200,
                        Success = true,
                        Message = "Account has been deactivated successfully!",
                    });
                else
                    return Request.CreateResponse(HttpStatusCode.OK, new GRValidation()
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
        [Route("api/ReActive/Admin")]
        //[Authorize(Roles = "SuperAdmin")]
        public HttpResponseMessage ReActiveAdmin([FromBody] ValidateUsersIA user)
        {
            if (user != null && user.UserUpdatedBy > 0 && user.UserID > 0)
            {
                var reas = AdminRepoObj.ReActiveAdmin(user);
                if (reas)
                    return Request.CreateResponse(HttpStatusCode.OK, new GRValidation()
                    {
                        StatusCode = 200,
                        Success = true,
                        Message = "Account has been activated successfully!",
                    });
                else
                    return Request.CreateResponse(HttpStatusCode.OK, new GRValidation()
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
        [Route("api/Get/Admin")]
        //[Authorize(Roles = "Admin,SuperAdmin")]
        public HttpResponseMessage GetAdminByID(int AdminID)
        {
            if (AdminID > 0)
            {
                var reas = AdminRepoObj.GetUserDetailById(AdminID);
                if (reas != null)
                    return Request.CreateResponse(HttpStatusCode.OK, new GRIValidation()
                    {
                        StatusCode = 200,
                        Success = true,
                        Message = "Account record has been recieved successfully!",
                        Datalist = reas
                    });
                else
                    return Request.CreateResponse(HttpStatusCode.OK, new GRValidation()
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
