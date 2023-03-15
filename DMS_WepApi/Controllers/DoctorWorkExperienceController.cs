using System.Net;
using System.Net.Http;
using System.Web.Http;
using DMS_WepApi.Models;
using System.Web.Http.Cors;
using DMS_BLL.Repositories;
using DMS_BOL.Validation_Classes;
using DMS_WepApi.ResponseClasses;

namespace DMS_WepApi.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class DoctorWorkExperienceController : ApiController
    {
        private DoctorWorkExperienceRepo wexRepoObj;

        public DoctorWorkExperienceController()
        {
            wexRepoObj = new DoctorWorkExperienceRepo();
        }

        [HttpPost]
        [ValidationActionFilter]
        [Route("api/Insert/WorkExperience")]
        [Authorize(Roles = "Admin,SuperAdmin,Doctor")]
        public HttpResponseMessage InsertDoctorWorkExperience([FromBody] ValidateDoctorWorkExperience WorkExperience)
        {
            if (WorkExperience != null)
            {
                var reas = wexRepoObj.InsertDoctorWorkExperience(WorkExperience);
                if (reas)
                    return Request.CreateResponse(HttpStatusCode.OK, new GRIValidation()
                    {
                        StatusCode = 200,
                        Success = true,
                        Message = "Doctor Work Experience has been added successfully!",
                        Datalist = reas
                    });
                else
                    return Request.CreateResponse(HttpStatusCode.OK, new GRValidation()
                    {
                        StatusCode = 500,
                        Success = false,
                        Message = "Error occured on adding Work Experience details. Please try again later!",
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
        [Route("api/Update/WorkExperience")]
        [Authorize(Roles = "Admin,SuperAdmin,Doctor")]
        public HttpResponseMessage UpdateDoctorWorkExperience([FromBody] ValidateDoctorWorkExperience WorkExperience)
        {
            if (WorkExperience != null && WorkExperience.WEX_ID > 0)
            {
                var reas = wexRepoObj.UpdateDoctorWorkExperience(WorkExperience);
                if (reas)
                    return Request.CreateResponse(HttpStatusCode.OK, new GRIValidation()
                    {
                        StatusCode = 200,
                        Success = true,
                        Message = "Doctor Work Experience has been updated successfully!",
                        Datalist = reas
                    });
                else
                    return Request.CreateResponse(HttpStatusCode.OK, new GRValidation()
                    {
                        StatusCode = 500,
                        Success = false,
                        Message = "Error occured on updating Work Experience details. Please try again later!",
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
        [Route("api/InActive/WorkExperience")]
        [Authorize(Roles = "Admin,SuperAdmin,Doctor")]
        public HttpResponseMessage InActiveDoctorWorkExperience([FromBody] ValidateDoctorWorkExperience WorkExperience)
        {
            if (WorkExperience != null && WorkExperience.WEX_ID > 0)
            {
                var reas = wexRepoObj.InActiveDoctorWorkExperience(WorkExperience);
                if (reas)
                    return Request.CreateResponse(HttpStatusCode.OK, new GRValidation()
                    {
                        StatusCode = 200,
                        Success = true,
                        Message = "Work Experience has been deactivated successfully!",
                    });
                else
                    return Request.CreateResponse(HttpStatusCode.OK, new GRValidation()
                    {
                        StatusCode = 500,
                        Success = false,
                        Message = "Error occured on deactivating Work Experience. Please try again later!",
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
        [Route("api/ReActive/WorkExperience")]
        [Authorize(Roles = "Admin,SuperAdmin")]
        public HttpResponseMessage ReActiveDoctorWorkExperience([FromBody] ValidateDoctorWorkExperience WorkExperience)
        {
            if (WorkExperience != null && WorkExperience.WEX_ID > 0)
            {
                var reas = wexRepoObj.ReActiveDoctorWorkExperience(WorkExperience);
                if (reas)
                    return Request.CreateResponse(HttpStatusCode.OK, new GRValidation()
                    {
                        StatusCode = 200,
                        Success = true,
                        Message = "Work Experience has been activated successfully!",
                    });
                else
                    return Request.CreateResponse(HttpStatusCode.OK, new GRValidation()
                    {
                        StatusCode = 500,
                        Success = false,
                        Message = "Error occured on activating Work Experience. Please try again later!",
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
        [Route("api/Get/WorkExperience")]
        [Authorize(Roles = "Admin,SuperAdmin,Doctor")]
        public HttpResponseMessage GetDoctorWorkExperienceByID(int WExperienceID)
        {
            if (WExperienceID > 0)
            {
                var reas = wexRepoObj.GetDoctorWorkExperienceByID(WExperienceID);
                if (reas != null)
                    return Request.CreateResponse(HttpStatusCode.OK, new GRIValidation()
                    {
                        StatusCode = 200,
                        Success = true,
                        Message = "Work Experience record has been recieved successfully!",
                        Datalist = reas
                    });
                else
                    return Request.CreateResponse(HttpStatusCode.OK, new GRValidation()
                    {
                        StatusCode = 500,
                        Success = false,
                        Message = "Error occured on getting Work Experience details. Please try again later!",
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
        [Route("api/Get/DoctorWorkExperience")]
        [Authorize(Roles = "Admin,SuperAdmin,Patient,Doctor")]
        public HttpResponseMessage GetDoctorAllWorkExperiencesByID(int DoctorID)
        {
            if (DoctorID > 0)
            {
                var reas = wexRepoObj.GetDoctorAllWorkExperiencesByID(DoctorID);
                if (reas != null)
                    return Request.CreateResponse(HttpStatusCode.OK, new GRIValidation()
                    {
                        StatusCode = 200,
                        Success = true,
                        Message = "Work Experience record has been recieved successfully!",
                        Datalist = reas
                    });
                else
                    return Request.CreateResponse(HttpStatusCode.OK, new GRValidation()
                    {
                        StatusCode = 500,
                        Success = false,
                        Message = "Error occured on getting Work Experience details. Please try again later!",
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
