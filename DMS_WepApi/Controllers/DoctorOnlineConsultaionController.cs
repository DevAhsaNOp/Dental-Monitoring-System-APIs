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
    public class DoctorOnlineConsultaionController : ApiController
    {
        private DoctorOnlineConsultaionDetailsRepo ocdRepoObj;

        public DoctorOnlineConsultaionController()
        {
            ocdRepoObj = new DoctorOnlineConsultaionDetailsRepo();
        }

        [HttpPost]
        [ValidationActionFilter]
        [Route("api/Insert/OnlineConsultaion")]
        [Authorize(Roles = "Admin,SuperAdmin,Doctor")]
        public HttpResponseMessage InsertOnlineConsultaionDetail([FromBody] ValidateDoctorOnlineConsultaionDetails OnlineConsultaionDetail)
        {
            if (OnlineConsultaionDetail != null)
            {
                var reas = ocdRepoObj.InsertOnlineConsultaionDetail(OnlineConsultaionDetail);
                if (reas)
                    return Request.CreateResponse(HttpStatusCode.OK, new GRIValidation()
                    {
                        StatusCode = 200,
                        Success = true,
                        Message = "Doctor Online Consultation has been added successfully!",
                        Datalist = reas
                    });
                else
                    return Request.CreateResponse(HttpStatusCode.OK, new GRValidation()
                    {
                        StatusCode = 500,
                        Success = false,
                        Message = "Error occured on adding Online Consultation details. Please try again later!",
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
        [Route("api/Update/OnlineConsultaion")]
        [Authorize(Roles = "Admin,SuperAdmin,Doctor")]
        public HttpResponseMessage UpdateDoctorOnlineConsultaionDetail([FromBody] ValidateDoctorOnlineConsultaionDetails OnlineConsultaionDetail)
        {
            if (OnlineConsultaionDetail != null && OnlineConsultaionDetail.OCD_ID > 0)
            {
                var reas = ocdRepoObj.UpdateOnlineConsultaionDetail(OnlineConsultaionDetail);
                if (reas)
                    return Request.CreateResponse(HttpStatusCode.OK, new GRIValidation()
                    {
                        StatusCode = 200,
                        Success = true,
                        Message = "Doctor Online Consultation has been updated successfully!",
                        Datalist = reas
                    });
                else
                    return Request.CreateResponse(HttpStatusCode.OK, new GRValidation()
                    {
                        StatusCode = 500,
                        Success = false,
                        Message = "Error occured on updating Online Consultation details. Please try again later!",
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
        [Route("api/InActive/OnlineConsultaion")]
        [Authorize(Roles = "Admin,SuperAdmin,Doctor")]
        public HttpResponseMessage InActiveDoctorOnlineConsultaionDetail([FromBody] ValidateDoctorOnlineConsultaionDetails OnlineConsultaionDetail)
        {
            if (OnlineConsultaionDetail != null && OnlineConsultaionDetail.OCD_ID > 0)
            {
                var reas = ocdRepoObj.InActiveOnlineConsultaionDetail(OnlineConsultaionDetail);
                if (reas)
                    return Request.CreateResponse(HttpStatusCode.OK, new GRValidation()
                    {
                        StatusCode = 200,
                        Success = true,
                        Message = "Online Consultation has been deactivated successfully!",
                    });
                else
                    return Request.CreateResponse(HttpStatusCode.OK, new GRValidation()
                    {
                        StatusCode = 500,
                        Success = false,
                        Message = "Error occured on deactivating Online Consultation. Please try again later!",
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
        [Route("api/ReActive/OnlineConsultaion")]
        [Authorize(Roles = "Admin,SuperAdmin")]
        public HttpResponseMessage ReActiveDoctorOnlineConsultaionDetail([FromBody] ValidateDoctorOnlineConsultaionDetails OnlineConsultaionDetail)
        {
            if (OnlineConsultaionDetail != null && OnlineConsultaionDetail.OCD_ID > 0)
            {
                var reas = ocdRepoObj.ReActiveOnlineConsultaionDetail(OnlineConsultaionDetail);
                if (reas)
                    return Request.CreateResponse(HttpStatusCode.OK, new GRValidation()
                    {
                        StatusCode = 200,
                        Success = true,
                        Message = "Online Consultation has been activated successfully!",
                    });
                else
                    return Request.CreateResponse(HttpStatusCode.OK, new GRValidation()
                    {
                        StatusCode = 500,
                        Success = false,
                        Message = "Error occured on activating Online Consultation. Please try again later!",
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
        [Route("api/Get/OnlineConsultaion")]
        [Authorize(Roles = "Admin,SuperAdmin,Doctor")]
        public HttpResponseMessage GetDoctorOnlineConsultaionDetailByID(int OConsultationID)
        {
            if (OConsultationID > 0)
            {
                var reas = ocdRepoObj.GetOnlineConsultaionDetailByID(OConsultationID);
                if (reas != null)
                    return Request.CreateResponse(HttpStatusCode.OK, new GRIValidation()
                    {
                        StatusCode = 200,
                        Success = true,
                        Message = "Online Consultation record has been recieved successfully!",
                        Datalist = reas
                    });
                else
                    return Request.CreateResponse(HttpStatusCode.OK, new GRValidation()
                    {
                        StatusCode = 500,
                        Success = false,
                        Message = "Error occured on getting Online Consultation details. Please try again later!",
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
        [Route("api/Get/DoctorOnlineConsultaionDetails")]
        [Authorize(Roles = "Admin,SuperAdmin,Patient,Doctor")]
        public HttpResponseMessage GetDoctorAllOnlineConsultaionDetailsByID(int DoctorID)
        {
            if (DoctorID > 0)
            {
                var reas = ocdRepoObj.GetDoctorAllOnlineConsultaionDetailsByID(DoctorID);
                if (reas != null)
                    return Request.CreateResponse(HttpStatusCode.OK, new GRIValidation()
                    {
                        StatusCode = 200,
                        Success = true,
                        Message = "Online Consultation record has been recieved successfully!",
                        Datalist = reas
                    });
                else
                    return Request.CreateResponse(HttpStatusCode.OK, new GRValidation()
                    {
                        StatusCode = 500,
                        Success = false,
                        Message = "Error occured on getting Online Consultation details. Please try again later!",
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
