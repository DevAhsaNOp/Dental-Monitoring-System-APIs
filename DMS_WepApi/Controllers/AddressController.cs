using System.Net;
using System.Net.Http;
using System.Web.Http;
using DMS_WepApi.Models;
using System.Web.Http.Cors;
using DMS_BLL.Repositories;
using DMS_WepApi.ResponseClasses;

namespace DMS_WepApi.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class AddressController : ApiController
    {
        private AddressRepo AddressRepoObj;

        public AddressController()
        {
            AddressRepoObj = new AddressRepo();
        }

        [HttpGet]
        [ValidationActionFilter]
        [Route("api/Get/Address")]
        [Authorize(Roles = "Admin,SuperAdmin,Patient,Doctor")]
        public HttpResponseMessage GetAddressByID(int AddressID)
        {
            if (AddressID > 0)
            {
                var reas = AddressRepoObj.GetAddressById(AddressID);
                if (reas != null)
                    return Request.CreateResponse(HttpStatusCode.OK, new GRIValidation()
                    {
                        StatusCode = 200,
                        Success = true,
                        Message = "Address record has been recieved successfully!",
                        Datalist = reas
                    });
                else
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, new GRValidation()
                    {
                        StatusCode = 500,
                        Success = false,
                        Message = "Error occured on getting Address details. Please try again later!",
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
        [Route("api/Get/State")]
        public HttpResponseMessage GetAllState()
        {
            var reas = AddressRepoObj.GetAllState();
            if (reas != null)
                return Request.CreateResponse(HttpStatusCode.OK, new GRIValidation()
                {
                    StatusCode = 200,
                    Success = true,
                    Message = "State record has been recieved successfully!",
                    Datalist = reas
                });
            else
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new GRValidation()
                {
                    StatusCode = 500,
                    Success = false,
                    Message = "Error occured on getting State details. Please try again later!",
                });
        }
        
        [HttpGet]
        [ValidationActionFilter]
        [Route("api/Get/City")]
        public HttpResponseMessage GetAllCity()
        {
            var reas = AddressRepoObj.GetAllCity();
            if (reas != null)
                return Request.CreateResponse(HttpStatusCode.OK, new GRIValidation()
                {
                    StatusCode = 200,
                    Success = true,
                    Message = "City record has been recieved successfully!",
                    Datalist = reas
                });
            else
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new GRValidation()
                {
                    StatusCode = 500,
                    Success = false,
                    Message = "Error occured on getting City details. Please try again later!",
                });
        }
        
        [HttpGet]
        [ValidationActionFilter]
        [Route("api/Get/Zone")]
        public HttpResponseMessage GetAllZone()
        {
            var reas = AddressRepoObj.GetAllZone();
            if (reas != null)
                return Request.CreateResponse(HttpStatusCode.OK, new GRIValidation()
                {
                    StatusCode = 200,
                    Success = true,
                    Message = "Zone record has been recieved successfully!",
                    Datalist = reas
                });
            else
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new GRValidation()
                {
                    StatusCode = 500,
                    Success = false,
                    Message = "Error occured on getting Zone details. Please try again later!",
                });
        }
        
        [HttpGet]
        [ValidationActionFilter]
        [Route("api/Get/CityByState")]
        public HttpResponseMessage GetCitiesByState(int StateID)
        {
            var reas = AddressRepoObj.GetCitiesByState(StateID);
            if (reas != null)
                return Request.CreateResponse(HttpStatusCode.OK, new GRIValidation()
                {
                    StatusCode = 200,
                    Success = true,
                    Message = "City record has been recieved successfully!",
                    Datalist = reas
                });
            else
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new GRValidation()
                {
                    StatusCode = 500,
                    Success = false,
                    Message = "Error occured on getting City details. Please try again later!",
                });
        }
        
        [HttpGet]
        [ValidationActionFilter]
        [Route("api/Get/ZoneByCity")]
        public HttpResponseMessage GetZoneByCity(int CityID)
        {
            var reas = AddressRepoObj.GetZoneByCity(CityID);
            if (reas != null)
                return Request.CreateResponse(HttpStatusCode.OK, new GRIValidation()
                {
                    StatusCode = 200,
                    Success = true,
                    Message = "Zone record has been recieved successfully!",
                    Datalist = reas
                });
            else
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new GRValidation()
                {
                    StatusCode = 500,
                    Success = false,
                    Message = "Error occured on getting Zone details. Please try again later!",
                });
        }

    }
}
