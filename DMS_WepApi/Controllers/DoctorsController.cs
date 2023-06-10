using System.Net;
using System.Net.Http;
using System.Web.Http;
using DMS_WepApi.Models;
using System.Web.Http.Cors;
using DMS_BLL.Repositories;
using DMS_BOL.Validation_Classes;
using DMS_WepApi.ResponseClasses;
using System.Linq;

namespace DMS_WepApi.Controllers
{
    //[Authorize]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class DoctorsController : ApiController
    {
        private DoctorsRepo DoctorRepoObj;

        public DoctorsController()
        {
            DoctorRepoObj = new DoctorsRepo();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidationActionFilter]
        [Route("api/Register/Doctor")]
        public HttpResponseMessage RegisterDoctor([FromBody] ValidateDoctor user)
        {
            if (user != null)
            {
                var reas = DoctorRepoObj.InsertDoctor(user);
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
        [Route("api/Update/Doctor")]
        //[Authorize(Roles = "Admin,SuperAdmin,Doctor")]
        public HttpResponseMessage UpdateDoctor([FromBody] ValidateDoctor user)
        {
            if (user != null && user.UserUpdatedBy > 0 && user.UserID > 0 && !string.IsNullOrEmpty(user.UserUpdatePhoneNumber) && !string.IsNullOrEmpty(user.UserUpdateEmail))
            {
                var reas = DoctorRepoObj.UpdateDoctor(user);
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
                    Message = "Invalid data provided. Please provide User ID or Updated By!"
                });
        }

        [HttpPost]
        [ValidationActionFilter]
        [Route("api/InActive/Doctor")]
        //[Authorize(Roles = "Admin,SuperAdmin,Doctor")]
        public HttpResponseMessage InActiveDoctor([FromBody] ValidateUsersIA user)
        {
            if (user != null && user.UserUpdatedBy > 0 && user.UserID > 0)
            {
                var reas = DoctorRepoObj.InActiveDoctor(user);
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
        [Route("api/ReActive/Doctor")]
        //[Authorize(Roles = "Admin,SuperAdmin")]
        public HttpResponseMessage ReActiveDoctor([FromBody] ValidateUsersIA user)
        {
            if (user != null && user.UserUpdatedBy > 0 && user.UserID > 0)
            {
                var reas = DoctorRepoObj.ReActiveDoctor(user);
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
        [Route("api/Get/AllDoctors")]
        //[Authorize(Roles = "Admin,SuperAdmin,Patient,Doctor")]
        public HttpResponseMessage GetAllDoctors()
        {
            var reas = DoctorRepoObj.GetAllDoctors();
            if (reas != null && reas.Count() > 0)
                return Request.CreateResponse(HttpStatusCode.OK, new GRIValidation()
                {
                    StatusCode = 200,
                    Success = true,
                    Message = "All doctors record has been recieved successfully!",
                    Datalist = reas
                });
            else
                return Request.CreateResponse(HttpStatusCode.OK, new GRValidation()
                {
                    StatusCode = 500,
                    Success = false,
                    Message = "Error occured on getting Doctors details. Please try again later!",
                });
        }

        [HttpGet]
        [ValidationActionFilter]
        [Route("api/Get/Doctor")]
        //[Authorize(Roles = "Admin,SuperAdmin,Patient,Doctor")]
        public HttpResponseMessage GetDoctorByID(int DoctorID)
        {
            if (DoctorID > 0)
            {
                var reas = DoctorRepoObj.GetUserDetailById(DoctorID);
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
