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
    public class DoctorServicesController : ApiController
    {
        private DoctorServicesRepo servicesRepoObj;

        public DoctorServicesController()
        {
            servicesRepoObj = new DoctorServicesRepo();
        }

        [HttpPost]
        [ValidationActionFilter]
        [Route("api/Insert/Services")]
        [Authorize(Roles = "Admin,SuperAdmin,Doctor")]
        public HttpResponseMessage InsertDoctorServices([FromBody] ValidateDoctorServices services)
        {
            if (services != null)
            {
                var reas = servicesRepoObj.InsertDoctorServices(services);
                if (reas)
                    return Request.CreateResponse(HttpStatusCode.OK, new GRIValidation()
                    {
                        StatusCode = 200,
                        Success = true,
                        Message = "Doctor services has been added successfully!",
                        Datalist = reas
                    });
                else
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, new GRValidation()
                    {
                        StatusCode = 500,
                        Success = false,
                        Message = "Error occured on adding services details. Please try again later!",
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
        [Route("api/InActive/Services")]
        [Authorize(Roles = "Admin,SuperAdmin,Doctor")]
        public HttpResponseMessage InActiveDoctorServices([FromBody] ValidateDoctorServices services)
        {
            if (services != null && services.DS_ID > 0)
            {
                var reas = servicesRepoObj.InActiveDoctorServices(services);
                if (reas)
                    return Request.CreateResponse(HttpStatusCode.OK, new GRValidation()
                    {
                        StatusCode = 200,
                        Success = true,
                        Message = "Services has been deactivated successfully!",
                    });
                else
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, new GRValidation()
                    {
                        StatusCode = 500,
                        Success = false,
                        Message = "Error occured on deactivating Services. Please try again later!",
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
        [Route("api/ReActive/Services")]
        [Authorize(Roles = "Admin,SuperAdmin")]
        public HttpResponseMessage ReActiveDoctorServices([FromBody] ValidateDoctorServices services)
        {
            if (services != null && services.DS_ID > 0)
            {
                var reas = servicesRepoObj.ReActiveDoctorServices(services);
                if (reas)
                    return Request.CreateResponse(HttpStatusCode.OK, new GRValidation()
                    {
                        StatusCode = 200,
                        Success = true,
                        Message = "Services has been activated successfully!",
                    });
                else
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, new GRValidation()
                    {
                        StatusCode = 500,
                        Success = false,
                        Message = "Error occured on activating Services. Please try again later!",
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
        [Route("api/Get/Services")]
        [Authorize(Roles = "Admin,SuperAdmin,Doctor")]
        public HttpResponseMessage GetDoctorServicesByID(int ServiceID)
        {
            if (ServiceID > 0)
            {
                var reas = servicesRepoObj.GetDoctorServicesByID(ServiceID);
                if (reas != null)
                    return Request.CreateResponse(HttpStatusCode.OK, new GRIValidation()
                    {
                        StatusCode = 200,
                        Success = true,
                        Message = "Services record has been recieved successfully!",
                        Datalist = reas
                    });
                else
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, new GRValidation()
                    {
                        StatusCode = 500,
                        Success = false,
                        Message = "Error occured on getting Services details. Please try again later!",
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
        [Route("api/Get/DoctorServices")]
        [Authorize(Roles = "Admin,SuperAdmin,Patient,Doctor")]
        public HttpResponseMessage GetAllDoctorServicesByID(int DoctorID)
        {
            if (DoctorID > 0)
            {
                var reas = servicesRepoObj.GetAllDoctorServicesByID(DoctorID);
                if (reas != null)
                    return Request.CreateResponse(HttpStatusCode.OK, new GRIValidation()
                    {
                        StatusCode = 200,
                        Success = true,
                        Message = "Services record has been recieved successfully!",
                        Datalist = reas
                    });
                else
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, new GRValidation()
                    {
                        StatusCode = 500,
                        Success = false,
                        Message = "Error occured on getting Services details. Please try again later!",
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
        [Route("api/Get/AllServices")]
        //[Authorize(Roles = "Admin,SuperAdmin,Patient,Doctor")]
        [AllowAnonymous]
        public HttpResponseMessage GetAllServices()
        {
            var reas = servicesRepoObj.GetAllDoctorServices();
            if (reas != null)
                return Request.CreateResponse(HttpStatusCode.OK, new GRIValidation()
                {
                    StatusCode = 200,
                    Success = true,
                    Message = "Services record has been recieved successfully!",
                    Datalist = reas
                });
            else
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new GRValidation()
                {
                    StatusCode = 500,
                    Success = false,
                    Message = "Error occured on getting Services details. Please try again later!",
                });
        }

    }
}
