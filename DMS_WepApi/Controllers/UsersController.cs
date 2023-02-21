using System.Net;
using System.Net.Http;
using System.Web.Http;
using DMS_WepApi.Models;
using System.Web.Http.Cors;
using DMS_BLL.Repositories;
using DMS_WepApi.ResponseClasses;
using DMS_BOL.Validation_Classes;
using System.Data.Entity;

namespace DMS_WepApi.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class UsersController : ApiController
    {
        private UsersRepo UserRepoObj;

        public UsersController()
        {
            UserRepoObj = new UsersRepo();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidationActionFilter]
        [Route("api/Register/Patient")]
        public HttpResponseMessage RegisterPatient([FromBody] ValidatePatient user)
        {
            if (user != null)
            {
                var reas = UserRepoObj.InsertPatient(user);
                if (reas)
                    return Request.CreateResponse(HttpStatusCode.Created, new GRValidation()
                    {
                        StatusCode = 201,
                        Success = true,
                        Message = "Your account has been registered successfully!",
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
        [AllowAnonymous]
        [ValidationActionFilter]
        [Route("api/Update/Patient")]
        public HttpResponseMessage UpdatePatient([FromBody] ValidatePatient user)
        {
            if (user != null && user.UserUpdatedBy > 0 && user.UserID > 0)
            {
                var reas = UserRepoObj.UpdatePatient(user);
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
        [AllowAnonymous]
        [ValidationActionFilter]
        [Route("api/InActive/Patient")]
        public HttpResponseMessage InActivePatient([FromBody] ValidateUsersIA user)
        {
            if (user != null && user.UserUpdatedBy > 0 && user.UserID > 0)
            {
                var reas = UserRepoObj.InActivePatient(user);
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
        [AllowAnonymous]
        [ValidationActionFilter]
        [Route("api/ReActive/Patient")]
        public HttpResponseMessage ReActivePatient([FromBody] ValidateUsersIA user)
        {
            if (user != null && user.UserUpdatedBy > 0 && user.UserID > 0)
            {
                var reas = UserRepoObj.ReActivePatient(user);
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
        [AllowAnonymous]
        [ValidationActionFilter]
        [Route("api/Get/Patient")]
        public HttpResponseMessage GetPatientByID(int PatientID)
        {
            if (PatientID > 0)
            {
                var reas = UserRepoObj.GetUserDetailById(PatientID);
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
