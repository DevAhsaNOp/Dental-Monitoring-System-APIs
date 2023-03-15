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
    public class DoctorOfflineConsultaionController : ApiController
    {
        private DoctorOfflineConsultaionDetailsRepo ofcdRepoObj;

        public DoctorOfflineConsultaionController()
        {
            ofcdRepoObj = new DoctorOfflineConsultaionDetailsRepo();
        }

        [HttpPost]
        [ValidationActionFilter]
        [Route("api/Insert/OfflineConsultaion")]
        [Authorize(Roles = "Admin,SuperAdmin,Doctor")]
        public HttpResponseMessage InsertOfflineConsultaionDetail([FromBody] ValidateDoctorOfflineConsultaionDetails OfflineConsultaionDetail)
        {
            if (OfflineConsultaionDetail != null)
            {
                var reas = ofcdRepoObj.InsertOfflineConsultaionDetail(OfflineConsultaionDetail);
                if (reas)
                    return Request.CreateResponse(HttpStatusCode.OK, new GRIValidation()
                    {
                        StatusCode = 200,
                        Success = true,
                        Message = "Doctor Offline Consultation has been added successfully!",
                        Datalist = reas
                    });
                else
                    return Request.CreateResponse(HttpStatusCode.OK, new GRValidation()
                    {
                        StatusCode = 500,
                        Success = false,
                        Message = "Error occured on adding Offline Consultation details. Please try again later!",
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
        [Route("api/Update/OfflineConsultaion")]
        [Authorize(Roles = "Admin,SuperAdmin,Doctor")]
        public HttpResponseMessage UpdateDoctorOfflineConsultaionDetail([FromBody] ValidateDoctorOfflineConsultaionDetails OfflineConsultaionDetail)
        {
            if (OfflineConsultaionDetail != null && OfflineConsultaionDetail.OFCD_ID > 0)
            {
                var reas = ofcdRepoObj.UpdateOfflineConsultaionDetail(OfflineConsultaionDetail);
                if (reas)
                    return Request.CreateResponse(HttpStatusCode.OK, new GRIValidation()
                    {
                        StatusCode = 200,
                        Success = true,
                        Message = "Doctor Offline Consultation has been updated successfully!",
                        Datalist = reas
                    });
                else
                    return Request.CreateResponse(HttpStatusCode.OK, new GRValidation()
                    {
                        StatusCode = 500,
                        Success = false,
                        Message = "Error occured on updating Offline Consultation details. Please try again later!",
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
        [Route("api/InActive/OfflineConsultaion")]
        [Authorize(Roles = "Admin,SuperAdmin,Doctor")]
        public HttpResponseMessage InActiveDoctorOfflineConsultaionDetail([FromBody] ValidateDoctorOfflineConsultaionDetails OfflineConsultaionDetail)
        {
            if (OfflineConsultaionDetail != null && OfflineConsultaionDetail.OFCD_ID > 0)
            {
                var reas = ofcdRepoObj.InActiveOfflineConsultaionDetail(OfflineConsultaionDetail);
                if (reas)
                    return Request.CreateResponse(HttpStatusCode.OK, new GRValidation()
                    {
                        StatusCode = 200,
                        Success = true,
                        Message = "Offline Consultation has been deactivated successfully!",
                    });
                else
                    return Request.CreateResponse(HttpStatusCode.OK, new GRValidation()
                    {
                        StatusCode = 500,
                        Success = false,
                        Message = "Error occured on deactivating Offline Consultation. Please try again later!",
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
        [Route("api/ReActive/OfflineConsultaion")]
        [Authorize(Roles = "Admin,SuperAdmin")]
        public HttpResponseMessage ReActiveDoctorOfflineConsultaionDetail([FromBody] ValidateDoctorOfflineConsultaionDetails OfflineConsultaionDetail)
        {
            if (OfflineConsultaionDetail != null && OfflineConsultaionDetail.OFCD_ID > 0)
            {
                var reas = ofcdRepoObj.ReActiveOfflineConsultaionDetail(OfflineConsultaionDetail);
                if (reas)
                    return Request.CreateResponse(HttpStatusCode.OK, new GRValidation()
                    {
                        StatusCode = 200,
                        Success = true,
                        Message = "Offline Consultation has been activated successfully!",
                    });
                else
                    return Request.CreateResponse(HttpStatusCode.OK, new GRValidation()
                    {
                        StatusCode = 500,
                        Success = false,
                        Message = "Error occured on activating Offline Consultation. Please try again later!",
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
        [Route("api/Get/OfflineConsultaion")]
        [Authorize(Roles = "Admin,SuperAdmin,Doctor")]
        public HttpResponseMessage GetDoctorOfflineConsultaionDetailByID(int OFConsultationID)
        {
            if (OFConsultationID > 0)
            {
                var reas = ofcdRepoObj.GetOfflineConsultaionDetailByID(OFConsultationID);
                if (reas != null)
                    return Request.CreateResponse(HttpStatusCode.OK, new GRIValidation()
                    {
                        StatusCode = 200,
                        Success = true,
                        Message = "Offline Consultation record has been recieved successfully!",
                        Datalist = reas
                    });
                else
                    return Request.CreateResponse(HttpStatusCode.OK, new GRValidation()
                    {
                        StatusCode = 500,
                        Success = false,
                        Message = "Error occured on getting Offline Consultation details. Please try again later!",
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
        [Route("api/Get/DoctorOfflineConsultaionDetails")]
        [Authorize(Roles = "Admin,SuperAdmin,Patient,Doctor")]
        public HttpResponseMessage GetDoctorAllOfflineConsultaionDetailsByID(int DoctorID)
        {
            if (DoctorID > 0)
            {
                var reas = ofcdRepoObj.GetDoctorAllOfflineConsultaionDetailsByID(DoctorID);
                if (reas != null)
                    return Request.CreateResponse(HttpStatusCode.OK, new GRIValidation()
                    {
                        StatusCode = 200,
                        Success = true,
                        Message = "Offline Consultation record has been recieved successfully!",
                        Datalist = reas
                    });
                else
                    return Request.CreateResponse(HttpStatusCode.OK, new GRValidation()
                    {
                        StatusCode = 500,
                        Success = false,
                        Message = "Error occured on getting Offline Consultation details. Please try again later!",
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
