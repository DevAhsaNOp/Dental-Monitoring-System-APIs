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
    public class PatientTestController : ApiController
    {
        private PatientTestRepo patientTestRepoObj;

        public PatientTestController()
        {
            patientTestRepoObj = new PatientTestRepo();
        }

        [HttpPost]
        [ValidationActionFilter]
        [Route("api/Insert/PatientTest")]
        //[Authorize(Roles = "Admin,SuperAdmin,Doctor")]
        public HttpResponseMessage InsertPatientTest([FromBody] ValidatePatientTest patientTest)
        {
            if (patientTest != null)
            {
                var reas = patientTestRepoObj.InsertPatientTest(patientTest);
                if (reas > 0)
                    return Request.CreateResponse(HttpStatusCode.OK, new GRIValidation()
                    {
                        StatusCode = 200,
                        Success = true,
                        Message = "Patient Test has been added successfully!",
                        Datalist = reas
                    });
                else
                    return Request.CreateResponse(HttpStatusCode.OK, new GRValidation()
                    {
                        StatusCode = 500,
                        Success = false,
                        Message = "Error occured on adding Patient Test details. Please try again later!",
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
        [Route("api/Update/PatientTest")]
        //[Authorize(Roles = "Admin,SuperAdmin,Doctor")]
        public HttpResponseMessage UpdatePatientTest([FromBody] ValidatePatientTest patientTest)
        {
            if (patientTest != null && patientTest.PT_ID > 0)
            {
                var reas = patientTestRepoObj.UpdatePatientTest(patientTest);
                if (reas > 0)
                    return Request.CreateResponse(HttpStatusCode.OK, new GRIValidation()
                    {
                        StatusCode = 200,
                        Success = true,
                        Message = "Patient Test has been updated successfully!",
                        Datalist = reas
                    });
                else
                    return Request.CreateResponse(HttpStatusCode.OK, new GRValidation()
                    {
                        StatusCode = 500,
                        Success = false,
                        Message = "Error occured on updating patient test details. Please try again later!",
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
        [Route("api/Get/PatientTest")]
        //[Authorize(Roles = "Admin,SuperAdmin,Doctor")]
        public HttpResponseMessage GetPatientTestById(int patientTestID)
        {
            if (patientTestID > 0)
            {
                var reas = patientTestRepoObj.GetPatientTestById(patientTestID);
                if (reas != null)
                    return Request.CreateResponse(HttpStatusCode.OK, new GRIValidation()
                    {
                        StatusCode = 200,
                        Success = true,
                        Message = "Patient Test record has been recieved successfully!",
                        Datalist = reas
                    });
                else
                    return Request.CreateResponse(HttpStatusCode.OK, new GRValidation()
                    {
                        StatusCode = 500,
                        Success = false,
                        Message = "Error occured on getting Patient Test details. Please try again later!",
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
        [Route("api/Get/PatientWantTest")]
        //[Authorize(Roles = "Admin,SuperAdmin,Patient,Doctor")]
        public HttpResponseMessage GetPatientWantTestById(int patientTestID)
        {
            if (patientTestID > 0)
            {
                var reas = patientTestRepoObj.GetPatientWantTestById(patientTestID);
                if (reas != null)
                    return Request.CreateResponse(HttpStatusCode.OK, new GRIValidation()
                    {
                        StatusCode = 200,
                        Success = true,
                        Message = "Patient Test record has been recieved successfully!",
                        Datalist = reas
                    });
                else
                    return Request.CreateResponse(HttpStatusCode.OK, new GRValidation()
                    {
                        StatusCode = 500,
                        Success = false,
                        Message = "Error occured on getting Patient Test details. Please try again later!",
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
        [Route("api/Get/AllPatientTest")]
        //[Authorize(Roles = "Admin,SuperAdmin,Patient,Doctor")]
        [AllowAnonymous]
        public HttpResponseMessage GetPatientAllTest()
        {
            var reas = patientTestRepoObj.GetPatientAllTest();
            if (reas != null)
                return Request.CreateResponse(HttpStatusCode.OK, new GRIValidation()
                {
                    StatusCode = 200,
                    Success = true,
                    Message = "Patient Test record has been recieved successfully!",
                    Datalist = reas
                });
            else
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new GRValidation()
                {
                    StatusCode = 500,
                    Success = false,
                    Message = "Error occured on getting Patient Test details. Please try again later!",
                });
        }
    }
}
